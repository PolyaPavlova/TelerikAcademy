/* 1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
 * Implement the ToString() to enable printing a 3D point. */

public struct Point3D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }   

    public Point3D(int x, int y, int z) : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    /* 2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
     * Add a static property to return the point O. */

    private static readonly Point3D basePoint = new Point3D(0, 0, 0);

    public static Point3D BasePoint
    {
        get { return basePoint; }
    }

    public override string ToString()
    {
        string result = "X: " + this.X + " Y: " + this.Y + " Z: " + this.Z;

        return result;

    }

   
}