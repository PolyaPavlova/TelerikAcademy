using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Matrix<int> test = new Matrix<int>(2,2);

            // Testing indexer
            test[0, 0] = 4;
            test[1, 0] = 4;
            test[1, 1] = 4;
            test[0, 1] = 4;

            Matrix<int> test1 = new Matrix<int>(2, 3);

            test1[0, 0] = 2;
            test1[1, 0] = 2;
            test1[1, 1] = 2;
            test1[0, 1] = 2;

            // Testing arithmetical operators
            Matrix<int> addition = test + test1;
            Matrix<int> substraction = test - test1;
            Matrix<int> multiply = test * test1;

            // Testing true and false operators
            if (test)
            {
                Console.WriteLine("Matrix is null");
            }
            else
            {
                Console.WriteLine("Matrix is NOT null");
            }
        }
    }
}
