using Integrador.DAL;
using Integrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integrador.Services
{
    public class AdminService
    {
        private Context db = new Context();

        public Administrador FindById(int adminId)
        {
            return db.Administradores
            .Where(a => a.Id == adminId)
            .FirstOrDefault();
        }
    }
}