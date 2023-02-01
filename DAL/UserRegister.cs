using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRegister : IRegister
    {
        private IConnectionStringProvider connectionStringProvider;

        public UserRegister(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public int Register(string userName, string userNickName, string passKey)
        {
            try
            {

                int userId = -1;

                using (SqlConnection conn = new SqlConnection(connectionStringProvider.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand("Register", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userName", SqlDbType.Char, 100).Value = userName;
                    cmd.Parameters.Add("@userNickName", SqlDbType.Char, 100).Value = userName;
                    cmd.Parameters.Add("@passKey", SqlDbType.Char, 100).Value = passKey;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        userId = Convert.ToInt32(cmd.Parameters["@userId"].Value);
                    }
                    catch (Exception e)
                    { }
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
