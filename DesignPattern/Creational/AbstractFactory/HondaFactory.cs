using AbstractFactory;
using CommonCode;

namespace FactoryDesignPattern
{
    public class HondaFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Honda();
        }
    }
}
