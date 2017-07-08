using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregatorConsumer.Contracts;
using HashtagAggregatorConsumer.Contracts.Interface;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;
using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using Microsoft.Extensions.Logging;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Jobs
{
    public class ConsumerJob : IConsumberJob
    {
        private readonly IQueueConsumer queue;
        private readonly IMessageSaverFactory factory;
        private readonly ILogger<ConsumerJob> logger;

        public ConsumerJob(IQueueConsumer queue, IMessageSaverFactory factory, ILogger<ConsumerJob> logger)
        {
            this.queue = queue;
            this.factory = factory;
            this.logger = logger;
        }

        public async Task<ICommandResult> Execute(ConsumerJobTask task)
        {
            var message = await queue.Dequeue(task.QueueName);
            var saver = factory.GetSaver(task.QueueName);
            var result = await saver.Save(message);
            await queue.DeleteMessage(task.QueueName, message);
            return result;
        }
    }
}