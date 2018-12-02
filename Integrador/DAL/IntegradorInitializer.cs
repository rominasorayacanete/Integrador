using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Integrador.Models;

namespace Integrador.DAL
{
    public class IntegradorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            List<Usuario> usuarios = new List<Usuario>();

            Usuario user1 = new Usuario { Username = "admin1", Password = "admin1", Email = "admin@admin1.com", FechaAltaSistema = new DateTime() };

            usuarios.Add(user1);

            usuarios.ForEach(u => context.Usuarios.Add(u));
            context.SaveChanges();
        }
    }
}