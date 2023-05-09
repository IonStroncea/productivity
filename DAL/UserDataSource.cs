using ComputerInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDataSource : IUserDataSource
    {
        public IConnectionStringProvider connectionStringProvider;

        public UserDataSource(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public int CreateComputer(int userId, string compName)
        {
            try
            {

                int compId = -1;

                using (SqlConnection conn = new SqlConnection(connectionStringProvider.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand("Create_Comp", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@compName", SqlDbType.Char, 100).Value = compName;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                    cmd.Parameters.Add("@compId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        compId = Convert.ToInt32(cmd.Parameters["@compId"].Value);
                    }
                    catch (Exception e)
                    { }
                    finally
                    {
                        conn.Close();
                    }
                }

                return compId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public Dictionary<int, string> GetAllComputers(int userId)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    con.Open();


                    using (SqlCommand cmd = new SqlCommand("GetAllComputersByUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {
                                
                                int id = Convert.ToInt32(row["id"]);
                                string computerName = Convert.ToString(row["computerName"]);
                                
                                result.Add(id, computerName);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return result;
            }

            return result;
        }

        public Dictionary<string, string> GetUserDTO(int userId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    con.Open();


                    using (SqlCommand cmd = new SqlCommand("GetUserDTO", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {

                                string userName = Convert.ToString(row["userName"]);
                                string userNickName = Convert.ToString(row["userNickName"]);

                                result.Add("UserName", userName);
                                result.Add("Name", userNickName);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return result;
            }

            return result;
        }
    }
}

