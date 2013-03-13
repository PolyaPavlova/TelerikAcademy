/* 7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. 
 * You may need to add a generic constraints for the type T. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListNamespace
{
   public static class Extentions
    {
       public static T Min<T>(this GenericList<T> list)
            where T : IComparable<T>
       {
           // Set min value to the first item
           T minValue = list[0];
           int length = list.Len;
           
           for (int i = 0; i < length; i++)
           {
               // If list[i] is null, CompareTo will throw an exception
               if (list[i] == null)
               {
                   continue;
               } 
               
               if (list[i].CompareTo(minValue) < 0)
               {
                   minValue = list[i];
               }
           }

           return minValue;
       }

       public static T Max<T>(this GenericList<T> list)
           where T : IComparable<T>
       {
           T maxValue = list[0];
           int length = list.Len;

           for (int i = 0; i < length; i++)
           {
               // If list[i] is null, CompareTo will throw an exception
               if (list[i] == null)
               {
                   continue;
               } 

               if (list[i].CompareTo(maxValue) > 0)
               {
                   maxValue = list[i];
               }
           }

           return maxValue;
       }
    }
}
