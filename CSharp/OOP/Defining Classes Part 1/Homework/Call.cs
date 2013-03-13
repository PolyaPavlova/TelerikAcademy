using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Call
{
    private DateTime dateTimeCall;
    private string dialed;
    private int duration;
   
    public DateTime DateTimeCall
    {
        get { return this.dateTimeCall; }
        set { this.dateTimeCall = value; }
    }

    public string Dialed
    {
        get { return this.dialed; }
        set { this.dialed = value; }
    }

    public int Duration
    {
        get { return this.duration; }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Duration must be at least 0 seconds");
            }
            else
            {
                this.duration = value;
            }
        }
    }

 
    public Call (DateTime dateTimeCall, string dialed, int duration)
    {
        this.dateTimeCall = dateTimeCall;
        this.dialed = dialed;
        this.duration = duration;
    }
}

