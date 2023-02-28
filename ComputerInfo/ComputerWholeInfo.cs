using Computerinfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInfo
{
    [DataContract]
    public class ComputerWholeInfo
    {
        public GetComputerInfo info { get; set; }

        public ComputerWholeInfo()
        {
            info = new GetComputerInfo();
        }
    }
}
