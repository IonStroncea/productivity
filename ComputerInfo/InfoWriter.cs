using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ComputerInfo
{
    public class InfoWriter
    {
        public string directoryPath = default(string);
        private string RSInfoDocName = "RSInfoDoc";
        private string extention = ".txt";

        public InfoWriter(string directoryPath)
        {
            this.directoryPath = directoryPath;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public int WriteRSInfo(List<RSInfoSend> information)
        {
            int retry = 0;

            while (retry < 3)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(directoryPath + "\\" + RSInfoDocName + extention))
                    {
                        foreach (RSInfoSend info in information)
                        {
                            sw.WriteLine(info.TextSave());
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                    retry++;
                    Thread.Sleep(10);
                }
            }
            if (retry < 3)
                return 1;

            return 0;
        }

        public int WriteRSInfo(List<RSInfo> information)
        {
            int retry = 0;
            
            while (retry < 3)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(directoryPath + "\\" + RSInfoDocName + extention))
                    {
                        foreach (RSInfo info in information)
                        {
                            sw.WriteLine("0*" + info.TextSave());
                        }
                    }
                    break;
                }
                catch(Exception ex) 
                {
                    retry++;
                    Thread.Sleep(10);
                }
            }
            if (retry < 3)
                return 1;

            return 0;
        }

        public void DeleteData()
        {
            if (File.Exists(directoryPath + "\\" + RSInfoDocName + extention))
            {
                File.Delete(directoryPath + "\\" + RSInfoDocName + extention);
            }
        }

        public List<RSInfo> ReadUnsendRSInfo()
        {
            List<RSInfo> result = new List<RSInfo>();

            int retry = 0;

            while (retry < 20)
            {
                try
                {

                    using (StreamReader sr = File.OpenText(directoryPath + "\\" + RSInfoDocName + extention))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s[0] == '0')
                            {
                                result.Add(new RSInfo(s.Substring(2)));
                            }
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                    retry++;
                    Thread.Sleep(10);
                }
            }

            return result;
        }

        public int DeleteInfos(List<RSInfo> toDelete)
        {
            List<RSInfo> result = new List<RSInfo>();

            int retry = 0;

            while (retry < 3)
            {
                try
                {

                    using (StreamReader sr = File.OpenText(directoryPath + "\\" + RSInfoDocName + extention))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            result.Add(new RSInfo(s.Substring(2)));
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                    retry++;
                    Thread.Sleep(10);
                }
            }
            retry = 0;
            while (retry < 50)
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(directoryPath + "\\" + RSInfoDocName + extention))
                    {
                        foreach (RSInfo info in result.Where(x => !toDelete.Contains(x)))
                        {
                            sw.WriteLine("0*" + info.TextSave());
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                    retry++;
                    Thread.Sleep(10);
                }
            }

            if (retry < 50)
                return 1;

            return 0;
        }

        public List<RSInfoSend> ReadAllRSInfo() 
        {
            List<RSInfoSend> result = new List<RSInfoSend>();

            int retry = 0;

            while (retry < 20)
            {
                try
                {
                    using (StreamReader sr = File.OpenText(directoryPath + "\\" + RSInfoDocName + extention))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            result.Add(new RSInfoSend(s));
                        }
                    }
                    break;
                }
                catch (Exception ex)
                {
                    retry++;
                    Thread.Sleep(10);
                }
            }

            return result;
        }

    }
}
