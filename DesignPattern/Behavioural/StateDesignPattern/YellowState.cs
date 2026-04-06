namespace StateDesignPattern
{
    internal class YellowState : ITrafficLightState
    {
        private string _colour;

        public YellowState()
        {
            this._colour = "YELLOW";
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
                Console.WriteLine($"Red light will be on in {i} seconds...");
                System.Threading.Thread.Sleep(1000); // Simulate waiting for 1 second
            }
            Console.WriteLine("Changed from Yellow to Red...");
            context.SetState(new RedState());
        }
    }
}
