using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpPrevio.Models;
using System.Text.RegularExpressions;
using Serilog;

namespace TpPrevio.Services
{
    public class LogService
    {
        public void LogData (string information)
        {
            var log = new LoggerConfiguration()
                          .MinimumLevel.Debug()
                          .WriteTo.RollingFile(@"c:\log\logprevio.txt", retainedFileCountLimit: 7)
                          .CreateLogger();
            log.Information(information);
        }
    }
}