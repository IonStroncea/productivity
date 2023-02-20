using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Computerinfo
{
    public class GetComputerInfo : IGetComputerInfo
    {
        private double CPUFreqMHZ;
        private double RAMMb;
        private List<string> CPUName;
        private List<string> GPUName;

        public GetComputerInfo()
        {
            RenewData();
        }

        public void RenewData()
        {
            ObjectQuery wmi_obj = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher _findObj = new ManagementObjectSearcher(wmi_obj);
            ManagementObjectCollection _ramInfo = _findObj.Get();

            foreach (ManagementObject _ram in _ramInfo)
            {
                RAMMb = Convert.ToDouble(_ram["TotalVisibleMemorySize"]) / (1024);
            }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            foreach (var item in searcher.Get())
            {
                CPUFreqMHZ = (uint)item["MaxClockSpeed"];
            }

            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            CPUName = new List<string>();

            foreach (ManagementObject mo in mos.Get())
            {
                CPUName.Add((String)mo["Name"]);
            }

            searcher = new ManagementObjectSearcher("select * from Win32_VideoController");
            GPUName = new List<string>();

            foreach (ManagementObject mo in searcher.Get())
            {
                GPUName.Add((String)mo["Name"]);
            }
        }

        public double GetCPUFreqGHZ()
        {
            return CPUFreqMHZ / 1000;
        }

        public double GetCPUFreqMHZ()
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
