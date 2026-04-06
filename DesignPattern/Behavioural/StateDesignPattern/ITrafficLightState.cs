namespace StateDesignPattern
{
    internal interface ITrafficLightState
    {
        void Next(TrafficLightContext context);
        string GetColor();
    }
}
