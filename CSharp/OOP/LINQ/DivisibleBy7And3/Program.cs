/* 6. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
 * Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleBy7And3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>(){ 4, 5, 14, 21, 49, 15, 441 };

            int divisor = 7 * 3;

            List<int> divisibleBy7And3Lambda = array.FindAll(x => (x % divisor) == 0);

            foreach (var number in divisibleBy7And3Lambda)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nLINQ:");

            var divisibleLinq =
                from number in array
                where number % divisor == 0
                select number;

            foreach (var number in divisibleLinq)
            {
                Console.WriteLine(number);
            }

           
               

        }
    }
}
