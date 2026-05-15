namespace ZeroEvenOddProblem
{
    internal class ZeroEvenOdd
    {
        // Maximum number till which numbers should print
        // Example: n = 5
        // Expected Output:
        // 0 1 0 2 0 3 0 4 0 5
        private int n;

        // Shared current number
        // Starts from 1
        private int current = 1;

        /*
            Semaphore Meaning:

            Semaphore count = permission count

            If count > 0:
                thread can continue

            If count == 0:
                thread waits/blocks
        */

        // Initially set to 1
        // Means Zero thread can start immediately
        private SemaphoreSlim semZero = new SemaphoreSlim(1);

        // Initially set to 0
        // Means Odd thread must wait initially
        private SemaphoreSlim semOdd = new SemaphoreSlim(0);

        // Initially set to 0
        // Means Even thread must wait initially
        private SemaphoreSlim semEven = new SemaphoreSlim(0);

        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }

        /*
            ZERO THREAD

            Responsibility:
            Print 0 before every number

            Flow:
            Zero prints 0
                ↓
            Decide whether Odd or Even should run
                ↓
            Wake Odd/Even thread using Release()
        */
        public async Task Zero()
        {
            // Runs n times because:
            // For every number we need one zero before it
            for (int i = 0; i < n; i++)
            {
                /*
                    Wait until Zero thread gets permission.

                    Initially semZero count = 1
                    So first iteration proceeds immediately.

                    After WaitAsync():
                    semaphore count decreases by 1
                */
                await semZero.WaitAsync();

                // Print zero
                Console.Write("0 ");

                /*
                    Decide who should print next.

                    If current number is odd:
                        Wake Odd thread

                    Else:
                        Wake Even thread
                */
                if (current % 2 == 1)
                {
                    // Give permission to Odd thread
                    semOdd.Release();
                }
                else
                {
                    // Give permission to Even thread
                    semEven.Release();
                }
            }
        }

        /*
            ODD THREAD

            Responsibility:
            Print only odd numbers

            Example:
            1 3 5 ...
        */
        public async Task Odd()
        {
            // Loop only for odd numbers
            for (int i = 1; i <= n; i += 2)
            {
                /*
                    Wait until Zero thread signals Odd thread.

                    Initially semOdd count = 0
                    So Odd thread blocks here initially.

                    Zero thread later calls:
                        semOdd.Release()

                    Then this thread wakes up.
                */
                await semOdd.WaitAsync();

                // Print current odd number
                Console.Write(current + " ");

                // Move to next number
                current++;

                /*
                    Very Important

                    After Odd finishes,
                    allow Zero thread to continue again.

                    Otherwise Zero thread remains blocked forever.
                */
                semZero.Release();
            }
        }

        /*
            EVEN THREAD

            Responsibility:
            Print only even numbers

            Example:
            2 4 6 ...
        */
        public async Task Even()
        {
            // Loop only for even numbers
            for (int i = 2; i <= n; i += 2)
            {
                /*
                    Wait until Zero thread signals Even thread.

                    Initially semEven count = 0
                    So Even thread blocks initially.

                    Zero thread later calls:
                        semEven.Release()

                    Then Even thread wakes up.
                */
                await semEven.WaitAsync();

                // Print current even number
                Console.Write(current + " ");

                // Move to next number
                current++;

                /*
                    After Even finishes,
                    wake Zero thread again.

                    This creates execution flow:

                    Zero -> Even -> Zero -> Even
                */
                semZero.Release();
            }
        }
    }
}