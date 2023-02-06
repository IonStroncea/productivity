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

        public List<RSInfo> GetAllRSInfoByType100(int computerId, RSInfoType type)
        {
            List<RSInfo> list = GetAllRSInfoByType(computerId, type);

            if (list.Count <= 100)
            {
                return list;
            }

            int step = list.Count / 100;

            List<RSInfo> result = new List<RSInfo>();

            for (int i = 0; i < 100; i++)
            {
                int usage = 0;

                for (int j = 0; j < step; j++)
                {
                    usage += list[i * step + j].Usage;
                }
                usage = usage / step;

                result.Add(new RSInfo(type, usage, list[i * step].Date));
            }

            return result;
        }

        public List<RSInfo> GetAllRSInfoByTypeAndDate100(RSInfoType type, int computerId, int userId, string startDate, string endtDate)
        {
            return GetAllRSInfoByTypeAndDate100(type, computerId, userId, DateTime.ParseExact(startDate, "yyyy-MM-dd HH:mm", null), DateTime.ParseExact(endtDate, "yyyy-MM-dd HH:mm", null));
        }

        public List<RSInfo> GetAllRSInfoByTypeAndDate100(RSInfoType type, int computerId, int userId, DateTime startDate, DateTime endtDate)
        {

            List<RSInfo> list = GetAllRSInfoByTypeAndDate(type, computerId,startDate, endtDate);

            if (list.Count <= 100)
            {
                return list;
            }

            int step = list.Count / 100;

            List<RSInfo> result = new List<RSInfo>();

            for (int i = 0; i < 100; i++)
            {
                int usage = 0;

                for (int j = 0; j < step; j++)
                {
                    usage += list[i * step + j].Usage;
                }
                usage = usage / step;

                result.Add(new RSInfo(type, usage, list[i * step].Date));
            }

            return result;
        }

        public List<RSInfo> GetAllRSInfoByTypeAndDate(RSInfoType type, int computerId, DateTime startDate, DateTime endtDate)
        {
            return dataSource.GetAllRSInfoByTypeAndDate(type, computerId, startDate, endtDate);
        }
    }
}
