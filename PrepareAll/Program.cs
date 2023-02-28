using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Computerinfo;

namespace PrepareAll
{
    public class Program
    {
        public static void Main()
        {
            IGetComputerInfo info = new GetComputerInfo();
            info.RenewData();

            Console.WriteLine(info.GetRAMMB());
            foreach (double freq in info.GetCPUFreqMHZ())
            {
                Console.WriteLine($"CPU freq is " + freq);
            }

            Console.WriteLine(info.GetRAMGB() + " GB");
            foreach (double freq in info.GetCPUFreqGHZ())
            {
                Console.WriteLine($"CPU freq is " + freq);
            }

            foreach (string name in info.GetCPUName())
            {
                Console.WriteLine($"CPU Name is " + name);
            }

            foreach (string name in info.GetGPUName())
            {
                Console.WriteLine($"GPU Name is " + name);
            }
        }
    }
}
