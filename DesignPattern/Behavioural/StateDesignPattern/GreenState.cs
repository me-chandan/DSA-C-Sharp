namespace StateDesignPattern
{
    internal class GreenState : ITrafficLightState
    {
        private string _colour;
        public GreenState()
        {
            _colour = "GREEN";
        }
        public string GetColor()
        {
            return this._colour;
        }
        public void Next(TrafficLightContext context)
        {
            //display 5 seconds timer
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Yellow light will be on in {5 - i} seconds...");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Changed from Green to Yellow...");
            context.SetState(new YellowState());
        }
    }
}
