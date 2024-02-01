
using Npgsql;
using System.Diagnostics;

namespace NaLib
{
    internal class Repository
    {
        private NpgsqlConnection connection;
        private readonly ILogger<Repository> _logger;

        private Repository(ILogger<Repository> logger)
        {
            _logger = logger;
        }

        public Repository()
        {
            try
            {
                string connectionString = Configuration.Instance.PostgresConnectionString;

                connection = new NpgsqlConnection(connectionString);
            }
            catch (NpgsqlException ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public NpgsqlConnection Connection
        {
            set { connection = value; }
            get { return connection; }
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
