using System;

class Program
{
    static void Main()
    {
        int wantedBit = int.Parse(Console.ReadLine());
        long number = long.Parse(Console.ReadLine());

        int[] results = new int[number];

        int countBits = 0;

        for (int i = 0; i < number; i++)
        {
            long currNumber = long.Parse(Console.ReadLine());

            string inBinary = Convert.ToString(currNumber, 2);
            
            for (int j = 0; j < inBinary.Length; j++)
            {

                if (wantedBit == 0)
                {
                    if (inBinary[j] == '0')
                    {
                        countBits++;
                    }
                }
                else
                {
                    if (inBinary[j] == '1')
                    {
                        countBits++;
                    }
                }
            }

            results[i] = countBits;
            countBits = 0;
        }

        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine(results[i]);
        }
       
    }
}

