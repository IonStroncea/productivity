using Common;
using ComputerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServerLibrary
{
    public interface IDataReciever
    {
       public  ReturnStatus RecieveLatest(MRSInfo info, int computerId);

        public ReturnStatus Save(MRSInfo info, int computerId);

        public ReturnStatus Save(RSInfo info, int computerId);

        public ReturnStatus RecieveLatestUssageInfo(List<ProcessUssageInfo> info, int computerId);
    }
}
