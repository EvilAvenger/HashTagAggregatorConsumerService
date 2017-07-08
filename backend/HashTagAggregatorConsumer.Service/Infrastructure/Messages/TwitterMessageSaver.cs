using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregatorConsumer.Contracts.Interface.Messages;

using Microsoft.WindowsAzure.Storage.Queue;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Messages
{
    public class TwitterMessageSaver: IMessageSaver
    {
        public Task<ICommandResult> Save(CloudQueueMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
