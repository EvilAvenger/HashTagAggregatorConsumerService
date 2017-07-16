using System;

using Microsoft.WindowsAzure.Storage.Queue;

namespace HashtagAggregatorConsumer.Contracts.Interface
{
    public interface IAzureQueueDictionary
    {
        bool GetQueue(string queueName, out CloudQueue value);
    }
}
