using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder source, int index, int length) 
        {
            StringBuilder result = new StringBuilder();

            string sourceString = source.ToString();
            
            for (int i = index; i < length; i++)
            {
                result.Append(source[i]);
            }

            return result;
        }
    }
}
