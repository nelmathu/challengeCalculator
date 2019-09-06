// String Calculator Program
// Created by Nelson Mathurent
// Date: Sep 05 2019

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StringCalculator
{
    public class Calculator
    {
        public static int AddNumbers(string numbers)
        {
            int totalSum = 0;
            int number;
            var delimiters = new List<char> { ',', '\n' }; // Defining comma and new line as separators

            // Call findDelimiters() to determine if a Custom Delimeter was provided
            char[] customDelimiters = findDelimiters(numbers);

            string[] stringArray = numbers.Split(customDelimiters); 
            foreach (var str in stringArray)
            {
                if (int.TryParse(str, out number))
                {
                    totalSum += number;
                }
            }

            return string.IsNullOrEmpty(numbers) ? 0 : totalSum;
        }

        public static char[] findDelimiters(string numbers)
        {
            var delimiters = new List<char> { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                string delimiterSection = numbers.Split('\n').First();
                char actualDelimiter = delimiterSection.Substring(2,1)[0];
                delimiters.Add(actualDelimiter);
            }

            return delimiters.ToArray();
        }

    }
}
