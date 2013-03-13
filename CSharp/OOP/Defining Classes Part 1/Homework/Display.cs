using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Display
{
    private int? size;
    private int? colorsNum;

    public int? Size
    {
        get { return this.size; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Size must be positive number");
            }

            this.size = value;
        }
    }

    public int? ColorsNum
    {
        get { return this.colorsNum; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Colors numbr must be positive number");
            }

            this.colorsNum = value;
        }

    }
}

