using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using Microsoft.WindowsAzure.Storage.Queue;

namespace HashtagAggregatorConsumer.Contracts.Interface.Messages
{
    public interface IMessageSaver
    {
        Task<ICommandResult> Save(CloudQueueMessage message);
    }
}
