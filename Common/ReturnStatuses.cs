using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Common
{
    [DataContract(Name = "ReturnStatus")]
    public enum ReturnStatus
    {
        [EnumMember]
        Success,
        [EnumMember]
        Fail,
        [EnumMember]
        TimeOut,
        [EnumMember]
        Error
    }
}