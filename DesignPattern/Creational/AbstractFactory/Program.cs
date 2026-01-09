using FactoryDesignPattern;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BadCode.Demo();
            Console.WriteLine();
            BadCode.Demo2();
            Console.WriteLine();
            BadCode.Demo3();
            Console.WriteLine();
            GoodCode.Demo();
        }
    }
}
