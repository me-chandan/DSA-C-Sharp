namespace FactoryDesignPattern
{
    public class VehicleFactory
    {
        public static IVehicle CreateVehicle(VehicleType vehicleType)
        {
            return vehicleType switch
            {
                VehicleType.CAR => new Car(),
                VehicleType.TRUCK => new Truck(),
                _ => throw new ArgumentException("Invalid vehicle type"),
            };
        }
    }
}
