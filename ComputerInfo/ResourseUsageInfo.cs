using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management;

namespace ComputerInfo
{
    public class ResourseUsageInfo
    {
        private PerformanceCounter CPUCounter = null;
        private PerformanceCounter MemFree = null;
        double totalMem = 0.0d;
        List<PerformanceCounter> GPUCounters = default;

        public ResourseUsageInfo()
        {
            CPUCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            MemFree = new PerformanceCounter("Memory", "Available KBytes");
            GPUCounters = GetAllGPUCounters();

            CPUCounter.NextValue();
            MemFree.NextValue();
            GetGPUUsage(GPUCounters);
            Thread.Sleep(10);

            CPUCounter.NextValue();
            MemFree.NextValue();
            GetGPUUsage(GPUCounters);
            Thread.Sleep(10);

            CPUCounter.NextValue();
            MemFree.NextValue();
            GetGPUUsage(GPUCounters);
            Thread.Sleep(10);

            ObjectQuery wmi_obj = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher _findObj = new ManagementObjectSearcher(wmi_obj);
            ManagementObjectCollection _ramInfo = _findObj.Get();

            foreach (ManagementObject _ram in _ramInfo)
            {
                totalMem = Convert.ToDouble(_ram["TotalVisibleMemorySize"]);
            }


        }
        private List<PerformanceCounter> GetAllGPUCounters()
        {
            var category = new PerformanceCounterCategory("GPU Engine");
            var names = category.GetInstanceNames();
            var gpuCounters = names
                            .Where(counterName => counterName.EndsWith("engtype_3D"))
                            .SelectMany(counterName => category.GetCounters(counterName))
                            .Where(counter => counter.CounterName.Equals("Utilization Percentage"))
                            .ToList();
            return gpuCounters;
        }

        private float GetGPUUsage(List<PerformanceCounter> gpuCounters)
        {
            var result = 0.0f;
            foreach (PerformanceCounter counter in gpuCounters)
            {
                try
                {
                    if (PerformanceCounterCategory.CounterExists(counter.CounterName, counter.CategoryName))
                    {
                        result += counter.NextValue();
                    }
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            return result;
        }

        public RSInfo GetCPUUsage()
        {
            float fValue = CPUCounter.NextValue();

            int value = (int)(fValue);

            RSInfo result = new RSInfo();
            result.Type = RSInfoType.CPU;
            result.Usage = value;

            return result;
        }

        public RSInfo GetGPUUsage()
        {
            float value = GetGPUUsage(GPUCounters);

            RSInfo result = new RSInfo();
            result.Type = RSInfoType.GPU;
            result.Usage = (int)value;

            return result;
        }

        public RSInfo GetRAMUsage()
        {
            float value = 100 - (MemFree.NextValue()) / (float)totalMem * 100;

            RSInfo result = new RSInfo();
            result.Type = RSInfoType.RAM;
            result.Usage = (int)value;

            return result;
        }

        public MRSInfo GetAllInfo()
        {
            MRSInfo result = new MRSInfo();

            result.SetInfo(GetCPUUsage());
            result.SetInfo(GetRAMUsage());
            result.SetInfo(GetGPUUsage());

            return result;
        }
    }
}
