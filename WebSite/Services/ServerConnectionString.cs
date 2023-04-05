namespace WebSite.Services
{
    public class ServerConnectionString
    {
        private string connectionString = "";

        public ServerConnectionString(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("ProductivityApps:Server");
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
