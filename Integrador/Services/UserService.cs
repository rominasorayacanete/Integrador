using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Integrador.Models;
using Integrador.Models.Clases.Tipos;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Integrador.ORM;
using Integrador.Services.Extension;

namespace Integrador.Services
{
    public class UserService
    {

        public ORM.Usuario findUserByUsername(string username)
        {
            using (var db = new DBContext())
            {
                return db.Usuario
                    .Where(u => u.username == username)
                    .FirstOrDefault();
            }
        }

        public void createNewUser(ORM.Usuario usuario)
        {
            using (var db = new DBContext())
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
            }
        }

        public void updateUser(ORM.Usuario usuario)
        {
            using (var db = new DBContext())
            {
                var usr = db.Usuario.SingleOrDefault(u => u.id == usuario.id);
                if (usr != null)
                {
                    usr = usuario;
                    db.SaveChanges();
                }
            }
        }

        public bool isAdmin(ORM.Usuario usuario)
        {
            using (var db = new DBContext())
            {
                var admin = db.Administrador.SingleOrDefault(a => a.Usuario.id == usuario.id);
                if (admin != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void CheckUser(int userId)
        {
            using (var db = new DBContext())
            {
                var cliente = db.Cliente
                    .Where(c => c.Usuario.id == userId)
                    .FirstOrDefault();
                if (cliente != null && cliente.transformador_id != null){
                    this.setTransformador(cliente.id);
                }
            }

        }
        public void setTransformador(int clienteId)
        {
            using (var db = new DBContext())
            {
                var transformadores = db.Transformador;
                var cliente = db.Cliente
                    .Where(c => c.id == clienteId)
                    .FirstOrDefault();
                IDictionary<ORM.Transformador, float> distancias = new Dictionary<ORM.Transformador, float>();

                foreach (ORM.Transformador trans in transformadores)
                {
                    var transformadorLat = trans.latitud;
                    var transformadorLong = trans.longitud;
                    var clienteLat = cliente.latitud;
                    var clienteLong = cliente.longitud;

                    var distancia = Extension.Extension.DistanciaKm(transformadorLat, transformadorLong, clienteLat, clienteLong);
                    distancias.Add(trans, distancia);
                }
                System.Diagnostics.Debug.WriteLine("Transformadores totales : " + distancias.Count());
                ORM.Transformador transformadorCercano = distancias.FirstOrDefault(x => x.Value == distancias.Values.Min()).Key;
                System.Diagnostics.Debug.WriteLine("Transformadores elegido : " + transformadorCercano.id);
                cliente.Transformador = transformadorCercano;
                db.SaveChanges();
            }

        }
    }
}