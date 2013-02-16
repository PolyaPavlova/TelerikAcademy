using System;
using System.Numerics;

class SubsetSumProblem
{
    static void Main()
    {
        BigInteger s = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        BigInteger[] array = new BigInteger[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = BigInteger.Parse(Console.ReadLine());
        }

        int max = (int)Math.Pow(2, n);

        BigInteger sum = 0;
        int count = 0;

        for (int i = 1; i < max; i++)
        {
            sum = 0;
            for (int j = 0; j < n; j++)
            {
                int bit = (i & (1 << j)) >> j;

                if (bit == 1)
                {
                    sum += array[j];
                }

            }

            if (sum == s)
            {
                count++;
            }

        }

        Console.WriteLine(count);
    }
}


