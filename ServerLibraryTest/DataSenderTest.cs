using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ComputerInfo;
using DAL;
using ServerLibrary;

namespace ServerLibraryTest
{
    [TestClass]
    public class DataSenderTest
    {
        [TestMethod]
        public void TestGetAllMRSInfo()
        {
            //Arrange
            DataSender sender = new DataSender(new TestingDataSource(), new Cache());

            //Act
            List<MRSInfo> result = sender.GetAllMRSInfo(1);

            //Aesert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void TestGetAllRSInfoGyType()
        {
            //Arrange
            DataSender sender = new DataSender(new TestingDataSource(), new Cache());
            RSInfoType type = RSInfoType.CPU;

            //Act
            List<RSInfo> result = sender.GetAllRSInfoByType(1, type);

            //Aesert
            Assert.IsNotNull(result);
            result.ForEach(x => Assert.IsTrue(x.Type == type));
        }

        [TestMethod]
        public void TestAllRSInfo()
        {
            //Arrange
            DataSender sender = new DataSender(new TestingDataSource(), new Cache());

            //Act
            List<RSInfo> result = sender.GetAllRSInfo(1);

            //Aesert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void TestGetLatestMRSInfo()
        {
            //Arrange
            Cache cache = new Cache();
            DataSender sender = new DataSender(new TestingDataSource(), cache);
            DataReciever reciever = new DataReciever(new TestingDataSaver(), cache);

            MRSInfo info = new MRSInfo();

            //Act
            ReturnStatus status= reciever.RecieveLatest(info, 1);

            //Aesert
            Assert.IsTrue(status == ReturnStatus.Success);
            Assert.AreEqual(info, sender.GetLatestMRSInfo(1));

        }
    }
}
