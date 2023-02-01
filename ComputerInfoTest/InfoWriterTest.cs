using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ComputerInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerInfoTest
{
    [TestClass]
    public class InfoWriterTest
    {
        List<RSInfoSend> data = default;
        InfoWriter writer = default;


        [TestInitialize]
        public void Start()
        {
            List<RSInfoSend> dataThere = new List<RSInfoSend>();

            for (int i = 0; i < 50; i++)
            {
                RSInfo info = new RSInfo();
                info.Usage = i;
                info.Date = DateTime.Now;
                info.Type = (RSInfoType)(i%Enum.GetNames(typeof(RSInfoType)).Length);

                RSInfoSend send= new RSInfoSend(info, i % 2 == 0 ? false: true);
                dataThere.Add(send);
            }

            this.data = dataThere;
            string directoryPath = "..\\..\\..\\testFiles";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            this.writer = new InfoWriter(directoryPath);

            writer.WriteRSInfo(data);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (writer != null)
            {
                writer.DeleteData();
                if (Directory.Exists(writer.directoryPath))
                { 
                    Directory.Delete(writer.directoryPath, true);
                }                
            }
            
        }


        [TestMethod]
        public void TestReaRSInfo__()
        {
            //Arrange
            List <RSInfoSend> all = default;

            //Act
            all = this.writer.ReadAllRSInfo();

            //Assert
            Assert.AreEqual(this.data.Count, all.Count);
        }

        [TestMethod]
        public void TestReadUnsendRSInfo__()
        {
            //Arrange
            List<RSInfo> all = default;

            //Act
            all = this.writer.ReadUnsendRSInfo();

            //Assert
            Assert.AreEqual(this.data.Where(x => x.sendStatus == false).Count(), all.Count);
        }
    }
}
