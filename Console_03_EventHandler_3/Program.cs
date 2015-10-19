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

namespace Console_03_EventHandler_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            HighwayPatrol highwayPolice = new HighwayPatrol();

            // Wiring the event handler of the listener to the event
            car.CarSpeedChanged += highwayPolice.HandleWhenExceedSpeed;

            car.Speed = 100; // Raise the event
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
            car.Speed = 110; // Raise the event again

            System.Console.ReadKey();
        }
    }

    // Event publisher
    class Car
    {
        public EventHandler<CarExceedSpeedEventArgs> CarSpeedChanged;

        private int speed;

        public int Speed
        {
            get { return this.speed; }
            set
            {
                this.speed = value;

                // Raise event when car exceeds a certain speed
                if (value > 60)
                {
                    if (this.CarSpeedChanged != null)
                        CarSpeedChanged(this, new CarExceedSpeedEventArgs());
                }
            }
        }
    }

    // Event listener
    class HighwayPatrol
    {
        // Event handler
        public void HandleWhenExceedSpeed(object sender, CarExceedSpeedEventArgs e)
        {
            System.Console.WriteLine("{1} : You are driving at {0}. Slow down!", ((Car)sender).Speed, e.WhenViolate);
        }
    }

    class CarExceedSpeedEventArgs : EventArgs
    {
        private DateTime whenViolate;

        public CarExceedSpeedEventArgs()
        {
            this.whenViolate = DateTime.Now;
        }

        public DateTime WhenViolate
        {
            get { return whenViolate; }
        }
    }
}
