namespace CourseSchedule2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] prerequisites = { new int[] { 1, 0 } };
            int numCourses = 2;

            var result = FindOrder(numCourses, prerequisites);
            Console.WriteLine(string.Join(',', result));

            //Time: O(V + E)
            //Space: O(V + E)
            // V - vertices (numCourses), E - edges (prerequisites.Length)
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            //create adjacency list, indegree
            List<int>[] graph = new List<int>[numCourses];
            int[] indegree = new int[numCourses];

            for(int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var item in prerequisites)
            {
                int course = item[0];
                int prereq = item[1];
                indegree[course]++;
                graph[prereq].Add(course);
            }
            //prepare Queue as it is BFS to store elements that have indegree 0
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int[] result = new int[numCourses];
            int r = 0;

            while (queue.Count > 0)
            {
                var prereq = queue.Dequeue();
                result[r++] = prereq;

                foreach (var course in graph[prereq])
                {
                    indegree[course]--;
                    if (indegree[course] == 0)
                    {
                        queue.Enqueue(course);
                    }
                }
            }

            if (r == numCourses)
            {
                return result;
            }
            else
            {
                return new int[] { };
            }
        }
    }
}
