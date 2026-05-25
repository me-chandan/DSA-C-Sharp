namespace ThreadSafeBoundedQueueDemo
{
    /*Implement a thread-safe bounded blocking queue that has the following methods: 
     * • BoundedBlockingQueue(int capacity) The constructor initializes the queue with a maximum capacity. 
     * • void enqueue(int element) Adds an element to the front of the queue. 
     * If the queue is full, the calling thread is blocked until the queue is no longer full. 
     * • int dequeue() Returns the element at the rear of the queue and removes it. 
     * If the queue is empty, the calling thread is blocked until the queue is no longer empty. 
     * • int size() Returns the number of elements currently in the queue. 
     * Your implementation will be tested using multiple threads at the same time. 
     * Each thread will either be a producer thread that only makes calls to the enqueue method or a consumer thread 
     * that only makes calls to the dequeue method. The size method will be called after every test case.*/
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*
                INPUT FORMAT

                Example:

                Capacity = 2

                Operations:
                ["enqueue","dequeue","dequeue","enqueue","enqueue","enqueue","enqueue","dequeue"]

                Values:
                [1,null,null,0,2,3,4,null]

                NOTE:
                dequeue has no input value
            */

            int capacity = 2;

            string[] operations =
            {
                "enqueue",
                "dequeue",
                "dequeue",
                "enqueue",
                "enqueue",
                "enqueue",
                "enqueue",
                "dequeue"
            };

            int?[] values =
            {
                1,
                null,
                null,
                0,
                2,
                3,
                4,
                null
            };

            // Your already created queue class
            var queue = new BoundedBlockingQueue(capacity);

            // Store all running tasks
            List<Task> tasks = new List<Task>();

            /*
                Process operations dynamically
            */
            for (int i = 0; i < operations.Length; i++)
            {
                string operation = operations[i];

                if (operation == "enqueue")
                {
                    int value = values[i].Value;

                    /*
                        Create producer task dynamically
                    */
                    tasks.Add(Task.Run(async () =>
                    {
                        Console.WriteLine(
                            $"[PRODUCER] Trying to enqueue {value}"
                        );

                        await queue.Enqueue(value);

                        Console.WriteLine(
                            $"[PRODUCER] Enqueued {value}"
                        );
                    }));
                }
                else if (operation == "dequeue")
                {
                    /*
                        Create consumer task dynamically
                    */
                    tasks.Add(Task.Run(async () =>
                    {
                        Console.WriteLine(
                            $"[CONSUMER] Trying to dequeue"
                        );

                        int item = await queue.Dequeue();

                        Console.WriteLine(
                            $"[CONSUMER] Dequeued {item}"
                        );
                    }));
                }

                /*
                    Small delay added only to make
                    execution flow easier to observe.

                    Remove this in real interview solution.
                */
                await Task.Delay(300);
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);

            Console.WriteLine();
            Console.WriteLine($"Final Queue Size = {queue.GetSize()}");

            Console.WriteLine();
            Console.WriteLine("Execution Completed");

            Console.ReadLine();
        }
    }
}
