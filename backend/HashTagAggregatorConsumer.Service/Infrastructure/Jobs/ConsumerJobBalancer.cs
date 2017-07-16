using System;
using System.Linq;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Service.Contracts;
using HashtagAggregatorConsumer.Contracts;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;
using HashtagAggregatorConsumer.Contracts.Settings;
using HashtagAggregatorConsumer.Data.Result;
using Microsoft.Extensions.Options;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Jobs
{
    public class ConsumerJobBalancer : IConsumerJobBalancer
    {
        private readonly IStorageAccessor accessor;
        private readonly IConsumerJobManager jobManager;
        private readonly IOptions<HangfireSettings> hangfireOptions;

        public ConsumerJobBalancer(IStorageAccessor accessor,
            IConsumerJobManager jobManager,
            IOptions<HangfireSettings> hangfireOptions)
        {
            this.accessor = accessor;
            this.jobManager = jobManager;
            this.hangfireOptions = hangfireOptions;
        }

        public ICommandResult TryCreateJob(string name, int interval)
        {
            CommandResult isAdded = new CommandResult();
            var qName = new QueueParams(name, hangfireOptions.Value.ServerName);
            var initTask = new ConsumerJobTask(qName, interval);
            if (!CheckJobLimitExceeded(initTask))
            {
                jobManager.AddJob(initTask);
                isAdded.Success = true;
                isAdded.Message = "Consumer created";
            }
            else
            {
                isAdded.Message = "Job Limit Exceeded";
            }
            return isAdded;
        }

        public ICommandResult DeleteJob(string name)
        {
            var queueParams = new QueueParams(name, hangfireOptions.Value.ServerName);
            var task = new ConsumerJobTask(queueParams, 0);
            return jobManager.DeleteJob(task);
        }

        private bool CheckJobLimitExceeded(IConsumerJobTask task)
        {
            var list = accessor.GetJobsList();
            var isValid = list.Any(x => x.Id.Equals(task.JobId));
            return isValid;
        }
    }
}