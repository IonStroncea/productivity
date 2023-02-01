using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class RecieveMessageResult
    {
        [DataMember]
        public ReturnStatus status;

        public RecieveMessageResult()
        { }

        public RecieveMessageResult(ReturnStatus status)
        {
            this.status = status;
        }
    }
}
