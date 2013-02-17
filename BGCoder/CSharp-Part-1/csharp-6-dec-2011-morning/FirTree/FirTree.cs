using System;

class FirTree
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        string dot, star;

        for (int i = 0; i < height - 1; i++)
        {
            dot = new string('.', (height - i) - 2);
            star = new string('*', (i * 2) + 1);

            Console.Write(dot);
            Console.Write(star);
            Console.Write(dot);
            Console.WriteLine();
        }

        dot = new string('.', height - 2);
        Console.Write(dot);
        Console.Write("*");
        Console.Write(dot);

        
    }
}
