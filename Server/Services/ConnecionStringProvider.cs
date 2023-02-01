using DAL;

namespace Server.Services
{
    public class ConnecionStringProvider : IConnectionStringProvider
    {
        private string connectionString = "Server=DESKTOP-3NTRSR2;Database=Licenta;User Id=sa;Password=sa;";
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
