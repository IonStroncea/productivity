using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComputerInfo;

namespace PrepareAll
{
    public class Program
    {
        public static void Main()
        {
            ResourseUsageInfo resourseUsage = new ResourseUsageInfo();

            for (int i = 0; i < 50; i++)
            {
                RSInfo info = resourseUsage.GetCPUUsage();
                Console.WriteLine($"{info.Usage} % type {info.Type}  {info.Date.ToLocalTime()}");

                info = resourseUsage.GetRAMUsage();
                Console.WriteLine($"{info.Usage} % type {info.Type}  {info.Date.ToLocalTime()}");

                info = resourseUsage.GetGPUUsage();
                Console.WriteLine($"{info.Usage} % type {info.Type}  {info.Date.ToLocalTime()}");

                Thread.Sleep(1000);
            }
            
        }
    }
}
