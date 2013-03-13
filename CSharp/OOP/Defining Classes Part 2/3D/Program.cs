using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSpace {
    class Program
    {
    
        static void Main(string[] args)
        {

            Point3D firstPoint = new Point3D(3, 4, 5);
            
            // Testing ToString
            Console.WriteLine(firstPoint);

            Point3D secondPoint = new Point3D(2, 3, 4);
            Point3D thirdPoint = new Point3D(6, 7, 8);

            Path firstPath = new Path();
            firstPath.AddPoint(firstPoint);
            firstPath.AddPoint(secondPoint);
            firstPath.AddPoint(thirdPoint);

            Path secondPath = new Path();
            Point3D fourthPoint = new Point3D(20, 21, 22);
            Point3D fifthPoint = new Point3D(23, 24, 25);
            Point3D sixthPoint = new Point3D(26, 27, 28);
            Point3D seventhPoint = new Point3D(29, 30, 31);


            secondPath.AddPoint(fourthPoint);
            secondPath.AddPoint(fifthPoint);
            secondPath.AddPoint(sixthPoint);
            secondPath.AddPoint(seventhPoint);

            //double distance = Distance.CalculateDistance(firstPoint, secondPoint);
            
            //Console.WriteLine(distance);

            //PathStorage.SaveToFile(firstPath);
            //PathStorage.SaveToFile(secondPath);

            //PathStorage.LoadFromFile();
        


        }
    }
}
