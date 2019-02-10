using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrador.Services;
using Integrador.Models;
using System.Web.Optimization;
using System.Web.Routing;

namespace Integrador
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected static System.Timers.Timer timer = new System.Timers.Timer(5000); // This will raise the event every one minute.
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }

        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           // SimplexService simplexService = new SimplexService();
           // Cliente cliente = simplexService.MockCliente();
           // simplexService.executeSimplex(cliente);
        }
    }
}
