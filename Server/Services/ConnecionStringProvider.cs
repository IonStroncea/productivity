using DAL;

namespace Server.Services
{
    public class ConnecionStringProvider : IConnectionStringProvider
    {
        private string connectionString = "";

        public ConnecionStringProvider(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("ProductivityApps:BD");
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
