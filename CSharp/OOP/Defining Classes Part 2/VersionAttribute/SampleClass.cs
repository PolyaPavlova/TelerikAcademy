/* 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations 
 * and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute 
 * to a sample class and display its version at runtime.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionAttribute
{
    [Version(2,7)]
    public class SampleClass
    {
        static void Main()
        {
            Type type = typeof(SampleClass);
            object[] attributes = type.GetCustomAttributes(false);

            VersionAttribute attr = (VersionAttribute)attributes[0];

            Console.WriteLine("Version: {0}.{1}", attr.Major, attr.Minor);
        }
    }
}
