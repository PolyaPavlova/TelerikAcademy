using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 5, 5 };

            int arrSum = arr.Sum();
            int arrProduct = arr.Product();

            int[] testArr2 = { 2, 3, 6 };

            int testArr2Min = testArr2.Min();
            int testArr2Max = testArr2.Max();
        }
    }
}
