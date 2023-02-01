using Common;
using Common.GRPCServices;
using ServerLibrary;

namespace Server.GRPCServices
{
    public class GRPCRecieverService : IGRPCRecieverService
    {
        private IDataReciever dataReciever;

        public GRPCRecieverService(IDataReciever dataReciever)
        {
            this.dataReciever = dataReciever;
        }
        public RecieveMessageResult RecieveLatest(RecieveMessageMRSInfo info)
        {
            Console.WriteLine($"RecieveLatest message form computer {info.computerId}");

            return new RecieveMessageResult(dataReciever.RecieveLatest(info.info, info.computerId));
        }

        public RecieveMessageResult SaveMRSInfo(RecieveMessageMRSInfo info)
        {
            Console.WriteLine($"SaveMRSInfo message form computer {info.computerId}");

            return new RecieveMessageResult(dataReciever.Save(info.info, info.computerId));
        }

        public RecieveMessageResult SaveRSInfo(RecieveMessageRSInfo info)
        {
            Console.WriteLine($"SaveRSInfo message form computer {info.computerId}");

            return new RecieveMessageResult(dataReciever.Save(info.info, info.computerId));
        }
    }
}
