using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Integrador.Models;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Integrador.Services.Extension;
using Integrador.DAL;
using Integrador.Models.Clases;

namespace Integrador.Services
{
    public class UserService
    {
        private Context db = new Context();

        public Usuario findUserByUsername(string username)
        {
            return db.Usuarios
                .Where(u => u.Username == username)
                .FirstOrDefault();
        }

        public void createNewUser(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        public void updateUser(Usuario usuario)
        {
            var usr = db.Usuarios.SingleOrDefault(u => u.Id == usuario.Id);
            if (usr != null)
            {
                usr = usuario;
                db.SaveChanges();
            }
        }

        public bool isAdmin(Models.Usuario usuario)
        {
            var admin = db.Administradores.SingleOrDefault(a => a.Id == usuario.Id);
            if (admin != null)
            {
                return true;
            }
            return false;
        }

        public void CheckUser(int userId)
        {
            var cliente = db.Clientes
                .Where(c => c.Id == userId)
                .FirstOrDefault();
            if (cliente != null && cliente.Transformador != null){
                this.setTransformador(cliente.Id);
            }
        }
        public void setTransformador(int clienteId)
        {
            var transformadores = db.Transformadores;
            var cliente = db.Clientes
                .Where(c => c.Id == clienteId)
                .FirstOrDefault();
            IDictionary<Transformador, float> distancias = new Dictionary<Transformador, float>();

            foreach (Transformador trans in transformadores)
            {
                var transformadorLat = trans.Latitud;
                var transformadorLong = trans.Longitud;
                var clienteLat = cliente.Latitud;
                var clienteLong = cliente.Longitud;

                var distancia = Extension.Extension.DistanciaKm(transformadorLat, transformadorLong, clienteLat, clienteLong);
                distancias.Add(trans, distancia);
            }
            System.Diagnostics.Debug.WriteLine("Transformadores totales : " + distancias.Count());
            Transformador transformadorCercano = distancias.FirstOrDefault(x => x.Value == distancias.Values.Min()).Key;
            System.Diagnostics.Debug.WriteLine("Transformadores elegido : " + transformadorCercano.Id);
            cliente.Transformador = transformadorCercano;
            db.SaveChanges();
        }
    }
}