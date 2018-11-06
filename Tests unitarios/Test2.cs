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
        public void CasoDePrueba2()
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
            var queryDispositivo = from d in db.Dispositivo select d;
            var dispositivo = queryDispositivo.FirstOrDefault();

            foreach (Operacion op in dispositivo.Operacion)
            {
                if(op.oper_descripcion == "encendido" && (((DateTime.Now.Year - op.oper_fecha.Year) * 12) + DateTime.Now.Month - op.oper_fecha.Month) == 0)
                {
                    Console.WriteLine("El dispositivo " + dispositivo.id + " fue encendido en: \n");
                    Console.WriteLine(op.oper_fecha);
                }

                if (op.oper_descripcion == "apagado" && (((DateTime.Now.Year - op.oper_fecha.Year) * 12) + DateTime.Now.Month - op.oper_fecha.Month) == 0)
                {
                    Console.WriteLine("El dispositivo " + dispositivo.id + " fue apagado en: \n");
                    Console.WriteLine(op.oper_fecha);
                }
            }

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
