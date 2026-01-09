using AbstractFactory;
using CommonCode;

namespace FactoryDesignPattern
{
    public class GoodCode
    {
        public static void Demo()
        {
            IVehicleFactory hondaFactory = new HondaFactory();
            IVehicle hondaCar = hondaFactory.CreateVehicle();
            hondaCar.Start();
            hondaCar.Stop();

            IVehicleFactory toyotaFactory = new ToyotaFactory();
            IVehicle toyotaCar = toyotaFactory.CreateVehicle();
            toyotaCar.Start();
            toyotaCar.Stop();

            IVehicleFactory bmwFactory = new BMWFactory();
            IVehicle bmwCar = bmwFactory.CreateVehicle();
            bmwCar.Start();
            bmwCar.Stop();

        }
    }
}
