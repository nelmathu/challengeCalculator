// String Calculator Program
// Created by Nelson Mathurent
// Date: Sep 05 2019

using System;

namespace StringCalculator
{
    public class Calculator
    {
        public static int AddNumbers(string numbers)
        {
            return string.IsNullOrEmpty(numbers) ? 0 : int.Parse(numbers);
        }
    }
}
