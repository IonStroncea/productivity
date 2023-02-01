using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDataSource
    {

        List<MRSInfo> GetAllMRSInfo(int comuterId);

        List<RSInfo> GetAllRSInfoByType(int comuterId, RSInfoType type);

        List<RSInfo> GetAllRSInfo(int comuterId);
    }
}
