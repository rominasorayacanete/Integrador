using System.Collections.Generic;
using Newtonsoft.Json;
using Integrador.DAL;
using Integrador.Models.Clases;
using System.Data.Entity;
using System.Linq;

namespace Integrador.Services
{
    public class TransformadorService
    {
        private Context db = new Context();

        public IQueryable<Transformador> getAll()
        {
            return db.Transformadores;
        }

        public Transformador FindById(int transformadorId)
        {
            return db.Transformadores
                  .Where(t => t.Id == transformadorId)
                  .FirstOrDefault();
        }
    }
}