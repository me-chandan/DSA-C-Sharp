namespace StateDesignPattern
{
    internal class TrafficLightContext
    {
        ITrafficLightState _currentState;
        public TrafficLightContext()
        {
            _currentState = new RedState();
        }

        public void SetState(ITrafficLightState state)
        {
            _currentState = state;
        }

        public string GetColor()
        {
            return _currentState.GetColor();
        }

        public void Change()
        {
            _currentState.Next(this);
        }
    }
}
