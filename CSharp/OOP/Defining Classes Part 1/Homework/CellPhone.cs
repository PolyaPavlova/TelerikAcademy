using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CellPhone
{
    private string model;
    private string manufacturer;
    private int? price;
    private string owner;
    private List<Call> callHistory = new List<Call>();
    public Battery battery = new Battery();
    private Display display = new Display();

    /*********************************
     *          PROPERTIES          *
     ********************************/

    public string Model
    {
        get { return this.model; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Model cannot be emty!");
            }
            this.model = value;
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Manufacturer cannot be empty");
            }
            this.manufacturer = value;
        }
    }


    public int? Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price must be positive number");
            }

            this.price = value;
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Owner's name cannot be empty");
            }

            this.owner = value;
        }
    }

      
    public List<Call> CallHistory
    {
        get { return this.callHistory; }
        set { this.callHistory = value; } 
        
    }

    private static CellPhone iPhone4S = new CellPhone("iPhone4S", "Apple");

    public static CellPhone IPhone4S
    {
        get { return iPhone4S; }

    }

    /***********************************
     *          CONSTRUCTORS           *
     ***********************************/

    public CellPhone(string model, string manufacturer)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
       
    }

    public CellPhone(string model, string manufacturer, int price)
        : this(model, manufacturer)
    {
        this.Price = price;
        
    }

    public CellPhone(string model, string manufacturer, int price, string owner)
        : this(model, manufacturer, price)
    {

        this.Owner = owner;
    }

    public CellPhone(string model, string manufacturer, int price, string owner, Battery battery) : 
        this(model, manufacturer, price, owner) 
    {
        this.battery = battery;
    }




    /***********************
     *      METHODS        *
     **********************/

    public override string ToString()
    {
       
        string modelStr = "Model: " + this.model;
        string manufacturerStr = "Manufacturer: " + this.manufacturer;
        string priceStr = string.Empty;
        string ownerStr = string.Empty;

        // If the used constructor contains price
        if (this.price != null)
        {
            priceStr = "Price: " + this.price + "\n";    
        }

        // If the used constructor contains owner
        if (this.owner != null)
        {
            ownerStr = "Owner: " + this.owner;    
        }
        

        string result = modelStr + "\n" + manufacturerStr + "\n" + priceStr + ownerStr;
        return result;
    }   

    
    public List<Call> AddCall(DateTime dateTimeCall, string dialed, int duration)
    {
        Call currCall = new Call(dateTimeCall, dialed, duration);
        
       callHistory.Add(currCall);

        return callHistory;
    }

    public List<Call> DeleteCall(DateTime dateTimeCall, string dialed, int duration)
    {
        Call currCall = new Call(dateTimeCall, dialed, duration);

        if (callHistory.Contains(currCall) == true)
        {
            callHistory.Remove(currCall);
        }
        else
        {
            throw new Exception("There is no such call");
        }

        return callHistory;

    }

    public List<Call> ClearHistory(List<Call> callHistory)
    {
        callHistory.Clear();
        
        return callHistory;
    }


    public decimal CalculateBill(List<Call> callHistory, decimal pricePerMinute)
    {
        decimal wholeSeconds = 0;
        
        for (int i = 0; i < callHistory.Count; i++)
        {
            wholeSeconds += callHistory[i].Duration;
        }

        decimal bill = pricePerMinute * (decimal)Math.Ceiling(wholeSeconds / 60);

        return bill;
    }

}