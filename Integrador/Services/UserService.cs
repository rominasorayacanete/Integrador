using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpPrevio.Models;
using System.Text.RegularExpressions;


namespace TpPrevio.Services
{
    public class UserService
    {
        private database db = new database();

        public User LoginUser(User user)
        {
            TaskExceptionList exceptions = new TaskExceptionList();     // Creamos una lista de exceptions las retornamos ante algun problema
            var result = db.User.SingleOrDefault(u => u.username == user.username && u.password == user.password); // Buscamos al usuario

            if (result != null) // Si existe usuario
            {
                return user;
            }
            exceptions.TaskExceptions.Add(new Exception("El usuario no existe."));
            throw exceptions;
        }

        public void CreateUser(User user)
        {
            TaskExceptionList exceptions = new TaskExceptionList();  // Creamos una lista de exceptions las retornamos ante algun problema            
            var password = user.password;
            
            // Validacion de username
            var result = db.User.SingleOrDefault(u => u.username == user.username);

            if (result != null)
            {
                exceptions.TaskExceptions.Add(new Exception("Usuario existente."));
            }

            // Validamos la contraseña 
            exceptions = this.validatePassword(exceptions, password);

            if (exceptions.TaskExceptions.Count > 0)
            {
                throw exceptions;
            }

            // Persistimos en db

            db.User.Add(user);
            db.SaveChanges();
            return;
        }

        private TaskExceptionList validatePassword (TaskExceptionList exceptions, string password)
        {
            // Validacion de string
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimumAndMaxChars = new Regex(@".{6,10}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");


            // Validamos todos los casos posibles de passwords

            if (hasSymbols.IsMatch(password))
            {
                exceptions.TaskExceptions.Add(new Exception("La contraseña no puede contener simbolos."));
            }

            if (!hasNumber.IsMatch(password))
            {
                exceptions.TaskExceptions.Add(new Exception("La contraseña debe tener al menos un numero."));
            }

            if (!hasUpperChar.IsMatch(password))
            {
                exceptions.TaskExceptions.Add(new Exception("La contraseña debe tener una letra mayuscula."));
            }
            if (!hasMinimumAndMaxChars.IsMatch(password))
            {
                exceptions.TaskExceptions.Add(new Exception("La contraseña debe tener al menos 6 caracteres y 10 como maximo."));
            }

            // retornamos exceptions
            return exceptions;
        }

        public User SaveCountry(string username, string country)
        {
            User result = db.User.SingleOrDefault(u => u.username == username);
            if (result != null)
            {
                result.country = country;
                db.SaveChanges();
            }
            return result;
        }

        public void UpdatePassword(string username, string password)
        {
            TaskExceptionList exceptions = new TaskExceptionList();     // Creamos una lista de exceptions las retornamos ante algun problema
            exceptions = this.validatePassword(exceptions, password);

            if (exceptions.TaskExceptions.Count > 0)
            {
                throw exceptions;
            }

            var result = db.User.SingleOrDefault(u => u.username == username);
            if (result != null)
            {
                result.password = password;
                db.SaveChanges();
            }
            return;
        }

    }
}