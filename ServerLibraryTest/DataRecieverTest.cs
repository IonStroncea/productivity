

using Common;
using ComputerInfo;
using ServerLibrary;

namespace ServerLibraryTest
{
    [TestClass]
    public class DataRecieverTest
    {
        [TestMethod]
        public void TestRecieveLatest()
        {
            //Arrange
            DataReciever reciever = new DataReciever(new TestingDataSaver(), new Cache());
            MRSInfo info = new MRSInfo();

            //Act
            ReturnStatus returnStatus = reciever.RecieveLatest(info, 1);

            //Assert
            Assert.AreEqual(ReturnStatus.Success, returnStatus);
        }

        [TestMethod]
        public void TestSave()
        {
            //Arrange
            DataReciever reciever = new DataReciever(new TestingDataSaver(), new Cache());
            MRSInfo info = new MRSInfo();

            //Act
            ReturnStatus returnStatus = reciever.Save(info, 1);

            //Assert
            Assert.AreEqual(ReturnStatus.Success, returnStatus);
        }
    }
}