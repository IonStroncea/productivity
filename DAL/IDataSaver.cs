using Common;
using Computerinfo;
using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDataSaver
    {
        ReturnStatus SaveMRSInfo(MRSInfo info, int computerId);

        ReturnStatus SaveRSInfo(RSInfo info, int computerId);

        ReturnStatus SaveComputerInfo(GetComputerInfo computerInfo, int computerId);
    }
}
