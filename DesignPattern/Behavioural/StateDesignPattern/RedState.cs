using System;
using System.Collections.Generic;
using System.Text;

namespace StateDesignPattern
{
    internal class RedState : ITrafficLightState
    {
        private string _colour;

        public RedState()
        {
            this._colour = "RED";
        }
        public string GetColor()
        {
            return _colour;
        }

        public void Next(TrafficLightContext context)
        {
            //display 5 seconds timer
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"Green light will be on in {i} seconds...");
                System.Threading.Thread.Sleep(1000); // Simulate waiting for 1 second
            }
            Console.WriteLine("Changed from Red to Green...");
            context.SetState(new GreenState());
        }
    }
}
