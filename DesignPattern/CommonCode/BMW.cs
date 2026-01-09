using FactoryDesignPattern;

namespace CommonCode
{
    public class BMW : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("BMW Started");
        }

        public void Stop()
        {
            Console.WriteLine("BMW Stopped");
        }
    }
}
