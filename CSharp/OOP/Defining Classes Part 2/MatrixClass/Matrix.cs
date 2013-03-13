/* 8. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).  
* 9. Implement an indexer this[row, col] to access the inner matrix cells. 
 * 10. Implement the operators + and - (addition and subtraction of matrices of the same size) and * 
 * for matrix multiplication. Throw an exception when the operation cannot be performed. Implement the 
 * true operator (check for non-zero elements). */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MatrixClass 
{
    public class Matrix<T> where T : struct
    {
        #region fields

        private int rowCount;
        private int colCount;
        private T[,] matrix;

        #endregion

        #region constuctors

        public Matrix(int rowCount, int colCount)
        {
            this.rowCount = rowCount;
            this.colCount = colCount;
            this.matrix = new T[rowCount, colCount];
        }

        #endregion

        #region operators

        public T this[int row, int col]
        {
            get
            {
                return matrix[row, col];
            }
            set
            {
                matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            // We can add one matrix to another only if they have same number of elements
            ValidateEqualDimensions(first, second);
            T[,] tempMatrix = new T[first.rowCount, first.colCount];
            
            for (int i = 0; i < first.rowCount; i++)
            {
                for (int j = 0; j < first.colCount; j++)
                {
                    // Number<T> because operators +, - etc don't work.
                    // See Number.cs and ICalculator.cs
                    Number<T> firstBox = first[i, j];
                    Number<T> secondBox = second[i, j];
                    tempMatrix[i, j] = firstBox + secondBox;
                }
            }

            Matrix<T> final = new Matrix<T>(first.rowCount, first.colCount);
            final.matrix = tempMatrix;
            return final;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            // We can add one matrix to another only if they have same number of elements
            ValidateEqualDimensions(first, second);
            T[,] tempMatrix = new T[first.rowCount, first.colCount];


            for (int i = 0; i < first.rowCount; i++)
            {
                for (int j = 0; j < first.colCount; j++)
                {
                    // Number<T> because operators +, - etc don't work.
                    // See Number.cs and ICalculator.cs
                    Number<T> firstBox = first[i, j];
                    Number<T> secondBox = second[i, j];
                    tempMatrix[i, j] = firstBox - secondBox;
                }
            }

            Matrix<T> final = new Matrix<T>(first.rowCount, first.colCount);
            final.matrix = tempMatrix;
            return final;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            // We can add one matrix to another only if they have same number of elements
            ValidateEqualDimensions(first, second);
            T[,] tempMatrix = new T[first.rowCount, first.colCount];

            for (int i = 0; i < first.rowCount; i++)
            {
                for (int j = 0; j < first.colCount; j++)
                {
                    // Number<T> because operators +, - etc don't work.
                    // See Number.cs and ICalculator.cs
                    Number<T> firstBox = first[i, j];
                    Number<T> secondBox = second[i, j];
                    tempMatrix[i, j] = firstBox * secondBox;
                }
            }

            Matrix<T> final = new Matrix<T>(first.rowCount, first.colCount);
            final.matrix = tempMatrix;
            return final;
        }

        public static bool operator true(Matrix<T> currMatrix)
        {
            // I really don't know when is true - when it's null or when it's not? To be or not to be?

            T defaultValue = default(T);
            bool isNull = true;

            for (int i = 0; i < currMatrix.rowCount; i++)
            {
                for (int j = 0; j < currMatrix.colCount; j++)
                {
                    if (!Equals(currMatrix[i, j], defaultValue))
                    {
                        isNull = false;
                    }
                }
            }

            return isNull;
        }

        public static bool operator false(Matrix<T> currMatrix)
        {
            T defaultValue = default(T);
            bool isNull = true;

            for (int i = 0; i < currMatrix.rowCount; i++)
            {
                for (int j = 0; j < currMatrix.colCount; j++)
                {
                    if (!Equals(currMatrix[i, j], defaultValue))
                    {
                        isNull = false;
                    }
                }
            }

            return isNull;
        }

        #endregion

       

        private static bool ValidateEqualDimensions(Matrix<T> first, Matrix<T> second)
        {
            int firstRows = first.rowCount;
            int secondRows = second.rowCount;

            int firstCols = first.colCount;
            int secondCols = second.colCount;

            if (firstRows != secondRows || firstCols != secondCols)
            {
                throw new DifferentMatricesException("Matrices are not the same size");
            }

            return true;
        }

      
    }
}
