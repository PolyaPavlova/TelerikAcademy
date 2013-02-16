using System;

class Pillars
{
    static void Main()
    {
        int[] columns = new int[8]; // Full sums in columns

        for (int i = 0; i < 8; i++)
        {
            int n = int.Parse(Console.ReadLine());

            string nString = Convert.ToString(n, 2).PadLeft(8, '0');
            int bit = 0;
           

            for (int j = 0; j < nString.Length; j++)
            {
                if (nString[j] == '0')
                {
                    bit = 0;
                    columns[j] += bit;
                }
                else
                {
                    bit = 1;
                    columns[j] += bit;
                }
            }

        }

        int totalSum = 0;

        for (int i = 0; i < columns.Length; i++)
        {
            totalSum += columns[i];
        }

        //Console.WriteLine("Total sum: {0}",totalSum);

        int currSum = 0;
        int leftSide = 0;
        int rightSide = 0;

        bool isPillar = false;

        int pillarPosition = 0;

        for (int pillar = 0; pillar < 8; pillar++)
        {
            currSum = totalSum - columns[pillar];

            for (int r = pillar+1; r < 8; r++)
            {
                leftSide += columns[r];
                
            }

            for (int l = pillar-1; l >= 0; l--)
            {
                rightSide += columns[l];
            }


            //if (rightSide == 0 && leftSide == 0)
            //{
            //    isPillar = true;
            //    Console.WriteLine(0);
            //    Console.WriteLine(0);
            //    break;
            //}
            if (rightSide == leftSide)
            {
                isPillar = true;
                Console.WriteLine(8 - pillar - 1);
                Console.WriteLine(rightSide);
                break;
            }
            

            rightSide = 0;
            leftSide = 0;

            //Console.WriteLine("Current sum: {0}", currSum);   
        }

        if (isPillar == false)
        {
            Console.WriteLine("No");
        }
        






    }
}
