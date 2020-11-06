using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Quartz;

namespace WebHost.Jobs
{
    [UsedImplicitly]
    [DisallowConcurrentExecution]
    public class SimpleJob  : IJob
    {
        private readonly IDataService _dataService;

        public SimpleJob(IDataService dataService)
        {
            _dataService = dataService;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var data = _dataService.GetData(context.FireTimeUtc);
            Console.WriteLine($"Received data: {data.First().AccountId} at {context.FireTimeUtc}");
            return Task.CompletedTask;
        }
    }
}