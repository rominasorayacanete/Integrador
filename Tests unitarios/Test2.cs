using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integrador.ORM;
using System.Data.Entity;
using System.Linq;

namespace Tests_unitarios
{
    [TestClass]
    public class Test2
    {
        [TestMethod]
        public void TestMethod1()
        {
            using(DBContext db = new DBContext())
            {
                string nombreGrabado = CambiarNombre(db);
                string nombrePersistido = NombrePersistido(db);
                Assert.AreEqual(nombreGrabado, nombrePersistido);
            }
        }

        public string CambiarNombre(DBContext db)
        {
            var query = from d in db.Dispositivo select d;
            var dispositivo = query.FirstOrDefault();
            string nombreGrabado = dispositivo.nombre_generico = "NuevoNombre";
            db.SaveChanges();
            return nombreGrabado;
        }

        public string NombrePersistido(DBContext db)
        {
            var query = from d in db.Dispositivo select d;
            var dispositivo = query.FirstOrDefault();
            return dispositivo.nombre_generico;
        }
    }
}
