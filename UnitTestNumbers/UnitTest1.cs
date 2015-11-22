using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryDecimalConverterApp;

namespace UnitTestNumbers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 form = new Form1();

            form.ConvertToDecimal(2);

            var binarys = form.binarys;

            Assert.AreEqual(1, binarys.Count);
        }
    }
}
