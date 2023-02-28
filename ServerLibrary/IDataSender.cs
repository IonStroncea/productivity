using Computerinfo;
using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
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

        public List<RSInfo> GetAllRSInfoByTypeAndDate100(RSInfoType type, int computerId, int userId, string startDate, string endtDate);

        public List<RSInfo> GetAllRSInfoByTypeAndDate100(RSInfoType type, int computerId, int userId, DateTime startDate, DateTime endtDate);

        public List<RSInfo> GetAllRSInfoByTypeAndDate(RSInfoType type, int computerId, DateTime startDate, DateTime endtDate);

        public List<ProcessUssageInfo> GetLatestUssageInfo(int computerId);

        public List<GetComputerInfo> GetWholeComputersInfo(int userId);
    }
}
