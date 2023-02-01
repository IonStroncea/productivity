using Common;
using ComputerInfo;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataSaver : IDataSaver
    {
        public IConnectionStringProvider connectionStringProvider;

        public DataSaver(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public ReturnStatus SaveMRSInfo(MRSInfo info, int computerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    try
                    {
                        con.Open();

                        foreach (RSInfo rSInfo in info.GetInfos())
                        {
                            using (SqlCommand cmd = new SqlCommand("SaveRSInfo", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add("@usage", SqlDbType.Int).Value = rSInfo.Usage;
                                cmd.Parameters.Add("@info_type", SqlDbType.Char, 50).Value = rSInfo.Type.ToString();
                                cmd.Parameters.Add("@measure_time", SqlDbType.DateTime).Value = rSInfo.Date;
                                cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;

                                cmd.ExecuteNonQuery();
                            }
                        }
                    } 
                    catch(Exception e) { }
                    finally 
                    {
                        con.Close();
                    }
                }
            } 
            catch(Exception ex) 
            {
                return ReturnStatus.Error;  
            }
            
            return ReturnStatus.Success;
        }

        public ReturnStatus SaveRSInfo(RSInfo info, int computerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    try
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand("SaveRSInfo", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@usage", SqlDbType.Int).Value = info.Usage;
                            cmd.Parameters.Add("@info_type", SqlDbType.Char, 50).Value = info.Type.ToString();
                            cmd.Parameters.Add("@measure_time", SqlDbType.DateTime).Value = info.Date;
                            cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;

                            cmd.ExecuteNonQuery();
                        }
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
                return ReturnStatus.Error;
            }

            return ReturnStatus.Success;
        }
    }
}