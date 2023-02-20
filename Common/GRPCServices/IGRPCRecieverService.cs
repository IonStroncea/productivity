using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common.GRPCServices
{
    [ServiceContract]
    public interface IGRPCRecieverService
    {
        [OperationContract]
        public RecieveMessageResult RecieveLatest(RecieveMessageMRSInfo info);

        [OperationContract]
        public RecieveMessageResult SaveMRSInfo(RecieveMessageMRSInfo info);

        [OperationContract]
        public RecieveMessageResult SaveRSInfo(RecieveMessageRSInfo info);

        [OperationContract]
        public RecieveMessageResult RecieveLatestUssageInfo(UssageInfoMessage info);
    }
}
