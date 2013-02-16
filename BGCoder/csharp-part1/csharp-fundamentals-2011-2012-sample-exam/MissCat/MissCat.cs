using System;

class MissCat
{
    static void Main()
    {
        int[] cats = new int[10];

        int firstCat = 0;
        int secondCat = 0;
        int thirdCat = 0;
        int fourCat = 0;
        int fifthCat = 0;
        int sixthCat = 0;
        int seventhCat = 0;
        int eigthCat = 0;
        int ninethCat = 0;
        int tenthCat = 0;

        int juryNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < juryNumber; i++)
        {
            int cat = int.Parse(Console.ReadLine());

            switch (cat)
            {
                case 1: firstCat++;
                    cats[0] = firstCat;
                    break;
                case 2: secondCat++;
                    cats[1] = secondCat;
                    break;
                case 3: thirdCat++;
                    cats[2] = thirdCat;
                    break;
                case 4: fourCat++;
                    cats[3] = fourCat;
                    break;
                case 5: fifthCat++;
                    cats[4] = fifthCat;
                    break;
                case 6: sixthCat++;
                    cats[5] = sixthCat;
                    break;
                case 7: seventhCat++;
                    cats[6] = seventhCat;
                    break;
                case 8: eigthCat++;
                    cats[7] = eigthCat;
                    break;
                case 9: ninethCat++;
                    cats[8] = ninethCat;
                    break;
                case 10: tenthCat++;
                    cats[9] = tenthCat;
                    break;
            }
        }

        int maxPoints = 0;
        int winner = 0;
        
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i] > maxPoints)
            {
                maxPoints = cats[i];
                winner = Array.IndexOf(cats, cats[i]);
            }
        }

        Console.WriteLine(winner+1);

        

    }
}

