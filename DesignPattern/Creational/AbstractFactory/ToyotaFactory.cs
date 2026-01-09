using AbstractFactory;
using CommonCode;

namespace FactoryDesignPattern
{
    public class ToyotaFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Toyota();
        }
    }
}
