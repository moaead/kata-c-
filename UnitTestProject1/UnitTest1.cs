using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calc = new Calculator();

        [TestMethod]
        public void Given0NumbersReturn0()
        {
            var input = "";
            int result = calc.Add(input);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Given1NumbersReturnNumber()
        {
            String input = "1";
            int result = calc.Add(input);
            Assert.AreEqual(result, 1);

        }
       
        [TestMethod]
        public void Given2NumbersReturnSum()
        {
            String input = "1,2";
            
            int result = calc.Add(input);
            
            Assert.AreEqual(result, 3);

        }
        [TestMethod]
        public void GivenAnyAmountOfnumbersReturnSum()
        {
            String input = "1,2,5,6,7,8,2";

            int result = calc.Add(input);

            Assert.AreEqual(result, 1+2+5+6+7+8+2);
        }
        
        [TestMethod]
        public void GivenNumbersWithNewLine()
        {
            String input = "1\n2,3";
            int result = calc.Add(input);
            Assert.AreEqual(result, 6);
        }
        [TestMethod]
        public void GivenNumbersWithDilmReturnSum()
        {
            String input = "//;\n1;2";
            int result = calc.Add(input);
            Assert.AreEqual(result, 3);
        }
        [TestMethod]
        public void GivenNegativeNumberReturnTheNumber()
        {
            try
            {
                String input = "-1";
                int result = calc.Add(input);
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.StartsWith("negatives"));
            }
            
        }
        [TestMethod]
        public void GivenNegativeNumbersReturnThem()
        {
            try
            {
                String input = "-1,-2,-3,-4,5,6";
                int result = calc.Add(input);
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.StartsWith("negatives") && e.Message.Contains("-4"));
            }
            
        }
        [TestMethod]
        public void GivenNumbersLargenThan1000IgnoreThem()
        {
            String input = "1002, 1, 2";
            int result = calc.Add(input);
            Assert.AreEqual(result, 5);
        }
        [TestMethod]
        public void GivenNumbersWithMultipleStringDilmReturnSum()
        {
            String input = "//[***]\n1***2***3";
            int result = calc.Add(input);
            Assert.AreEqual(result, 6);
        }
        [TestMethod]
        public void GivenNumbersWithMultipleDilmReturnSum()
        {
            String input = "//[*][%]\n1*2%3";
            int result = calc.Add(input);
            Assert.AreEqual(result, 6);
        }
        
        

    }
}
