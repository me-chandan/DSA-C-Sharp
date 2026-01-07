namespace CourseSchedule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] prerequisites = { new int[] { 1, 0 } };
            int numCourses = 2;

            bool result = CanFinish_BFS.CanFinish2(numCourses, prerequisites);
            Console.WriteLine(result);
        }
    }
}