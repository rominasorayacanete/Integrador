using System.Collections.Generic;
using Newtonsoft.Json;
using Integrador.DAL;
using Integrador.Models.Clases;

namespace Integrador.Services
{
    public class ZonaService
    {
        private Context db = new Context();

        public void CargarJson(string json)
        {
            List<ZonaGeografica> zonas = JsonConvert.DeserializeObject<List<ZonaGeografica>>(json);
            zonas.ForEach(z => {
                ZonaGeografica zona = new ZonaGeografica()
                {
                    Id = z.Id,
                    Radio = z.Radio,
                    NombreZona = z.NombreZona,
                    Latitud = z.Latitud,
                    Longitud = z.Longitud
                };

                db.ZonaGeograficas.Add(zona);
                db.SaveChanges();

                foreach (Transformador t in z.Transformadores)
                {
                    t.ZonaGeografica = zona;
                    db.Transformadores.Add(t);
                    db.SaveChanges();
                }

            });

        }

    }
}