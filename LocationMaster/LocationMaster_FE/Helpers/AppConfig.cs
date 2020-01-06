using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LocationMaster_FE.Helpers
{
    public static class AppConfig
    {
        public static string BaseUrl { get; } = "https://localhost:";
        public static string Port { get; } = "5001";
    }
}
