using FactoryDesignPattern;

namespace AbstractFactory
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle();
    }
}
