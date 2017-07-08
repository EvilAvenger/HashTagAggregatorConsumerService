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

        public async Task<CloudQueueMessage> Dequeue(string queueName)
        {
            CloudQueueMessage message = null;
            var queue = GetQueue(queueName);
            if (queue != null)
            {
                message = await queue.GetMessageAsync();
            }
            return message;
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

        private CloudQueue GetQueue(string queueName)
        {
            CloudQueue queue = null;
            initializer.GetQueue(queueName, out queue);
            return queue;
        }
    }
}