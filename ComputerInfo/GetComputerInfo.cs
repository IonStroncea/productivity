using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Computerinfo
{
    [DataContract]
    public class GetComputerInfo : IGetComputerInfo
    {
        public string name { get; set; }

        public int userId { get; set; }

        public int computerId { get; set; }

        [DataMember(Order = 2)]
        public double RAMMb { get; set; }

        [DataMember(Order = 1)]
        public List<double> CPUFreqMHZ { get; set; }

        [DataMember(Order = 3)]
        public List<string> CPUName { get; set; }
        [DataMember(Order = 4)]
        public List<string> GPUName { get; set; }

        public GetComputerInfo()
        {
            
        }

        public void createData()
        {
            CPUFreqMHZ = new List<double>();
            CPUName = new List<string>();
            GPUName = new List<string>();
        }

        public void RenewData()
        {
            CPUFreqMHZ = new List<double>();
            CPUName = new List<string>();
            GPUName = new List<string>();

            ObjectQuery wmi_obj = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher _findObj = new ManagementObjectSearcher(wmi_obj);
            ManagementObjectCollection _ramInfo = _findObj.Get();

            foreach (ManagementObject _ram in _ramInfo)
            {
                RAMMb = Convert.ToDouble(_ram["TotalVisibleMemorySize"]) / (1024);
            }

            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            CPUFreqMHZ = new List<double>();
            CPUName = new List<string>();
            foreach (ManagementObject mo in mos.Get())
            {
                CPUName.Add((string)mo["Name"]);
                CPUFreqMHZ.Add((uint)mo["MaxClockSpeed"]);
                break;
            }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_VideoController");
            GPUName = new List<string>();

            foreach (ManagementObject mo in searcher.Get())
            {
                GPUName.Add((String)mo["Name"]);
            }
        }

        public List<double> GetCPUFreqGHZ()
        {
            List<double> result = new List<double>();

            CPUFreqMHZ.ForEach(x => result.Add(x / 1000));

            return result;
        }

        public List<double> GetCPUFreqMHZ()
        {
            return CPUFreqMHZ;
        }

        public double GetRAMGB()
        {
            return RAMMb / 1024;
        }

        public double GetRAMMB()
        {
            return RAMMb;
        }

        public List<string> GetCPUName()
        {
            return CPUName;
        }

        public List<string> GetGPUName()
        {
            return GPUName;
        }
    }
}
