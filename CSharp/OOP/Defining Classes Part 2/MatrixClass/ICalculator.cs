using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    public interface ICalculator<T> 
    {
        T Addition(T first, T second);
        T Substraction(T first, T second);
        T Multiply(T first, T second);
    }

    struct Int32Calculator : ICalculator<Int32>
    {
        //int or Int32???

        public int Addition(int first, int second)
        {
            return first + second;
        }

        public int Substraction(int first, int second)
        {
            return first - second;
        }

        public int Multiply(int first, int second)
        {
            return first * second;
        }
        

    }

    struct DoubleCalculator : ICalculator<Double>
    {

     public double Addition(double first, double second)
        {
            return first + second;
        }

        public double Substraction(double first, double second)
        {
            return first - second;
        }

        public double Multiply(double first, double second)
        {
            return first * second;
        }

    }

    struct DecimalCalculator : ICalculator<Decimal>
    {

        public decimal Addition(decimal first, decimal second)
        {
            return first + second;
        }

        public decimal Substraction(decimal first, decimal second)
        {
            return first - second;
        }

        public decimal Multiply(decimal first, decimal second)
        {
            return first * second;
        }
    }

    struct BigIntegerCalculator : ICalculator<BigInteger>
    {
        public BigInteger Addition(BigInteger first, BigInteger second)
        {
            return first + second;
        }

        public BigInteger Substraction(BigInteger first, BigInteger second)
        {
            return first - second;
        }

        public BigInteger Multiply(BigInteger first, BigInteger second)
        {
            return first * second;
        }
    }
}
