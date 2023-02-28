using Common;
using Common.GRPCServices;
using ComputerInfo;
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

        public RecieveMessageResult RecieveLatestUssageInfo(UssageInfoMessage info)
        {
            Console.WriteLine($"Recieved procces ussage info form {info.computerId} with {info.infos.Count} values");

            return new RecieveMessageResult(dataReciever.RecieveLatestUssageInfo(info.infos, info.computerId)); 
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

        public RecieveMessageResult UpdateComputerInfo(ComputerInfoMessage info)
        {
            Console.WriteLine($"Update computer info from computer: {info.computerId}");

            return new RecieveMessageResult(dataReciever.RecieveComputerInfo(info.computerInfo, info.computerId));
        }
    }
}
