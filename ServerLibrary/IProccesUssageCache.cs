using Common;
using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
{
    public interface IProccesUssageCache
    {
        ReturnStatus AddProccesUssage(List<ProcessUssageInfo> info, int computerId);

        List<ProcessUssageInfo> GetLatest(int comuterId);

        bool Contains(int coputerId);

        int GetSize();
    }
}
