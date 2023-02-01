using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ComputerInfo;
using DAL;

namespace ServerLibrary
{
    public class DataSender : IDataSender
    {
        public IDataSource dataSource;
        public ICache cache;

        public DataSender(IDataSource dataSource, ICache cache)
        {
            this.dataSource = dataSource;
            this.cache = cache;
        }

        public List<MRSInfo> GetAllMRSInfo(int computerId)
        {
            return dataSource.GetAllMRSInfo(computerId);
        }

        public List<RSInfo> GetAllRSInfoByType(int computerId, RSInfoType type)
        {
            return dataSource.GetAllRSInfoByType(computerId, type);
        }

        public List<RSInfo> GetAllRSInfo(int computerId)
        { 
            return dataSource.GetAllRSInfo(computerId);
        }

        public MRSInfo GetLatestMRSInfo(int computerId)
        {
            if (cache.GetSize() > 0)
            {
                return cache.GetLatest(computerId).info;
            }
            return new MRSInfo();
        }

        public int GetCacheSize()
        {
            return cache.GetSize();
        }

        public bool CacheContaints(int computerId)
        {
            return cache.Contains(computerId);
        }
    }
}
