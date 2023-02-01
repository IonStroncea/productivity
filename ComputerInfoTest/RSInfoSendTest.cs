using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerInfoTest
{
    [TestClass]
    public class RSInfoSendTest
    {
        [TestMethod]
        public void TestToString__Text()
        {
            //Arrange
            DateTime date = DateTime.Now;
            int usage = 50;
            RSInfoType type = RSInfoType.CPU;

            RSInfo info = new RSInfo(type, usage, date);
            RSInfoSend expected = new RSInfoSend(info);

            string expectedText = $"Send status : {expected.sendStatus} {expected.info.ToString()}";

            //Act
            string actualText = expected.ToString();


            //Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void TestToText__Text()
        {
            //Arrange
            DateTime date = DateTime.Now;
            int usage = 50;
            RSInfoType type = RSInfoType.CPU;

            RSInfo info = new RSInfo(type, usage, date);
            RSInfoSend expected = new RSInfoSend(info);

            string expectedText = $"{(expected.sendStatus ? 1 : 0)}*{expected.info.TextSave()}";

            //Act
            string actualText = expected.TextSave();


            //Assert
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void TestConstructor_Text_RSInfoSend()
        {
            //Arrange
            DateTime date = DateTime.Now;
            int usage = 50;
            RSInfoType type = RSInfoType.CPU;

            RSInfo info = new RSInfo(type, usage, date);
            RSInfoSend expected = new RSInfoSend(info);

            //Act
            string initialText = $"{(expected.sendStatus ? 1 : 0)}*{expected.info.TextSave()}";
            RSInfoSend actual = new RSInfoSend(initialText);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
