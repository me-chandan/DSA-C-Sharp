namespace FactoryDesignPattern
{
    public class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Car Started");
        }
        public void Stop()
        {
            Console.WriteLine("Car Stopped");
        }
    }
}
