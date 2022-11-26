using System;
using System.Collections.Generic;
using Core.Patterns.Creational;

namespace Core.Threading
{
    public class MainThreadDispatcher : Singleton<MainThreadDispatcher>
    {
        private static readonly Queue<Action> ExecutionQueue = new Queue<Action>();

        private void Update()
        {
            ProcessExecutionQueue();
        }

        private static void ProcessExecutionQueue()
        {
            lock (ExecutionQueue)
            {
                while (ExecutionQueue.Count > 0)
                {
                    ExecutionQueue.Dequeue()?.Invoke();
                }
            }
        }

        public void Dispatch(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            ExecutionQueue.Enqueue(action);
        }

        private void OnDestroy()
        {
            DestroySafely();
        }

        private void DestroySafely()
        {
            ExecutionQueue.Clear();
        }
    }
}