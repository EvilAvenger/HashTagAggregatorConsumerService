using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;

namespace HashtagAggregatorConsumer.Contracts.Interface
{
    public interface IQueueConsumer
    {
        Task<CloudQueueMessage> DequeueAsync(string queueName);

        Task DeleteMessage(string queueName, CloudQueueMessage message);

        IEnumerable<CloudQueueMessage> DequeueMany(string queueName);

        Task<int?> GetQueueLength(string queueName);
    }
}
