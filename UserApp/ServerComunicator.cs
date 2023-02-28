using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerInfo;
using Grpc.Net.Client;
using Common.GRPCServices;
using ProtoBuf.Grpc.Client;
using Common;
using Computerinfo;

namespace UserApp
{
    internal class ServerComunicator
    {
        GrpcChannel channel;
        IGRPCRecieverService client;
        public ServerComunicator()
        {
            channel = GrpcChannel.ForAddress("https://localhost:7155");
            client = channel.CreateGrpcService<IGRPCRecieverService>();
        }
        public List<RSInfo> SendInfo(List<RSInfo> toSend, int computerId)
        {
            List<RSInfo> result = new List<RSInfo>();

            foreach (RSInfo info in toSend)
            {
                try
                {
                    RecieveMessageRSInfo message = new RecieveMessageRSInfo();
                    message.info = info;
                    message.computerId = computerId;

                    ReturnStatus reply = ReturnStatus.Fail;

                    lock (client)
                    {
                        reply = client.SaveRSInfo(message).status;
                    }

                    if (reply == ReturnStatus.Success)
                    {
                        result.Add(info);
                    }
                }
                catch (Exception ex)
                {

                }
            }
         

            return result;
        }

        public ReturnStatus SendProccesUssageInfo(List<ProcessUssageInfo> infos, int computerId)
        {
            ReturnStatus reply = ReturnStatus.Fail;

            try
            {
                UssageInfoMessage message = new UssageInfoMessage();
                message.infos = infos;
                message.computerId = computerId;

                lock (client)
                {
                    reply = client.RecieveLatestUssageInfo(message).status;
                }
            }
            catch (Exception ex)
            {
                return ReturnStatus.Error;
            }

            return reply;
        }

        public ReturnStatus SentMRSInfoLatest(MRSInfo toSend, int computerId)
        {
            ReturnStatus reply = ReturnStatus.Fail;
            try
            {
                RecieveMessageMRSInfo message = new RecieveMessageMRSInfo();
                message.info = toSend;
                message.computerId = computerId;

                lock (client)
                {
                    reply = client.RecieveLatest(message).status;
                }
            }
            catch (Exception e)
            {
                return ReturnStatus.Error;
            }

            return reply;
        }

        public ReturnStatus RenewComputerInfo(GetComputerInfo info, int computerId)
        { 
            ReturnStatus reply =  ReturnStatus.Fail;
            try
            {
                ComputerInfoMessage message = new ComputerInfoMessage();
                message.computerInfo = info;
                message.computerId = computerId;

                lock (client)
                {
                    reply = client.UpdateComputerInfo(message).status;
                }
            }
            catch (Exception e)
            {
                return ReturnStatus.Error;
            }

            return reply;
        }
    }
}
