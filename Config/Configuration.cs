using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaLib
{
    public class Configuration
    {
        public string PostgresConnectionString { get; set; }

        private static readonly Lazy<Configuration> lazyInstance = new Lazy<Configuration>(() => new Configuration());
        private readonly ILogger<Configuration> _logger;

        private Configuration(ILogger<Configuration> logger){
            _logger = logger;
        }

        public Configuration()
        {
            try
            {
                string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;

                DotNetEnv.Env.Load(rootDirectory);
                PostgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONN_STRING");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public static Configuration Instance => lazyInstance.Value;
    }

}