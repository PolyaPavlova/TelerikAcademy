using System;
using System.Numerics;


class Tribonacci
{
    static void Main()
    {
        BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger thidNumber = BigInteger.Parse(Console.ReadLine());

        BigInteger wantedNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger nextNumber = 0;

        if (wantedNumber == 1)
        {
            Console.WriteLine(firstNumber);
        }
        else if (wantedNumber == 2)
        {
            Console.WriteLine(secondNumber);
        }
        else if (wantedNumber == 3)
        {
            Console.WriteLine(thidNumber);
        }
        else
        {
            for (int i = 3; i < wantedNumber; i++)
            {
                nextNumber = firstNumber + secondNumber + thidNumber;

                firstNumber = secondNumber;
                secondNumber = thidNumber;
                thidNumber = nextNumber;


            }

            Console.WriteLine(nextNumber);
        }
    }
}

