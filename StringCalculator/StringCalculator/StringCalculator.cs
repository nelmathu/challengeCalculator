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
            int number;
            var delimiters = new List<char> { ',', '\n' }; // Defining comma and new line as separators

            // Call findDelimiters() to determine if a Custom Delimeter was provided
            string[] customDelimiters = findDelimiters(numbers);

            string[] stringArray = numbers.Split(customDelimiters, StringSplitOptions.None);
 
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

            // Check for negative numbers in the list
            CheckNegativesNumbers(numberList);

            // Remove all numbers > 1000 from the list
            numberList.RemoveAll(x => x > 1000);

            return string.IsNullOrEmpty(numbers) ? 0 : numberList.Sum();
        }

        public static string[] findDelimiters(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {

                // The following line extracts the substring [***] from //[***]\n
                string delimiterSection = numbers.Split('\n').First().Substring(2);

                if (delimiterSection.StartsWith("["))   // delimiter of any length
                {
                    delimiters.Add(delimiterSection.Substring(1, delimiterSection.Length - 2));
                }
                else     // single character length delimiter
                {
                    delimiters.Add(delimiterSection);
                }
                
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
