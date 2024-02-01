using System;
using Microsoft.Extensions.Logging;

namespace NaLib
{
    public class Configuration
    {
        public string PostgresConnectionString { get; set; }

        private static readonly Lazy<Configuration> lazyInstance = new Lazy<Configuration>(() => new Configuration(null));
        private readonly ILogger<Configuration> _logger;

        private Configuration(ILogger<Configuration> logger)
        {
            _logger = logger;
            try
            {
                string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
                Console.WriteLine(rootDirectory);

                DotNetEnv.Env.Load(rootDirectory);
                PostgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONN_STRING");
            }
            catch (DotNetEnv.EnvVariableNotFoundException ex)
            {
               Console.WriteLine(".env file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Log the entire exception for other unexpected errors
                Console.WriteLine("Unexpected error: " + ex.ToString());
            }
        }

        private void LogError(string message)
        {
            if (_logger != null)
            {
                _logger.LogError(message);
            }
        }

        public static Configuration Instance => lazyInstance.Value;
    }
}
