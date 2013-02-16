using System;


class BinaryDigitsCount
{
    static void Main()
    {
        int wantedBit = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
             

        int[] results = new int[n];

       // string resultString = "";

        for (int j = 0; j < n; j++)
        {
            int number = int.Parse(Console.ReadLine());

            int countBits = 0;
            int startPosition = 0;


                for (int i = 32; i >= 0; i--)
                {
                    int currBit = ((number & (1 << i)) >> i;

                    if (currBit == 1)
                    {
                        startPosition = i;
                        break;
                    }

                }

                for (int i = 0; i <= startPosition; i++)
                {
                    int lastBit = (number & (1 << i)) >> i;

                    if (lastBit == wantedBit)
                    {
                        countBits++;                                              
                    }
                }

                results[j] = countBits;
                //resultString += countBits + "\n";
        }

       

        //Console.WriteLine(resultString + "\b");
        
        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine(results[i]);
        }
        
    }
}

