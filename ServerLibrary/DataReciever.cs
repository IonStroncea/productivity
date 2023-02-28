using Common;
using DAL;
using ComputerInfo;
using ProtoBuf.Grpc;
using Computerinfo;

namespace ServerLibrary
{
    public class DataReciever : IDataReciever
    {
        private IDataSaver dataSaver;
        private ICache cache;
        private IProccesUssageCache proccesUssageCache;

        public DataReciever(IDataSaver dataSaver, ICache cache, IProccesUssageCache proccesUssageCache)
        {
            this.dataSaver = dataSaver;
            this.cache = cache;
            this.proccesUssageCache = proccesUssageCache;
        }

        public ReturnStatus RecieveComputerInfo(GetComputerInfo computerInfo, int computerId)
        {
            ReturnStatus status = dataSaver.SaveComputerInfo(computerInfo, computerId);

            return status;
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