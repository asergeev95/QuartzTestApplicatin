using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace WebHost.Jobs
{
    [UsedImplicitly]
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private static IScheduler Scheduler { get; set; }

        public QuartzHostedService(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            await ConfigureSimpleJob();
            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            // ReSharper disable once PossibleNullReferenceException
            await Scheduler?.Shutdown(cancellationToken);
            Scheduler = null;
        }
       
        private async Task ConfigureSimpleJob()
        {
            var trigger = TriggerBuilder.Create()
                .WithIdentity(nameof(SimpleJob))
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).RepeatForever())
                .Build();
            var job = JobBuilder.Create<SimpleJob>().WithIdentity(nameof(SimpleJob)).Build();
            await Scheduler.ScheduleJob(job, trigger);
        }
    }
}
