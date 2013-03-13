/* 3. Write a static class with a static method to calculate the distance between two points in the 3D space */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSpace
{
    public static class Distance
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            // Formula:
            // (Xb - Xa)2 + (Yb - Ya)2 + (Zb - Za)2

            int xb = secondPoint.X;
            int xa = firstPoint.X;

            int yb = secondPoint.Y;
            int ya = firstPoint.Y;

            int zb = secondPoint.Z;
            int za = firstPoint.Z;

            double equation = ((xb - xa) * (xb - xa)) + ((yb - ya) * (yb - ya)) + ((zb - za) * (zb - za));

            double result = Math.Sqrt(equation);

            return result;

        }
    }
}

