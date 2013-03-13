/* 4. ... Create a static class PathStorage with static methods to save and load paths from a text file. 
 * Use a file format of your choice. */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSpace
{
    public static class PathStorage
    {
        public static void SaveToFile(Path path)
        {
            // First assign writer and file to save in
            // True so we can append many paths
            StreamWriter writer = new StreamWriter("../../SavedPaths.txt", true);

            using (writer)
            {
                // Define variable length outside the loop so there's no need to be calculated at every iteration
                int length = path.Paths.Count;

                for (int i = 0; i < length; i++)
                {
                    // Our path has a List of elements of Point3D
                    // WriteLine works because of overriding ToString
                    writer.WriteLine(path.Paths[i]);
                }

                // To separate different paths
                writer.WriteLine("*");

            }
        }

        public static void LoadFromFile()
        {        
            // Load the file
            StreamReader reader = new StreamReader("../../SavedPaths.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                
                // line == null when there are no more lines
                while (line != null)
                {
                    Console.WriteLine(line);

                    // Update line
                    line = reader.ReadLine();
                }
            }
        }

        
    }
}

