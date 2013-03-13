/*4. Create a class Path to hold a sequence of points in the 3D space */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Path
{
    public List<Point3D> Paths = new List<Point3D>();

    //public Path(List<Point3D> path)
    //{
    //    this.Paths = path;
    //}

    public void AddPoint(Point3D point)
    {
        Paths.Add(point);
    }
}

