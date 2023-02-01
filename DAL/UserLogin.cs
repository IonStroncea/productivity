using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class UserLogin : ILogin
    {
        public IConnectionStringProvider connectionStringProvider;

        public UserLogin(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public int Login(string userName, string passKey)
        {
            try
            {

                int userId = -1;

                using (SqlConnection conn = new SqlConnection(connectionStringProvider.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand("LogIn", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userName", SqlDbType.Char, 100).Value = userName;
                    cmd.Parameters.Add("@passKey", SqlDbType.Char, 100).Value = passKey;
                    cmd.Parameters.Add("@userId",SqlDbType.Int).Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        userId = Convert.ToInt32(cmd.Parameters["@userId"].Value);
                    }
                    catch (Exception ex) 
                    { 
                    }
                    finally 
                    { 
                        conn.Close(); 
                    }

                }

                return userId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
