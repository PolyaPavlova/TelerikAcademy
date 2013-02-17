using System;

class Proba
{
    static void Main()
    {
        Console.WriteLine("Please, enter the height of the tree:");
        int treeHeight = int.Parse(Console.ReadLine());
        string startAndEnd;
        string middle;

        for (int i = treeHeight, j = 1; i > 0; i--, j += 2)
        {
            startAndEnd = new string('.', i);
            middle = new string('*', j);

            Console.WriteLine(startAndEnd + middle + startAndEnd);
        }
        string bottomStart = new string('.', treeHeight);
        string star = new string('*', 1);
        Console.WriteLine(bottomStart + star + bottomStart);
        Console.WriteLine();
        Console.WriteLine();

        
    }
}