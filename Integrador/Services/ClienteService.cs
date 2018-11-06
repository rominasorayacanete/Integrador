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
    public class ClienteService
    {

        public ORM.Cliente findUserByUserId(int userId)
        {
            using (var db = new DBContext())
            {
                return db.Cliente
                    .Where(c => c.usuario_id == userId)
                    .FirstOrDefault();
            }
        }

        public void createNewCliente(ORM.Cliente cliente)
        {
            using (var db = new DBContext())
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
            }
        }

        public void updateGeoCliente(ORM.Cliente cliente, double latitud, double longitud)
        {
            using (var db = new DBContext())
            {
                var cli = db.Cliente.SingleOrDefault(c => c.id == cliente.id);
                if (cli != null)
                {
                    cli.latitud = latitud;
                    cli.longitud = longitud;
                    db.SaveChanges();
                }
            }
        }
    }
}