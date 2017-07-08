using System.Collections.Generic;

using HashtagAggregatorConsumer.Contracts.Interface;
using HashTagAggregatorConsumer.Service.Settings;

using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Queues
{
    public class AzureQueueDictionary : IAzureQueueDictionary
    {
        private readonly IOptions<QueueSettings> queueSettings;
        private readonly Dictionary<string, CloudQueue> queueDictionary = new Dictionary<string, CloudQueue>();

        public Dictionary<string, CloudQueue> QueueDictionary => queueDictionary;

        public AzureQueueDictionary(IOptions<QueueSettings> queueSettings)
        {
            this.queueSettings = queueSettings;
        }

        public bool GetQueue(string queueName, out CloudQueue value)
        {
            var isSuccess = false;
            isSuccess = queueDictionary.TryGetValue(queueName, out value);
            if (!isSuccess)
            {
                AddQueue(queueName);
                isSuccess = queueDictionary.TryGetValue(queueName, out value);
            }
            return isSuccess;
        }

        private void AddQueue(string queueName)
        {
            var storageAccount = CloudStorageAccount.Parse(queueSettings.Value.StorageConnectionString);

            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);
            queue.CreateIfNotExistsAsync();
            queueDictionary.Add(queueName, queue);
        }
    }
}