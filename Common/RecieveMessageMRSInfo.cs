using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ComputerInfo;

namespace Common
{
    [DataContract]
    public class RecieveMessageMRSInfo
    {
        [DataMember(Order = 1)]
        public MRSInfo info;

        [DataMember(Order = 2)]
        public int computerId;
    }
}
