using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ComputerInfo
{
    [DataContract(Name = "RSInfoType")]
    public enum RSInfoType
    {
        [EnumMember]
        CPU,
        [EnumMember]
        RAM,
        [EnumMember]
        GPU
    }
}
