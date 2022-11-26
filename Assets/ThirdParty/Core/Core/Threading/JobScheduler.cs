using System;
using System.Collections.Generic;
using System.Threading;

namespace Core.Threading
{
    public class JobScheduler : IDisposable
    {
        private readonly Queue<Action> _scheduledJobs;

        private Thread _jobThread;

        public bool isEnabled;

        public int threadSleepTime;

        public JobScheduler(bool activateOnStart = false)
        {
            _scheduledJobs = new Queue<Action>();

            threadSleepTime = 10;

            isEnabled = true;
            
            StartProcessingJobs();
        }

        private void StartProcessingJobs()
        {
            _jobThread = new Thread(ExecuteScheduledJobs);
            _jobThread.Start();
        }

        public void ScheduleJob(Action action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _scheduledJobs.Enqueue(action);
        }

        private void ExecuteScheduledJobs()
        {
            while (true)
            {
                if (!isEnabled)
                {
                    continue;
                }

                while (_scheduledJobs.Count > 0)
                {
                    _scheduledJobs.Dequeue()?.Invoke();
                }

                Thread.Sleep(threadSleepTime);
            }
        }

        public void Dispose()
        {
            _scheduledJobs.Clear();
            _jobThread.Abort();

            GC.SuppressFinalize(this);
        }
    }
}