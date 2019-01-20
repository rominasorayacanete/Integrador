using System.Linq;
using Integrador.Models;
using Integrador.DAL;

namespace Integrador.Services
{
    public class ClienteService
    {
        private Context db = new Context();

        public Cliente findClientByUserId(int userId)
        {
            return db.Clientes
                .Where(c => c.Usuario.Id == userId)
                .FirstOrDefault();
        }

        public void createNewCliente(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }

        public void updateGeoCliente(Cliente cliente, double latitud, double longitud)
        {
            var cli = db.Clientes.SingleOrDefault(c => c.Id== cliente.Id);
            if (cli != null)
            {
                cli.Latitud = latitud;
                cli.Longitud = longitud;
                db.SaveChanges();
            }
        }
    }
}