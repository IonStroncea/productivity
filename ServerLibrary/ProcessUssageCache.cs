using Common;
using ComputerInfo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
{
    public class ProcessUssageCache : IProccesUssageCache
    {
        private BlockingCollection<Tuple <int,List<ProcessUssageInfo>, DateTime>> cq = new BlockingCollection<Tuple<int, List<ProcessUssageInfo>, DateTime>>();
        private Thread clearValues;
        private bool clearValuesWork = true;
        private TimeSpan liveTime = TimeSpan.FromSeconds(3);

        public ProcessUssageCache()
        {
            clearValues = new Thread(() => {
                while (clearValuesWork)
                {
                    ClearValues();
                    Thread.Sleep(500);
                }
            });

            clearValues.Start();
        }

        public ReturnStatus AddProccesUssage(List<ProcessUssageInfo> info, int computerId)
        {
            try
            {
                lock (cq)
                {
                    List<Tuple<int, List<ProcessUssageInfo>, DateTime>> cacheInfos = cq.ToList();

                    if (cacheInfos.Any(x => x.Item1 == computerId))
                    {
                        cq.Dispose();
                        cq = new BlockingCollection<Tuple<int, List<ProcessUssageInfo>, DateTime>>();
                        Tuple<int, List<ProcessUssageInfo>, DateTime> toDelete = cacheInfos.First(x => x.Item1 == computerId);

                        cacheInfos.Remove(toDelete);

                        Tuple<int, List<ProcessUssageInfo>, DateTime> toAdd = new Tuple<int, List<ProcessUssageInfo>, DateTime>(computerId, info, DateTime.UtcNow);
                        cacheInfos.Add(toAdd);
                        cacheInfos.ForEach(x => cq.Add(x));
                    }
                    else
                    {
                        cq.Add(new Tuple<int, List<ProcessUssageInfo>, DateTime>(computerId, info, DateTime.UtcNow));
                    }
                }
                return ReturnStatus.Success;
            }
            catch (Exception ex)
            {
                return ReturnStatus.Error;
            }
        }

        public List<ProcessUssageInfo> GetLatest(int comuterId)
        {
            lock (cq)
            {
                Tuple<int, List<ProcessUssageInfo>, DateTime> info = cq.First(x => x.Item1 == comuterId);

                return info.Item2;
            }
        }

        ~ProcessUssageCache()
        {
            clearValuesWork = false;

            if (clearValues != null && clearValues.IsAlive)
            {
                clearValues.Join();
            }
        }

        private void ClearValues()
        {
            lock (cq)
            {
                List<Tuple<int, List<ProcessUssageInfo>, DateTime>> processInfos = cq.ToList();

                cq.Dispose();
                cq = new BlockingCollection<Tuple<int, List<ProcessUssageInfo>, DateTime>>();

                foreach (var item in processInfos)
                {
                    if (item.Item3.Add(liveTime).CompareTo(DateTime.UtcNow) > 0)
                    {
                        cq.Add(item);
                    }
                }
            }
        }

        public bool Contains(int coputerId)
        {
            lock (cq)
            {
                bool contains = cq.Where(x => x.Item1 == coputerId).Count() > 0;
                return contains;
            }
        }

        public int GetSize()
        {
            lock (cq)
            {
                return cq.Count;
            }
        }
    }
}
