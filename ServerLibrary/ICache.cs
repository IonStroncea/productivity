using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerInfo;

namespace ServerLibrary
{
    public interface ICache
    {
        ReturnStatus AddCacheInfo(CacheInfo info);

        CacheInfo GetLatest(int comuterId);

        bool Contains(int coputerId);

        int GetSize();
    }
}
