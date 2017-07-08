using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using HashTagAggregatorConsumer.Service.Settings;
using Microsoft.Extensions.Options;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Messages
{
    public class MessageSaverFactory : IMessageSaverFactory
    {
        private readonly IOptions<QueueSettings> queueSettings;

        public MessageSaverFactory(IOptions<QueueSettings> queueSettings)
        {
            this.queueSettings = queueSettings;
        }

        public IMessageSaver GetSaver(string queueName)
        {
            IMessageSaver saver = null;
            if (queueSettings.Value.TwitterQueueName.Equals(queueName))
            {
                saver = new TwitterMessageSaver();
            }
            else if (queueSettings.Value.VkQueueName.Equals(queueName))
            {
                saver = new VkMessageSaver();
            }
            return saver;
        }
    }
}