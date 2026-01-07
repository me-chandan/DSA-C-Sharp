namespace CourseSchedule
{
    public static class CanFinish_BFS
    {
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int[] visited = new int[numCourses];
            Array.Fill(visited, 0);

            List<List<int>> adj = new List<List<int>>();

            for (int i = 0; i < numCourses; i++)
            {
                adj.Add(new List<int>());
            }

            foreach (int[] item in prerequisites)
            {
                adj[item[0]].Add(item[1]);
            }

            int[] indegree = new int[numCourses];
            Array.Fill(indegree, 0);

            foreach (List<int> item in adj)
            {
                foreach (int node in item)
                {
                    indegree[node]++;
                }
            }
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                    queue.Enqueue(i);
            }

            while (queue.Count != 0)
            {
                int u = queue.Dequeue();

                if (adj[u].Count > 0)
                {
                    foreach (int next in adj[u])
                    {
                        indegree[next]--;

                        if (indegree[next] == 0)
                            queue.Enqueue(next);
                    }
                }
            }

            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] != 0)
                    return false;
            }

            return true;
        }

        public static bool CanFinish2(int numCourses, int[][] prerequisites)
        {
            List<int>[] graph = new List<int>[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            int[] indegree = new int[numCourses];

            foreach (var p in prerequisites)
            {
                int course = p[0];
                int prereq = p[1];
                graph[prereq].Add(course);
                indegree[course]++;
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            int completed = 0;

            while (queue.Count > 0)
            {
                var course = queue.Dequeue();
                completed++;

                foreach (var item in graph[course])
                {
                    indegree[item]--;

                    if (indegree[item] == 0)
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return completed == numCourses;
        }
    }
}
