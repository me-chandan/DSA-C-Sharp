namespace StateDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new TrafficLightContext();
            context.Change(); // Red
            context.Change(); // Green
            context.Change(); // Yellow
        }
    }
}
