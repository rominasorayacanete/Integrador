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
        public void CheckUser(ORM.Usuario usuario)
        {
            using (var db = new DBContext())
            {
                var cliente = db.Cliente
                    .Where(c => c.Usuario == usuario)
                    .FirstOrDefault();
                if (cliente != null && cliente.Transformador1 != null){
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
                IDictionary<Transformador, float> distancias = new Dictionary<Transformador, float>();

                foreach (Transformador trans in transformadores)
                {
                    var transformadorLat = trans.latitud;
                    var transformadorLong = trans.longitud;
                    var clienteLat = cliente.latitud;
                    var clienteLong = cliente.longitud;

                    var distancia = Extension.Extension.DistanciaKm(transformadorLat, transformadorLong, clienteLat, clienteLong);
                    distancias.Add(trans, distancia);
                }
                Transformador transformadorCercano = distancias.FirstOrDefault(x => x.Value == distancias.Values.Min()).Key;
                cliente.Transformador1 = transformadorCercano;
                db.SaveChanges();
            }

        }
    }
}