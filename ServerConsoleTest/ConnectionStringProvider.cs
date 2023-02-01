using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsoleTest
{
    internal class ConnectionStringProvider : IConnectionStringProvider
    {
        private string connectionString = "Server=DESKTOP-3NTRSR2;Database=Licenta;User Id=sa;Password=sa;";
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
