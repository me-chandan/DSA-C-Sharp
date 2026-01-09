using FactoryDesignPattern;

namespace CommonCode
{
    public class Honda : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Honda Started");
        }

        public void Stop()
        {
            Console.WriteLine("Honda Stopped");
        }
    }
}
