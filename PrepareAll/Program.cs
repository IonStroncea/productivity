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
            ProccessUssageGetter proccessUssage = new ProccessUssageGetter();

            Thread.Sleep(2000);

            for (int i = 0; i < 1000; i++)
            {
                List<ProcessUssage> processUssages = proccessUssage.GetProcesses();

                foreach (ProcessUssage p in processUssages)
                {
                    Console.WriteLine($"{p.id} --- {p.ussage.ToString("0.00")}% --- {p.name} --- {p.ramUssage.ToString("0.00")}MB");
                }

                Thread.Sleep(2000);
            }

            proccessUssage.Stop();

            Thread.Sleep(2000);
        }
    }
}
