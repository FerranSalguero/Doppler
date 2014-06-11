using System.Threading;
using System.Collections.Generic;
using System;
public sealed class RetrieverPool : IDisposable
{
    private Semaphore _workWaiting;
    private Queue<WaitQueueItem> _queue;
    private List<Thread> _threads;

    public RetrieverPool(int numThreads)
    {
        if (numThreads <= 0)
            throw new ArgumentOutOfRangeException("numThreads");

        _threads = new List<Thread>(numThreads);
        _queue = new Queue<WaitQueueItem>();
        _workWaiting = new Semaphore(0, int.MaxValue);

        for (int i = 0; i < numThreads; i++)
        {
            Thread t = new Thread(Run);
            t.IsBackground = true;
            _threads.Add(t);
            t.Start();
        }
    }

    public void SetMaxThreads(int numThreads)
    {
        if (numThreads <= 0)
            throw new ArgumentOutOfRangeException("numThreads");

        _threads = new List<Thread>(numThreads);
        _queue = new Queue<WaitQueueItem>();
        _workWaiting = new Semaphore(0, int.MaxValue);

        for (int i = 0; i < numThreads; i++)
        {
            Thread t = new Thread(Run);
            t.IsBackground = true;
            _threads.Add(t);
            t.Start();
        }
    }

    public int ActiveThreads()
    {
        return _threads.Count;
    }

    public int WaitinginQueue()
    {
        return _queue.Count;
    }

    public void AbortAll()
    {
        // clear the queue
        _queue.Clear();
        // loop through the existing ones and abort them
        foreach (Thread thread in _threads)
        {
            thread.Abort();
        }
    }

    public void Dispose()
    {
        if (_threads != null)
        {
            _threads.ForEach(delegate(Thread t) { t.Interrupt(); });
            _threads = null;
        }
    }

    public void QueueUserWorkItem(WaitCallback callback, object state)
    {
        if (_threads == null)
            throw new ObjectDisposedException(GetType().Name);
        if (callback == null) throw new ArgumentNullException("callback");

        WaitQueueItem item = new WaitQueueItem();
        item.Callback = callback;
        item.State = state;
        item.Context = ExecutionContext.Capture();

        lock (_queue) _queue.Enqueue(item);
        _workWaiting.Release();
    }

    private void Run()
    {
        try
        {
            while (true)
            {
                _workWaiting.WaitOne();
                WaitQueueItem item;
                lock (_queue) item = _queue.Dequeue();
                ExecutionContext.Run(item.Context,
                    new ContextCallback(item.Callback), item.State);
            }
        }
        catch (ThreadInterruptedException) { }
    }

    private class WaitQueueItem
    {
        public WaitCallback Callback;
        public object State;
        public ExecutionContext Context;
    }
}