using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] results = new int[n];

        for (int l = 0; l < n; l++)
        {
            int p = int.Parse(Console.ReadLine());


            string pBin = Convert.ToString(p, 2);


            /// INVERTED P̃

            string pInvertedBin = "";

            for (int i = 0; i < pBin.Length; i++)
            {
                if (pBin[i] == '0')
                {
                    pInvertedBin += '1';

                }
                else
                {
                    pInvertedBin += '0';
                }
            }

            int intPInverted = Convert.ToInt32(pInvertedBin, 2);


            // REVERSED P̈

            string pReversedBin = "";

            for (int j = pBin.Length - 1; j >= 0; j--)
            {
                if (pBin[j] == '0')
                {
                    pReversedBin += '0';

                }
                else
                {
                    pReversedBin += '1';
                }
            }

            int intPReversed = Convert.ToInt32(pReversedBin, 2);

            int currRes = (p ^ intPInverted) & intPReversed;

            results[l] = currRes;
        }

        for (int r = 0; r < results.Length; r++)
        {
            Console.WriteLine(results[r]);
        }

        
    }
}

