namespace ThreadSafeBoundedQueueDemo
{
    internal class BoundedBlockingQueue
    {
        int _capacity;
        private readonly Queue<int> _boundedQueue;

        private readonly SemaphoreSlim _emptySlots;
        private readonly SemaphoreSlim _filledSlots;
        private readonly object _queueLock = new object();

        public BoundedBlockingQueue(int capacity)
        {
            _capacity = capacity;
            this._boundedQueue = new Queue<int>(capacity);
            _emptySlots = new SemaphoreSlim(capacity);
            _filledSlots = new SemaphoreSlim(0);
        }

        public async Task Enqueue(int element)
        {
            // If queue is full, block the calling thread until space is available
            await _emptySlots.WaitAsync();
            lock(_queueLock) {
                _boundedQueue.Enqueue(element);
            }
            _filledSlots.Release();
        }

        public async Task<int> Dequeue()
        {
            // If queue is empty, block the calling thread until an element is available
            await _filledSlots.WaitAsync();
            int element;
            lock (_queueLock)
            {
                element = _boundedQueue.Dequeue();
            }
            _emptySlots.Release();
            return element;
        }

        public int GetSize()
        {
            // Return the number of elements currently in the queue
            lock(_queueLock)
            {
                return _boundedQueue.Count;
            }
        }
    }
}
