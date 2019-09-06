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
 
            // Create a List of numbers
            List<int> numberList = new List<int>();

            foreach (var str in stringArray)
            {
                if (int.TryParse(str, out number))
                {
                    numberList.Add(number);
                    //totalSum += number;
                }
            }

            // Remove all numbers >= 1000 from the list
            numberList.RemoveAll(x => x >= 1000);

            // Check for negative numbers in the list
            CheckNegativesNumbers(numberList);

            return string.IsNullOrEmpty(numbers) ? 0 : numberList.Sum();
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


        public static void CheckNegativesNumbers(List<int> numbersList)
        {
            var negativeNumbers = numbersList.Where(x => x < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new NegativesNotAllowedException(negativeNumbers);
            }
        }

    }
}
