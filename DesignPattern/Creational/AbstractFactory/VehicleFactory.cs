using CommonCode;

namespace FactoryDesignPattern
{
    public class VehicleFactory
    {
        public static IVehicle CreateVehicle(VehicleBrand brand)
        {
            return brand switch
            {
                VehicleBrand.BMW => new BMW(),
                VehicleBrand.Honda => new Honda(),
                VehicleBrand.Toyota => new Toyota(),
                _ => throw new ArgumentException("Invalid vehicle brand"),
            };
        }

        /*
         * Here , the problem is if there are more brands of CAR, Truck or ther vehicles, we need to modify this factory class again and again.
         * to solve this problem, we can use Abstract Factory Pattern.         
         */
    }
}
