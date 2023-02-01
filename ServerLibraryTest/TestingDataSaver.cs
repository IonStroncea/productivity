using Common;
using ComputerInfo;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibraryTest
{
    public class TestingDataSaver : IDataSaver
    {
        public ReturnStatus SaveMRSInfo(MRSInfo info, int computerId)
        {
            return ReturnStatus.Success;
        }

        public ReturnStatus SaveRSInfo(RSInfo info, int computerId)
        {
            return ReturnStatus.Success;
        }
    }
}
