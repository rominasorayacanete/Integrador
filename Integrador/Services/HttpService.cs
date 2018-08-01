using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using TpPrevio.Models;
using System.Net;
using Newtonsoft.Json;

namespace Simplex.Services
{
    public class HttpService
    {
        public List<Dispositivos> GetDispositivos ()
        {
            string sUrlRequest = "FALTA QUE MANDEN LA URL";
            var json = new WebClient().DownloadString(sUrlRequest);
            var dispositivos = JsonConvert.DeserializeObject<List<Dispositivo>>(json);
            return dispositivos;
        }

    }
}