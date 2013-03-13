using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum BatteryType
{
    LiIon, NiMH, NiCd
}

public class Battery
{
    
    private string model;
    private int? hoursIddle;
    private int? hoursTalk;
    private BatteryType type;

    public string Model
    {
        get { return this.model; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Model cannot be empty");
            }

            this.model = value;
        }

    }

    public int? HoursIddle
    {
        get { return this.hoursIddle; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hours idlle must be positive number");
            }

            this.hoursIddle = value;
        }
    }

    public int? HoursTalk
    {
        get { return this.hoursTalk; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hours talk must be positive number");
            }

            this.hoursTalk = value;
        }
    }

    public Battery()
    {

    }

    public Battery(string model)
    {
        this.model = model;
    }

    public Battery(string model, BatteryType batteryType) 
        : this(model)
    {
        this.type = batteryType;
    }


    public Battery(string model, BatteryType batteryType, int? hoursIddle)
        : this(model, batteryType)
    {
        this.hoursIddle = hoursIddle;
    }

    public Battery(string model, BatteryType batteryType, int? hoursIddle, int? hoursTalk)
        : this(model, batteryType, hoursIddle)
    {
        this.hoursTalk = hoursTalk;
    }
}

