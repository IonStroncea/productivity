using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Common;
using ComputerInfo;

namespace ServerLibrary
{
    public class Cache : ICache
    {
        private BlockingCollection<CacheInfo> cq = new BlockingCollection<CacheInfo>();
        private Thread clearValues;
        private bool clearValuesWork = true;
        private TimeSpan liveTime = TimeSpan.FromSeconds(3);

        public Cache()
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

        public ReturnStatus AddCacheInfo(CacheInfo info)
        {
            try
            {
                lock (cq)
                {
                    List<CacheInfo> cacheInfos = cq.ToList();

                    if (cacheInfos.Any(x => x.comuterId == info.comuterId))
                    {
                        cq.Dispose();
                        cq = new BlockingCollection<CacheInfo>();
                        CacheInfo toDelete = cacheInfos.First(x => x.comuterId == info.comuterId);

                        cacheInfos.Remove(toDelete);
                        cacheInfos.Add(info);

                        cacheInfos.ForEach(x => cq.Add(x));
                    }
                    else
                    {
                        cq.Add(info);
                    }
                }
                return ReturnStatus.Success;
            }
            catch(Exception ex) 
            {
                return ReturnStatus.Error;
            }
        }

        ~Cache()
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
                List<CacheInfo> cacheInfos = cq.ToList();

                cq.Dispose();
                cq = new BlockingCollection<CacheInfo>();

                foreach (var item in cacheInfos)
                {
                    if (item.birthTime.Add(liveTime).CompareTo(DateTime.UtcNow) > 0)
                    {
                        Console.WriteLine("Saved info");
                        cq.Add(item);
                    }
                    else 
                    {
                        Console.WriteLine($"Deleted info {item.birthTime}  {item.birthTime.Add(liveTime)}  {item.birthTime.Add(liveTime).CompareTo(DateTime.UtcNow)}");
                    }
                }
            }
        }

        public CacheInfo GetLatest(int comuterId)
        {
            lock (cq)
            {
                CacheInfo info = cq.First(x => x.comuterId == comuterId);

                MRSInfo mrs = info.info;

                return info;
            }
        }

        public bool Contains(int coputerId)
        {
            lock (cq)
            {
                bool contains = cq.Where(x => x.comuterId == coputerId).Count() > 0;
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
