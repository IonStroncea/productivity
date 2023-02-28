using Computerinfo;
using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class ComputerInfoMessage
    {
        [DataMember(Order = 1)]
        public GetComputerInfo computerInfo;

        [DataMember(Order = 2)]
        public int computerId;
    }
}
