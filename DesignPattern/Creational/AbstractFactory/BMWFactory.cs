using AbstractFactory;
using CommonCode;

namespace FactoryDesignPattern
{
    public class BMWFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new BMW();
        }
    }
}
