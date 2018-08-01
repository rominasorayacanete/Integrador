using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Integrador.Models;

namespace Integrador.DAL
{
    public class IntegradorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<IntegradorContext>
    {
        protected override void Seed(IntegradorContext context)
        {
            var categorias = new List<Categoria>
            {
            new Categoria{ConsumoMaximo=100,ConsumoMinimo=10,CargoFijo=20,CargoVariable=10},
            new Categoria{ConsumoMaximo=200,ConsumoMinimo=20,CargoFijo=40,CargoVariable=20},
            };

            categorias.ForEach(s => context.Categorias.Add(s));
            context.SaveChanges();
        }
    }
}