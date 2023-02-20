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
    public class UssageInfoMessage
    {
        [DataMember(Order = 1)]
        public int computerId;

        [DataMember(Order = 2)]
        public List<ProcessUssageInfo> infos;
    }
}
