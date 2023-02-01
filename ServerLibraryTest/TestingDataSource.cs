using Common;
using ComputerInfo;
using DAL;
using ServerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibraryTest
{
    public class TestingDataSource : IDataSource
    {
        public List<MRSInfo> GetAllMRSInfo(int computerId)
        {
            List<MRSInfo> result = new List<MRSInfo>();
            MRSInfo info = new MRSInfo();

            result.Add(info);

            return result;
        }

        public List<RSInfo> GetAllRSInfo(int computerId)
        {
            List<RSInfo> result = new List<RSInfo>();
            RSInfo info = new RSInfo();

            result.Add(info);

            return result;
        }

        public List<RSInfo> GetAllRSInfoByType(int computerId, RSInfoType type)
        {
            List<RSInfo> result = new List<RSInfo>();
            RSInfo info = new RSInfo();

            info.Type = type;

            result.Add(info);

            return result;
        }
    }
}
