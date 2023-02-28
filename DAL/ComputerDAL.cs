using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ComputerDAL : IComputerDAL
    {
        public IConnectionStringProvider connectionStringProvider;

        public ComputerDAL(IConnectionStringProvider connectionStringProvider) 
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public bool DeteleComputer(int computerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("DeleteComputerById", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) { }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
