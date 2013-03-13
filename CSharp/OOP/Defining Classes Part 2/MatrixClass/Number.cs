using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    public class Number<T>
    {
        private T value;

        public Number(T value) 
        {
            this.value = value;
        
        }

        public static Type GetCalculatorType()
        {
            Type currType = typeof(T);
            Type calculatorType = null;

            if (currType == typeof(Int32))
            {
                calculatorType = typeof(Int32Calculator);
            }
            else if (currType == typeof(Double))
            {
                calculatorType = typeof(DoubleCalculator);
            }
            else if (currType == typeof(Decimal))
            {
                calculatorType = typeof(DecimalCalculator);
            }
            else if (currType == typeof(BigInteger))
            {
                calculatorType = typeof(BigIntegerCalculator);
            }
            else
            {
                // Exception handling to be added
                throw new InvalidCastException("Invalid type");
            }

            return calculatorType;
        }

        private static ICalculator<T> calculator = null;

        public static ICalculator<T> Calculator
        {
            get 
            {
                if (calculator == null)
                {
                    CreateCalculator();
                }

                return calculator;
            }
        }

        public static void CreateCalculator()
        {
            Type calculatorType = GetCalculatorType();
            calculator =  Activator.CreateInstance(calculatorType) as ICalculator<T>;
        }

        /// <summary>
        ///  Implicit?
        /// </summary>
        
        public static implicit operator Number<T>(T a)
        {
            return new Number<T>(a);
        }

        public static implicit operator T(Number<T> a)
        {
            return a.value;
        }

        public static Number<T> operator +(Number<T> first, Number<T> second)
        {
            return Calculator.Addition(first.value, second.value);
        }

        public static Number<T> operator -(Number<T> first, Number<T> second)
        {
            return Calculator.Substraction(first.value, second.value);
        }

        public static Number<T> operator *(Number<T> first, Number<T> second)
        {
            return Calculator.Multiply(first.value, second.value);
        }


    }

}
