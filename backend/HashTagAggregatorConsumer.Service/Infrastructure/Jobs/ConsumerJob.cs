using System;
using System.Threading.Tasks;
using Hangfire;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregatorConsumer.Contracts;
using HashtagAggregatorConsumer.Contracts.Interface;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;
using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using HashtagAggregatorConsumer.Data.Result;
using Microsoft.Extensions.Logging;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Jobs
{
    [AutomaticRetry(Attempts = 1)]
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
            var saver = factory.GetSaver(task.QueueParameters.Name);
            ICommandResult result = new CommandResult {Success = true};

            var approximateLength = await queue.GetQueueLength(task.QueueParameters.Name);
            for (int i = 0; i < approximateLength; i++)
            {
                var message = await queue.DequeueAsync(task.QueueParameters.Name);
                if (message != null)
                {
                    result = await saver.Save(message);
                    if (result.Success)
                    {
                        await queue.DeleteMessage(task.QueueParameters.Name, message);
                    }
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}