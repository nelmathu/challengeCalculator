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
            int totalSum = 0;
            int number;
            string[] stringArray = numbers.Split(',');
            foreach (var str in stringArray)
            {
                if (int.TryParse(str, out number))
                {
                    totalSum += number;
                }
            }

            return string.IsNullOrEmpty(numbers) ? 0 : totalSum;
        }
    }
}
