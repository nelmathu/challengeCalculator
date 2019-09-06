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
    }
}
