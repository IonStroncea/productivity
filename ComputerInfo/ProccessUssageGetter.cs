using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerInfo
{
    public class ProccessUssageGetter
    {
        List<ProcessUssage> processes = new List<ProcessUssage>();
        Thread t1;
        bool run = true;

        public ProccessUssageGetter()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process process in processCollection) 
            {
                try
                {
                    ProcessUssage processUssage = new ProcessUssage();

                    processUssage.id = process.Id;
                    processUssage.name = process.ProcessName;
                    processUssage.lastMeasuredTime = DateTime.UtcNow;
                    processUssage.proccesTime = process.TotalProcessorTime;
                    processUssage.ramUssage = process.WorkingSet64 / (1024 * 1024);

                    processes.Add(processUssage);
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            t1 = new Thread(() => { Cicle(); });
            t1.Start();
        }

        private void Cicle()
        {
            while (run)
            {
                Thread.Sleep(100);
                Process[] processCollection = Process.GetProcesses();

                foreach (Process process in processCollection)
                {
                    if (processes.Any(x => x.id == process.Id))
                    {
                        try
                        {
                            int index = processes.FindIndex(x => x.id == process.Id);

                            DateTime thisTime = DateTime.UtcNow;
                            var endCpuUsage = process.TotalProcessorTime;

                            var cpuUsedMs = (endCpuUsage - processes[index].proccesTime).TotalMilliseconds;
                            var totalMsPassed = (thisTime - processes[index].lastMeasuredTime).TotalMilliseconds;

                            processes[index].ussage = (cpuUsedMs / (Environment.ProcessorCount * totalMsPassed) * 100);
                            processes[index].proccesTime = endCpuUsage;
                            processes[index].lastMeasuredTime = thisTime;
                            processes[index].ramUssage = process.WorkingSet64 / (1024 * 1024);
                        }
                        catch (Exception e)
                        {
                            int index = processes.FindIndex(x => x.id == process.Id);
                            processes.RemoveAt(index);
                        }
                    }
                    else
                    {
                        try
                        {
                            ProcessUssage processUssage = new ProcessUssage();

                            processUssage.id = process.Id;
                            processUssage.name = process.ProcessName;
                            processUssage.lastMeasuredTime = DateTime.UtcNow;
                            processUssage.proccesTime = process.TotalProcessorTime;
                            processUssage.ramUssage = process.WorkingSet64 / (1024 * 1024);

                            processes.Add(processUssage);
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }

                for (int i = 0; i < processes.Count; i++)
                {
                    if (!processCollection.Any(x => x.Id == processes[i].id))
                    {
                        processes.RemoveAt(i);
                    }
                }
            }
        }

        public void Stop()
        {
            run = false;
            t1.Join();
        }

        public void Pause()
        {
            run = false;
        }

        public void Restart()
        {
            run = true;
        }

        public List<ProcessUssage> GetProcesses() 
        {
            return new List<ProcessUssage>(processes);
        }

        public List<ProcessUssageInfo> GetProcessesInfo()
        {
            List <ProcessUssageInfo> info = new List<ProcessUssageInfo>();

            foreach (ProcessUssage ussage in processes)
            {
                info.Add(new ProcessUssageInfo(ussage));
            }

            return info;
        }
    }
}
