using System;
using System.Threading;
using FluentScheduler;

namespace DockerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            JobManager.JobException += JobManager_JobException;

            var registry = new Registry();

            // Run every 5 minutes
            registry.Schedule<MyFiveMinutesTask>().ToRunNow().AndEvery(5).Minutes();

            // It will run every day at 2 am
            registry.Schedule<MyDailyTask>().ToRunEvery(1).Days().At(2, 0);

            JobManager.Initialize(registry);


            Thread.Sleep(Timeout.Infinite);
        }

        private static void JobManager_JobException(JobExceptionInfo obj)
        {
            // Log Errors 
        }
    }

    public class MyFiveMinutesTask : IJob
    {
        public void Execute()
        {
            // Do something usefull
        }
    }


    public class MyDailyTask : IJob
    {
        public void Execute()
        {
            // Do something usefull
        }
    }
}
