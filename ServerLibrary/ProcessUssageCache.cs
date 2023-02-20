using Common;
using ComputerInfo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
{
    public class ProcessUssageCache : IProccesUssageCache
    {
        private BlockingCollection<KeyValuePair<int,List<ProcessUssageInfo>>> cq = new BlockingCollection<KeyValuePair<int, List<ProcessUssageInfo>>>();

        public ReturnStatus AddProccesUssage(List<ProcessUssageInfo> info, int computerId)
        {
            try
            {
                lock (cq)
                {
                    List<KeyValuePair<int, List<ProcessUssageInfo>>> cacheInfos = cq.ToList();

                    if (cacheInfos.Any(x => x.Key == computerId))
                    {
                        cq.Dispose();
                        cq = new BlockingCollection<KeyValuePair<int, List<ProcessUssageInfo>>>();
                        KeyValuePair<int, List<ProcessUssageInfo>> toDelete = cacheInfos.First(x => x.Key == computerId);

                        cacheInfos.Remove(toDelete);

                        KeyValuePair<int, List<ProcessUssageInfo>> toAdd = new KeyValuePair<int, List<ProcessUssageInfo>>(computerId, info);
                        cacheInfos.Add(toAdd);
                        cacheInfos.ForEach(x => cq.Add(x));
                    }
                    else
                    {
                        cq.Add(new KeyValuePair<int, List<ProcessUssageInfo>>(computerId, info));
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
                KeyValuePair<int, List<ProcessUssageInfo>> info = cq.First(x => x.Key == comuterId);

                return info.Value;
            }
        }

        public bool Contains(int coputerId)
        {
            lock (cq)
            {
                bool contains = cq.Where(x => x.Key == coputerId).Count() > 0;
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
