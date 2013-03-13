/* 5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
 * Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
 * Implement methods for adding element, accessing element by index, removing element by index, inserting element 
 * at given position, clearing the list, finding element by its value and ToString(). 
 * Check all input parameters to avoid accessing elements at invalid positions. */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListNamespace
{
    public class GenericList<T>
    {
        // Use region for better organization
        #region fields 

        private int capacity = 0; // Changed with constructor
        private int count = -1; // To know how many positions are filled
        private const int defaultCapacity = 5; // Default
        private T[] genericArray = new T[defaultCapacity]; 
        private int length = 0;

        #endregion

        #region properties
        
        public int Len
        {
            get
            {
                return genericArray.Length;
            }
        }

        #endregion

        #region constuctors

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.genericArray = new T[capacity];
        }

        #endregion

        #region methods

        public T[] AddElement(T element)
        {
            // Count is to know how many positions are filled. Adding element means one more filled position.
            count++;

            // In case of overloading, auto-grow
            if (count >= capacity)
            {
                genericArray = DoubleCapacity();
            }

            int length = genericArray.Length;

            // Getting the default value for this type. ex.: 0 or null
            T defaultValue = default(T);
            
            // Start from count means start from the last filled position 
            // so we don't override the first defaultValue from the begining but the first from where we can add
            // ex. {0,0,0} Add(2) -> {2,0,0} Add(0) -> {2,0,0} Add(7) -> {2,0,7} : without count -> {2,7,0};
            
            for (int i = count; i < length; i++)
            {
                // Using Equals because we cannot use ==
                if (Equals(genericArray[i], defaultValue))
                {
                    genericArray[i] = element;
                    break;
                }
            }

            return genericArray;

        }

        public T[] RemoveElement(int i)
        {
            int length = genericArray.Length;

            // Temporary array with length-1 of the original array. 
            T[] tempArray = new T[length - 1];
            T defaultValue = default(T);

            // Validate index (<0 and >length-1)
            if (ValidateIndexer(i) == true)
            {
                // Set default (0 or null) value like striking out the position
                genericArray[i] = defaultValue;

                // Now we have a hole. We have to move all elements after the hole with one position back to fill the hole.

                int start = i + 1;

                for (int p = start; p < length; p++)
                {
                    genericArray[p - 1] = genericArray[p];

                }

                // Ps: Now we have a hole in the end, but nobody cares

                // Fill tempArray
                for (int j = 0; j < tempArray.Length; j++)
                {
                    tempArray[j] = genericArray[j];
                }
            }

            // Watch how many position are filled
            capacity--;

            // Swap arrays
            genericArray = tempArray;

            return genericArray;
        }

        public T[] InsertElement(int position, T element)
        {
            int i = position;
            int length = genericArray.Length;

            // Temporary array with length+1 from the original array
            int tempLength = genericArray.Length + 1;

            // Special case - insert after last position
            if (i == length - 1)
            {
                genericArray = DoubleCapacity();
                tempLength = genericArray.Length;
            }
            
            T[] tempArray = new T[tempLength];

            // Fill the tempArray to the desired position
            for (int j = 0; j <= i; j++)
            {
                tempArray[j] = genericArray[j];
            }

            // Add the element after the desired position
            tempArray[i + 1] = element;

            // Fill the rest
            for (int l = i + 2; l < tempLength; l++)
            {
                tempArray[l] = genericArray[l - 1];
            }

            // Swap!
            genericArray = tempArray;

            return genericArray;
        }


        public T[] Clear()
        {
            T[] tempArray = new T[0];
            genericArray = tempArray;

            capacity = 0;
            return genericArray;
        }

        public int GetPosition(T element)
        {
            int length = genericArray.Length;
            int position = -1;

            for (int i = 0; i < length; i++)
            {
                // == doesn't work
                if (Equals(genericArray[i], element))
                {
                    position = i;
                    break;
                }
            }

            return position;
        }

        public override string ToString()
        {
            int length = genericArray.Length;
            StringBuilder buffer = new StringBuilder();
            string separator = ", ";

            for (int i = 0; i < length; i++)
            {
                buffer.Append(genericArray[i]);
               
                if (i != length-1)
                {
                    buffer.Append(separator);    
                }
            }

            string result = buffer.ToString();

            return result;
        }

        /* 6. Implement auto-grow functionality: when the internal array is full, create a new array of 
         * double size and move all elements to it. */

        private T[] DoubleCapacity() 
        {
            int length = genericArray.Length;
            T[] tempArray = new T[length * 2];
           
            for (int i = 0; i < length; i++)
            {
                tempArray[i] = genericArray[i];
            }

            capacity *= 2;

            return tempArray;
        }

        #endregion

        #region operators

        public T this[int i]
        {
            get
            {
                return genericArray[i];
            }
            set
            {
                if (ValidateIndexer(i) == true)
                {
                    genericArray[i] = value;
                }

            }
        }

        #endregion

        #region validation
        private bool ValidateIndexer(int i)
        {
            int lastPossible = genericArray.Length - 1;

            if (i < 0 || i > lastPossible)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            else
            {
                return true;
            }
        }

        #endregion
    }

}