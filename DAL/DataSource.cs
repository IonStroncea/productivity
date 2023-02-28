using Common;
using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computerinfo;

namespace DAL
{
    public class DataSource : IDataSource
    {
        public IConnectionStringProvider connectionStringProvider;

        public DataSource(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public List<MRSInfo> GetAllMRSInfo(int comuterId)
        {
            List<MRSInfo> result = new List<MRSInfo>();
            List<RSInfo> inside = new List<RSInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    con.Open();

        
                    using (SqlCommand cmd = new SqlCommand("GetRSInfo_by_computer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = comuterId;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {   
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];                           

                            foreach (DataRow row in dt.Rows)
                            {
                                RSInfo info = new RSInfo();

                                info.Usage = (int)row["usage"];
                                info.Date = Convert.ToDateTime(row["measure_time"]);
                                info.Type = (RSInfoType)Enum.Parse(typeof(RSInfoType), row["info_type"].ToString(), true);

                                inside.Add(info);
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

            for (int i = 0; i < inside.Count; i++)
            {
                List<RSInfo> sameDate = new List<RSInfo>();

                inside.Where(x => x.Date == inside[i].Date).ToList().ForEach(x => sameDate.Add(x));

                foreach (RSInfo info in sameDate)
                {
                    inside.Remove(info);
                }

                MRSInfo mRSInfo = new MRSInfo();

                sameDate.ForEach(x => mRSInfo.SetInfo(x));

                result.Add(mRSInfo);

            }

            return result;
        }

        public List<RSInfo> GetAllRSInfo(int comuterId)
        {
            List<RSInfo> inside = new List<RSInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    con.Open();


                    using (SqlCommand cmd = new SqlCommand("GetRSInfo_by_computer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = comuterId;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {
                                RSInfo info = new RSInfo();

                                info.Usage = (int)row["usage"];
                                info.Date = Convert.ToDateTime(row["measure_time"]);
                                info.Type = (RSInfoType)Enum.Parse(typeof(RSInfoType), row["info_type"].ToString(), true);

                                inside.Add(info);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return inside;
            }

            return inside;
        }

        public List<RSInfo> GetAllRSInfoByType(int comuterId, RSInfoType type)
        {
            List<RSInfo> inside = new List<RSInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    con.Open();


                    using (SqlCommand cmd = new SqlCommand("GetRSInfo_by_computer_and_type", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = comuterId;
                        cmd.Parameters.Add("@info_type", SqlDbType.Char, 50).Value = type.ToString();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {
                                RSInfo info = new RSInfo();

                                info.Usage = (int)row["usage"];
                                info.Date = Convert.ToDateTime(row["measure_time"]);
                                info.Type = (RSInfoType)Enum.Parse(typeof(RSInfoType), row["info_type"].ToString(), true);

                                inside.Add(info);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return inside;
            }

            return inside;
        }

        public List<RSInfo> GetAllRSInfoByTypeAndDate(RSInfoType type, int computerId, DateTime startDate, DateTime endtDate)
        {
            List<RSInfo> inside = new List<RSInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionStringProvider.GetConnectionString()))
                {
                    con.Open();


                    using (SqlCommand cmd = new SqlCommand("GetRSInfo_by_computer_type_daterange", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computerId;
                        cmd.Parameters.Add("@info_type", SqlDbType.Char, 50).Value = type.ToString();
                        cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
                        cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endtDate;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {
                                RSInfo info = new RSInfo();

                                info.Usage = (int)row["usage"];
                                info.Date = Convert.ToDateTime(row["measure_time"]);
                                info.Type = (RSInfoType)Enum.Parse(typeof(RSInfoType), row["info_type"].ToString(), true);

                                inside.Add(info);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return inside;
            }

            return inside;
        }

        public List<GetComputerInfo> GetWholeComputersInfo(int userId)
        {
            List<GetComputerInfo> computers = new List<GetComputerInfo>();

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
                                GetComputerInfo computerWholeInfo = new GetComputerInfo();
                                computerWholeInfo.computerId = Convert.ToInt32(row["id"]);
                                computerWholeInfo.name = Convert.ToString(row["computerName"]);
                                computerWholeInfo.userId = userId;
                                computerWholeInfo.createData();

                                computers.Add(computerWholeInfo);
                            }
                        }                        
                    }

                    foreach (GetComputerInfo computer in computers)
                    {
                        SqlCommand cmd = new SqlCommand("GetCPUByComputerId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computer.computerId;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {
                                computer.CPUName.Add(Convert.ToString(row["CPUName"]));
                                computer.CPUFreqMHZ.Add(Convert.ToDouble(row["CPUFreq"]));
                            }
                        }

                        cmd = new SqlCommand("GetGPUByComputerId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computer.computerId;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {
                                computer.GPUName.Add(Convert.ToString(row["GPUName"]));
                            }
                        }

                        cmd = new SqlCommand("GetRamByComputerId", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@computerId", SqlDbType.Int).Value = computer.computerId;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds, "result_name");

                            DataTable dt = ds.Tables["result_name"];

                            foreach (DataRow row in dt.Rows)
                            {
                                computer.RAMMb = Convert.ToDouble(row["valueMB"]);
                            }
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return computers;
            }

            return computers;
        }
    }
}
