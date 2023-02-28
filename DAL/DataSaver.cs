using Common;
using Computerinfo;
using ComputerInfo;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataSaver : IDataSaver
    {
        private IConnectionStringProvider connectionStringProvider;

        public DataSaver(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public ReturnStatus SaveComputerInfo(GetComputerInfo computerInfo, int computerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("DeleteComputerInfo", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("AddRAM", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;
                        cmd.Parameters.Add("@valueMB", SqlDbType.Float).Value = computerInfo.GetRAMMB();

                        cmd.ExecuteNonQuery();

                        foreach (string gpuName in computerInfo.GetGPUName())
                        {
                            cmd = new SqlCommand("AddGPU", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;
                            cmd.Parameters.Add("@GPUName", SqlDbType.NVarChar, 1000).Value = gpuName;

                            cmd.ExecuteNonQuery();
                        }

                        for (int i = 0; i < computerInfo.GetCPUName().Count; i++)
                        {
                            cmd = new SqlCommand("AddCPU", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;
                            cmd.Parameters.Add("@CPUName", SqlDbType.NVarChar, 1000).Value = computerInfo.GetCPUName()[i];
                            cmd.Parameters.Add("@CPUFreq", SqlDbType.Float).Value = computerInfo.GetCPUFreqMHZ()[i];

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