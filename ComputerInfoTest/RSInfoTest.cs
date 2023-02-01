using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerInfoTest
{
    [TestClass]
    public class RSInfoTest
    {
        [TestMethod]
        public void TestConstructorFromText_Text_RSInfo()
        {
            //Arrange
            DateTime date = DateTime.Now;
            int usage = 50;
            RSInfoType type = RSInfoType.CPU;

            RSInfo expected = new RSInfo(type, usage, date);

            string expectedString = $"{type}*{usage}*{date}";

            //Act
            RSInfo actual = new RSInfo(expectedString);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTextSave_RSInfo_Text()
        {
            //Arrange
            DateTime date= DateTime.Now;
            int usage = 50;
            RSInfoType type = RSInfoType.CPU;

            RSInfo info= new RSInfo(type, usage, date);

            string expected = $"{type}*{usage}*{date}";

            //Act
            string actual = info.TextSave();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString_RSInfo_Text()
        {
            //Arrange
            DateTime date = DateTime.Now;
            int usage = 50;
            RSInfoType type = RSInfoType.CPU;

            RSInfo info = new RSInfo(type, usage, date);

            string expected = $"type : {type}  usage : {usage}  date : {date}";

            //Act
            string actual = info.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
