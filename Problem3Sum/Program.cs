namespace Problem3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-1,0,1,2,-1,-4};
            ThreeSum threeSum = new ThreeSum();
            var result = threeSum.GetThreeSum(nums);
            foreach (var triplet in result)
            {
                Console.WriteLine("[" + string.Join(", ", triplet) + "]");
            }
        }
    }
}
