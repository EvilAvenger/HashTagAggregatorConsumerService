using System.Collections.Generic;
using System.Threading.Tasks;

using HashtagAggregatorConsumer.Contracts.Interface;

using Microsoft.WindowsAzure.Storage.Queue;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Queues
{
    public class QueueConsumer : IQueueConsumer
    {
        private readonly IAzureQueueDictionary initializer;

        public QueueConsumer(IAzureQueueDictionary initializer)
        {
            this.initializer = initializer;
        }

        public async Task<CloudQueueMessage> DequeueAsync(string queueName)
        {
            var queue = GetQueue(queueName);
            return await Dequeue(queue);
        }

        public IEnumerable<CloudQueueMessage> DequeueMany(string queueName)
        {
            var queue = GetQueue(queueName);
            yield return Dequeue(queue).Result;
        }

        public async Task DeleteMessage(string queueName, CloudQueueMessage message)
        {
            CloudQueue queue = null;
            initializer.GetQueue(queueName, out queue);
            if (queue != null)
            {
                await queue.DeleteMessageAsync(message);
            }
        }

        public async Task<int?> GetQueueLength(string queueName)
        {
            int? cachedMessageCount = null;
            var queue = GetQueue(queueName);
            if (queue != null)
            {
                await queue.FetchAttributesAsync();
                cachedMessageCount = queue.ApproximateMessageCount;
            }
            return cachedMessageCount;
        }

        private async Task<CloudQueueMessage> Dequeue(CloudQueue queue)
        {
            CloudQueueMessage message = null;
            if (queue != null)
            {
                message = await queue.GetMessageAsync();
            }
            return message;
        }

        private CloudQueue GetQueue(string queueName)
        {
            CloudQueue queue = null;
            initializer.GetQueue(queueName, out queue);
            return queue;
        }
    }
}