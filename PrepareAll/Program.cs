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

            Console.WriteLine(info.GetRAMMB());
            Console.WriteLine(info.GetCPUFreqMHZ());

            Console.WriteLine(info.GetRAMGB() + " GB");
            Console.WriteLine(info.GetCPUFreqGHZ() + " GHZ");

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
