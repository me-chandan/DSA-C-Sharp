namespace FactoryDesignPattern
{
    public class Truck : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Truck Started");
        }
        public void Stop()
        {
            Console.WriteLine("Truck Stopped");
        }
    }
}
