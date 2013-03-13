using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Program
    {
        static void DoSomething()
        {
            Console.WriteLine("Kolio teroristaaaa");
        }

        static void Main(string[] args)
        {
            TimerDelagate timerDelagate = DoSomething;

            Timer testTimer = new Timer(5, 5, timerDelagate);
            testTimer.Play(DoSomething);
                       
            

        }
    }
}
