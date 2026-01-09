using FactoryDesignPattern;

namespace CommonCode
{
    public class Toyota : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Toyota Started");
        }

        public void Stop()
        {
            Console.WriteLine("Toyota Stopped");
        }
    }
}
