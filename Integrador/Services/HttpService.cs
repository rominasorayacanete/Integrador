using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using TpPrevio.Models;
using System.Net;
using Newtonsoft.Json;

namespace Integrador.Services
{
    public class HttpService
    {
        public List<Country> GetCountries ()
        {
            string sUrlRequest = "https://api.mercadolibre.com/countries";
            var json = new WebClient().DownloadString(sUrlRequest);
            var countries = JsonConvert.DeserializeObject<List<Country>>(json);
            return countries;
        }

    }
}