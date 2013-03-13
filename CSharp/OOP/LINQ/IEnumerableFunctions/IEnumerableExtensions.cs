using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableFunctions
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> source)
        {
            T result = default(T);

            foreach (var item in source)
            {
                result += (dynamic)item;
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> source)
        {
            dynamic currRes = 1;

            foreach (var item in source)
            {
                currRes *= (dynamic)item;
            }

            return currRes;
        }

        public static T Min<T>(this IEnumerable<T> source) where T : IComparable
        {

            T min = source.First();

            foreach (var item in source)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;   
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> source) where T : IComparable
        {
            T max = source.First();

            foreach (var item in source)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> source)
        {
            dynamic sum = 0;
            int count = 0;

            foreach (var item in source)
            {
                count++;
                sum += (dynamic)item;
            }

            T result = sum / count;

            return result;

        }
    }
}
