using System.Text;

namespace ZeroEvenOddProblem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //int n = 5;
            //var str = GetZeroEvenOddString(n);
            //Console.WriteLine($"Hello, World! {str}");

            int n = 5;
            var obj = new ZeroEvenOdd(n);

            var t1 = obj.Zero();
            var t2 = obj.Odd();
            var t3 = obj.Even();

            await Task.WhenAll(t1, t2, t3);
        }

        static string GetZeroEvenOddString(int n)
        {
            StringBuilder str = new StringBuilder();
            bool isZeroRequired = true;
            int count = 1;
            int i = 1;

            while(str.Length < (2*n))
            {
                if (isZeroRequired)
                {
                    str.Append("0");
                    isZeroRequired = false;
                }
                else
                {
                    str.Append(count.ToString());
                    count++;
                    isZeroRequired = true;
                }
                i++;
            }

            return str.ToString();
        }


    }
}
