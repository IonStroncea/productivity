using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDataSender
    {
        public List<MRSInfo> GetAllMRSInfo(int computerId);

        public List<RSInfo> GetAllRSInfoByType(int computerId, RSInfoType type);

        public List<RSInfo> GetAllRSInfo(int computerId);

        public MRSInfo GetLatestMRSInfo(int computerId);

        public int GetCacheSize();

        public bool CacheContaints(int computerId);

        public List<RSInfo> GetAllRSInfoByType100(int computerId, RSInfoType type);
    }
}
