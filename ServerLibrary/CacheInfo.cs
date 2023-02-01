using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerInfo;

namespace ServerLibrary
{
    public class CacheInfo
    {
        public DateTime birthTime;

        public int comuterId;

        public MRSInfo info;

        public CacheInfo()
        {
            DateTime Date1 = DateTime.UtcNow;
            birthTime = new DateTime(Date1.Year, Date1.Month, Date1.Day, Date1.Hour, Date1.Minute, Date1.Second, Date1.Kind);
        }

        public CacheInfo(int comuterId, MRSInfo info)
        {
            DateTime Date1 = DateTime.UtcNow;
            birthTime = new DateTime(Date1.Year, Date1.Month, Date1.Day, Date1.Hour, Date1.Minute, Date1.Second, Date1.Kind);

            this.comuterId = comuterId;
            this.info = info;
        }
    }
}
