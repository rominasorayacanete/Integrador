using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Integrador.ORM;
using System.Data.Entity;
using System.Linq;

namespace Tests_unitarios
{
    [TestClass]
    public class Test3
    {
        [TestMethod]
         public void CasoDePrueba3()
        {
            using (DBContext db = new DBContext())
            {
                Regla regla = new Regla();
                Actuador actuador = new Actuador();
                var queryDispositivo = from d in db.Dispositivo select d;
                var dispositivo = queryDispositivo.FirstOrDefault();


                //PERSISTENCIA SENSOR


                Sensor sensor = new Sensor();
                sensor.magnitud = "MagnitudTest";
                db.Sensor.Add(sensor);
                db.SaveChanges();

                var sensorQuery = from s in db.Sensor where s.magnitud == "MagnitudTest" select s;
                var _sensor = sensorQuery.First();


                //PERSISTENCIA REGLA


                regla.condicion = "NuevaCondicion2";
                regla.regla_cumplida = true;
                regla.sensor = _sensor.id;
                db.Regla.Add(regla);
                db.SaveChanges();


                //PERSISTENCIA DISPOSITIVO


                Dispositivo disp = new Dispositivo();
                disp.nombre_generico = "OtroDispositivo";
                disp.consumo_hora = 4000;
                disp.encendido = true;
                disp.consumo = 2;
                db.Dispositivo.Add(disp);
                db.SaveChanges();

                var query = from d in db.Dispositivo where d.nombre_generico == "OtroDispositivo" select d;
                var dsp = query.FirstOrDefault();
                int dispositivoID = dsp.id;


                //PERSISTENCIA ACTUADOR


                actuador.accion = "AccionTest";
                actuador.dispositivo_id = dispositivoID;
                actuador.Regla.Add(regla);
                db.Actuador.Add(actuador);
                db.SaveChanges();
                
   
                var queryRegla = from r in db.Regla where r.condicion == "NuevaCondicion" select r;
                regla = queryRegla.First();
                int idReglaModificada = regla.id;
                regla.condicion = "CondicionModificada";
                db.SaveChanges();

                var queryReglaModificada = from rm in db.Regla where rm.id == idReglaModificada select rm;
                var reglaModificada = queryReglaModificada.First();

                Assert.AreEqual(reglaModificada.condicion, "CondicionModificada");           
            }
        }
    }
}
