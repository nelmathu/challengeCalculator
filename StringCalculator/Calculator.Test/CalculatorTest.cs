// Unit Testing module for String Calculator Program
// Created by Nelson Mathurent
// Date: Sep 05 2019
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;


namespace Calculator.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AddNumbers_NoParameters_ReturnZero()
        {
            //Arrange 
            int expectedValue = 0;
            string numbersToTest = "";

            // Act 
            int actualValue = StringCalculator.Calculator.AddNumbers(numbersToTest);

            // Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void AddNumbers_InvalidValue_ReplaceToZero()
        {
            //Arrange 
            int expectedValue = 4;
            string numbersToTest = "4,6jk";

            // Act 
            int actualValue = StringCalculator.Calculator.AddNumbers(numbersToTest);

            // Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void AddNumbers_SingleValue_ReturnSameValue()
        {
            //Arrange 
            int expectedValue = 20;
            string numbersToTest = "20";

            // Act 
            int actualValue = StringCalculator.Calculator.AddNumbers(numbersToTest);

            // Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void AddNumbers_SupportNewLineSeparator_ReturnSum()
        {
            //Arrange 
            int expectedValue = 17;
            string numbersToTest = "8\n2,\n7";

            // Act 
            int actualValue = StringCalculator.Calculator.AddNumbers(numbersToTest);

            // Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void AddNumbers_AllowCustomDelimiter_ReturnSum()
        {
            //Arrange 
            int expectedValue = 18;
            string numbersToTest = "//;\n8;3;7";

            // Act 
            int actualValue = StringCalculator.Calculator.AddNumbers(numbersToTest);

            // Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void AddNumbers_NegativeNotAllow_ReturnException()
        {
            //Arrange 
            string numbersToTest = "-1";

            // Act 

            // Assert

            var exception = Assert.ThrowsException<StringCalculator.NegativesNotAllowedException>(() => StringCalculator.Calculator.AddNumbers(numbersToTest));
            bool isNegative = !exception.Message.Contains("-1");
            
            Assert.IsTrue(isNegative);
            {
            }
        }

        // Ignore any number greater than 1000 e.g. 2,1001,6 will return 8
        [TestMethod]
        public void AddNumbers_IgnoreNumbersGT1000_ReturnSum()
        {
            //Arrange 
            int expectedValue = 1005;
            string numbersToTest = "1001,5,1000";

            // Act 
            int actualValue = StringCalculator.Calculator.AddNumbers(numbersToTest);

            // Assert

            Assert.AreEqual(expectedValue, actualValue);
            {
            }
        }

        // Numbers equal to 1000 must be included
        [TestMethod]
        public void AddNumbers_TestNumbersEqualTo1000_IgnoreThem()
        {
            //Arrange 
            int expectedValue = 3008;
            string numbersToTest = "2,1000,6,1000\n1001,1000";

            // Act 
            int actualValue = StringCalculator.Calculator.AddNumbers(numbersToTest);

            // Assert

            Assert.AreEqual(expectedValue, actualValue);
            {
            }
        }
    }
}
