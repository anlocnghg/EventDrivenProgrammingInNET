/*
 * Event-driven Programming in .NET
 * Learn delegate-event by simplest examples
 * Article URL: http://www.codeproject.com/Articles/1008553/Event-Driven-Programing-in-NET
 * 
 * By: Lộc Nguyễn
 * URL: http://locnguyen.us/
 * Email: loc.nguyen.st.louis[at]Gmail[dot]com
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_02_EventSimple
{
    delegate void CarSpeedChangedHandler(string s);
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            HighwayPatrol highwayPolice = new HighwayPatrol();

            // Wire the event handler to the event
            car.CarSpeedChanged += highwayPolice.HandleWhenExceedSpeed;

            car.SetSpeed(70); // Raise the event

            System.Console.ReadKey();
        }
    }


    // Publisher
    class Car
    {
        // !! event in .NET is type of delegate !!
        public event CarSpeedChangedHandler CarSpeedChanged;

        // Raise event when car exceeds a certain speed (60 mph)
        public void SetSpeed(int speed)
        {
            if (speed > 60)
            {
                // Check if there exists a listener subscribed to the event
                if (this.CarSpeedChanged != null)
                    CarSpeedChanged("You're driving at " + speed + " . Slow down!");
            }
        }
    }

    // Listener
    class HighwayPatrol
    {
        // Event handler
        public void HandleWhenExceedSpeed(string s)
        {
            System.Console.WriteLine(s);
        }
    }
}
