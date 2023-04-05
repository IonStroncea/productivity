using DAL;

namespace WebSite.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private string connectionString = "";

        public ConnectionStringProvider(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("ProductivityApps:BD");
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
