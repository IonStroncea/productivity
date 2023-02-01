using ComputerInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ComputerInfoTest
{
    [TestClass]
    public class ResourceUsageInfoTest
    {
        [TestMethod]
        public void TestGetCPUUsage_Nothing_RSInfoTypeCPUvaluenot0()
        {
            //Arrange
            ResourseUsageInfo resourseUsage = new ResourseUsageInfo();

            RSInfo wanted = new RSInfo();
            wanted.Type = RSInfoType.CPU;

            //Act
            RSInfo actual = resourseUsage.GetCPUUsage();

            //Assert
            Assert.AreEqual(wanted.Type, actual.Type);
            Assert.IsTrue(actual.Usage > 0);
        }

        [TestMethod]
        public void TestGetGPUUsage_Nothing_RSInfoTypeGPU()
        {
            //Arrange
            ResourseUsageInfo resourseUsage = new ResourseUsageInfo();

            RSInfo wanted = new RSInfo();
            wanted.Type = RSInfoType.GPU;

            //Act
            RSInfo actual = resourseUsage.GetGPUUsage();

            //Assert
            Assert.AreEqual(wanted.Type, actual.Type);
        }

        [TestMethod]
        public void TestGetGPUUsage_Nothing_RSInfoTypeRAMvaluenot0()
        {
            //Arrange
            ResourseUsageInfo resourseUsage = new ResourseUsageInfo();

            RSInfo wanted = new RSInfo();
            wanted.Type = RSInfoType.RAM;

            //Act
            RSInfo actual = resourseUsage.GetRAMUsage();

            //Assert
            Assert.AreEqual(wanted.Type, actual.Type);
            Assert.IsTrue(actual.Usage > 0);
        }

        [TestMethod]
        public void TestGetAllInfo_Nothing_MRSInfo()
        {
            //Arrange
            ResourseUsageInfo resourseUsage = new ResourseUsageInfo();

            //Act
            MRSInfo infos = resourseUsage.GetAllInfo();

            //Assert
            foreach (int i in Enum.GetValues(typeof(RSInfoType)))
            {
                Assert.IsTrue(infos.ExistType((RSInfoType)Enum.ToObject(typeof(RSInfoType), i)));
            }
        }
    }
}