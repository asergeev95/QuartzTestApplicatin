using System;
using System.Threading.Tasks;
using Quartz;

namespace WebHost.Jobs
{
    public class SimpleJob  : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Hello from simple job {context.FireTimeUtc}");
            return Task.CompletedTask;
        }
    }
}