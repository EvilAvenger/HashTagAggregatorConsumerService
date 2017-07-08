using System;

using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;

namespace HashtagAggregatorConsumer.Contracts.Interface
{
    public interface IQueueConsumer
    {
        Task<CloudQueueMessage> Dequeue(string queueName);

        Task DeleteMessage(string queueName, CloudQueueMessage message);

        Task<int?> GetQueueLength(string queueName);
    }
}
