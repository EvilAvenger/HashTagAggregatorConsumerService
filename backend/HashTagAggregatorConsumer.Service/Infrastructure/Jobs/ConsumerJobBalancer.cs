using System;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Service.Contracts;
using HashtagAggregatorConsumer.Contracts;
using HashtagAggregatorConsumer.Contracts.Interface;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;
using HashtagAggregatorConsumer.Data.Result;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Jobs
{
    public class ConsumerJobBalancer : IConsumerJobBalancer
    {
        private readonly IStorageAccessor accessor;
        private readonly IConsumerJobManager jobManager;

        public ConsumerJobBalancer(IStorageAccessor accessor,
            IConsumerJobManager jobManager)
        {
            this.accessor = accessor;
            this.jobManager = jobManager;
        }

        public ICommandResult TryCreateJob(string name, int interval)
        {
            var isAdded = new CommandResult();
            var qName = new QueueParams(name);
            var initTask = new ConsumerJobTask(qName, interval);
            jobManager.AddJob(initTask);
            return isAdded;
        }

        public void DeleteJob(string name)
        {
            var qName = new QueueParams(name);
            var task = new ConsumerJobTask(qName, 0);
            jobManager.DeleteJob(task);
        }
    }
}