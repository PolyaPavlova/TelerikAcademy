using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Main
{
    static void Main()
    {

        // Create an instance of CellPhone class
        CellPhone first = new CellPhone("5800", "Nokia");

        // Create an array of CellPhone objects
        CellPhone[] phones = {
                    new CellPhone("5700", "Nokia"),
                    new CellPhone("5200", "Samsung")
             };

        // Printing them using ToString
        foreach (var phone in phones)
        {
            Console.WriteLine(phone);
        }

        // Printing static CellPhone
        Console.WriteLine(CellPhone.IPhone4S);        

        // AddCall to fill CallHistory    
        first.AddCall(DateTime.Now, "555", 526);
   
        first.AddCall(DateTime.Parse("5/5/2012"), "08952626", 30);
        first.AddCall(DateTime.Parse("2/5/2012"), "08954626", 30);
        first.AddCall(DateTime.Parse("4/5/2012"), "08552626", 60);

        // Printing calls
        foreach (var item in first.CallHistory)
        {
            Console.WriteLine(item.DateTimeCall);
        }

        // Creating instance of Battery
        Battery bat = new Battery("Model", BatteryType.LiIon);


        CellPhone myNokia = new CellPhone("5800", "Nokia", 200, "Ralitsa");

        // Printing myNoki
        Console.WriteLine(myNokia);
        
      
        
    }
}

