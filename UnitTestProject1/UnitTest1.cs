using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public List<int> binarys = new List<int>();


        [TestMethod]
        public void TestMethod1()
        {
            ConvertToDecimal(3);
            ConvertToDecimalWhile(3);
            Assert.AreEqual(2, binarys.Count);

           
        }



        private void ConvertToDecimal(int binary)
        {
            var reminder = binary % 2;
            var result = binary / 2;

            if (result != 0)
            {
                binarys.Add(reminder);
                ConvertToDecimal(result);
            }
            else
            {
                binarys.Add(reminder);
            } 
        }

        private void ConvertToDecimalWhile(int binary)
        {
            var reminder = 0;
            var result = "";

            while (binary != 0)  // >0
            {
                reminder = binary % 2;
                binary = binary / 2;
                result = reminder.ToString();
                Console.WriteLine("result: {0}", result);
            }
             
        }
    }
}
