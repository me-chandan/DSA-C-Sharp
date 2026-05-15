namespace SemaphoreDemo
{
    internal class Program
    {
        static SemaphoreSlim semaphore = new SemaphoreSlim(2);
        static int activeThreads = 0;

        static async Task Main()
        {
            var tasks = new Task[6];

            for (int i = 0; i < 6; i++)
            {
                int id = i;
                tasks[i] = Task.Run(() => AccessResource(id));
            }

            await Task.WhenAll(tasks);
        }

        static async Task AccessResource(int id)
        {
            Console.WriteLine($"[WAIT ] Thread {id + 1} waiting...");

            await semaphore.WaitAsync();    // try to enter the semaphore

            Interlocked.Increment(ref activeThreads);
            Console.WriteLine($"[ENTER] Thread {id + 1} entered | Active: {activeThreads}");

            try
            {
                await Task.Delay(2000);
            }
            finally
            {
                Interlocked.Decrement(ref activeThreads);
                Console.WriteLine($"[EXIT ] Thread {id + 1} leaving | Active: {activeThreads}");
                semaphore.Release();
            }
        }
    }
}
