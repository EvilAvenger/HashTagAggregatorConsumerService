namespace HashtagAggregatorConsumer.Contracts.Settings
{
    public class QueueSettings
    {
        public string StorageConnectionString { get; set; }

        public string TwitterQueueName { get; set; }

        public string VkQueueName { get; set; }
    }
}
