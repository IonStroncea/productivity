using Common;
using DAL;
using ComputerInfo;
using ProtoBuf.Grpc;

namespace ServerLibrary
{
    public class DataReciever : IDataReciever
    {
        public IDataSaver dataSaver;
        public ICache cache;
        public IProccesUssageCache proccesUssageCache;

        public DataReciever(IDataSaver dataSaver, ICache cache, IProccesUssageCache proccesUssageCache)
        {
            this.dataSaver = dataSaver;
            this.cache = cache;
            this.proccesUssageCache = proccesUssageCache;
        }
        public ReturnStatus RecieveLatest(MRSInfo info, int computerId)
        {
            ReturnStatus status = cache.AddCacheInfo(new CacheInfo(computerId, info));

            if (status != ReturnStatus.Success)
            {
                return status;
            }

            return Save(info, computerId);
        }

        public ReturnStatus RecieveLatestUssageInfo(List<ProcessUssageInfo> info, int computerId)
        {
            ReturnStatus status =  proccesUssageCache.AddProccesUssage(info, computerId);

            Console.WriteLine($"Current length {proccesUssageCache.GetSize()}");

            return status;
        }

        public ReturnStatus Save(MRSInfo info, int computerId)
        {
            return dataSaver.SaveMRSInfo(info, computerId);
        }

        public ReturnStatus Save(RSInfo info, int computerId)
        {
            return dataSaver.SaveRSInfo(info, computerId);
        }
    }
}