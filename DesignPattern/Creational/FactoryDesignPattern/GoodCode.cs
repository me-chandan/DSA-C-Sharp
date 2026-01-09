namespace FactoryDesignPattern
{
    public class GoodCode
    {
        public static void Demo()
        {
            IVehicle car = VehicleFactory.CreateVehicle(VehicleType.CAR);
            car.Start();
            car.Stop();
            IVehicle truck = VehicleFactory.CreateVehicle(VehicleType.TRUCK);
            truck.Start();
            truck.Stop();
        }
    }
}
