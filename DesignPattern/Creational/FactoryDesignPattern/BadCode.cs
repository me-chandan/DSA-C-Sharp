namespace FactoryDesignPattern
{
    public class BadCode
    {
        public static void Demo()
        {
            Car car = new Car();
            car.Start();
            car.Stop();
            Truck truck = new Truck();
            truck.Start();
            truck.Stop();
        }

        public static void Demo2()
        {
            IVehicle? vehicle = null;
            var vehicleType = VehicleType.CAR; // This could come from user input or configuration
            if (vehicleType == VehicleType.CAR)
            {
                vehicle = new Car();
            }
            else if (vehicleType == VehicleType.TRUCK)
            {
                vehicle = new Truck();
            }
            else
            {
                throw new ArgumentException("Unknown vehicle type");
            }
                
            vehicle?.Start();
            vehicle?.Stop();
        }
    }
}

/* In this BadCode example, the Demo method directly instantiates specific vehicle types (Car and Truck).
 * Here, Demo method creates each vehicle explicitly by calling the constructor of the respective vehicle class. 
 * But what if we need to add more vehicle types later, or if we need to change the way vehicles are created?
 * 
 * Demo2 method uses conditional logic to determine which vehicle to create based on a string input.
 * This code is fragile. If we want to add another vehicle type, we need to modify this code again, which is error-prone and hard to maintain. 
 */