using System;
using System.Threading.Tasks;
using Hangfire;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregatorConsumer.Contracts;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;
using HashtagAggregatorConsumer.Data.CQRS;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Jobs
{
    public class RecurringJobManager : IConsumerJobManager
    {
        private readonly IConsumberJob job;

        public RecurringJobManager(IConsumberJob job)
        {
            this.job = job;
        }

        public ICommandResult AddJob(IConsumerJobTask task)
        {
            RecurringJob.AddOrUpdate<IConsumberJob>(
                task.JobId,
                x => x.Execute((ConsumerJobTask) task),
                Cron.MinuteInterval(task.Interval));

            return new CommandResult {Success = true};
        }

        public ICommandResult DeleteJob(IConsumerJobTask task)
        {
            RecurringJob.RemoveIfExists(task.JobId);
            return new CommandResult {Success = true};
        }

        public async Task<ICommandResult> StartNow(IConsumerJobTask task)
        {
            return await job.Execute((ConsumerJobTask) task);
        }

        public ICommandResult ReconfigureJob(IConsumerJobTask task)
        {
            throw new NotImplementedException();
        }
    }
}