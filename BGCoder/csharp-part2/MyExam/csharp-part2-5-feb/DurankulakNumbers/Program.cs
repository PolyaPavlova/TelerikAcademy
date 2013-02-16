using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DurankulakNumbers
{
    public class DurankulakNumbersClass
    {
        public static BigInteger ConvertToDecimal(string input)
        {
            string[] array = {
                                "A","B","C","D","E","F","G","H","I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                "aA", "aB", "aC", "aD", "aE", "aF", "aG", "aH", "aI", "aJ", "aK", "aL", "aM", "aN", "aO", "aP", "aQ", "aR", "aS", "aT", "aU", "aV", "aW", "aX", "aY", "aZ",
                                "bA", "bB", "bC", "bD", "bE", "bF", "bG", "bH", "bI", "bJ", "bK", "bL", "bM", "bN", "bO", "bP", "bQ", "bR", "bS", "bT", "bU", "bV", "bW", "bX", "bY", "bZ",
                                "cA", "cB", "cC", "cD", "cE", "cF", "cG", "cH", "cI", "cJ", "cK", "cL", "cM", "cN", "cO", "cP", "cQ", "cR", "cS", "cT", "cU", "cV", "cW", "cX", "cY", "cZ",
                                "dA", "dB", "dC", "dD", "dE", "dF", "dG", "dH", "dI", "dJ", "dK", "dL", "dM", "dN", "dO", "dP", "dQ", "dR", "dS", "dT", "dU", "dV", "dW", "dX", "dY", "dZ",
                                "eA", "eB", "eC", "eD", "eE", "eF", "eG", "eH", "eI", "eJ", "eK", "eL", "eM", "eN", "eO", "eP", "eQ", "eR", "eS", "eT", "eU", "eV", "eW", "eX", "eY", "eZ",
                                "fA", "fB", "fC", "fD", "fE", "fF", "fG", "fH", "fI", "fJ", "fK", "fL"
                             };

            BigInteger length = input.Length;

            List<BigInteger> numbers = new List<BigInteger>();

            BigInteger currNum = 0;
            StringBuilder currNumStr = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                if (Char.IsUpper(input[i]))
                {
                    currNum = Array.IndexOf(array, input[i].ToString());
                    numbers.Add(currNum);
                }
                else
                {
                    currNumStr.Append(input[i]);
                    currNumStr.Append(input[i + 1]);
                    i++;
                    currNum = Array.IndexOf(array, currNumStr.ToString());
                    numbers.Add(currNum);
                    currNumStr.Clear();
                }
            }

            BigInteger power = 0;
            BigInteger result = 168;

            for (int i = numbers.Count - 2; i >= 0; i--)
            {
                power++;

                for (int p = 0; p < power; p++)
                {

                    numbers[i] *= result;

                }

                result = 168;
            }

            BigInteger endResult = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                endResult += numbers[i];
            }

           // Console.WriteLine(endResult);
            return endResult;
        }
             
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //string input = "fAAaB";

            Console.WriteLine(ConvertToDecimal(input));
        }
    }
}