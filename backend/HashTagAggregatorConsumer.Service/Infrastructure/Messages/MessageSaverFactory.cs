using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using HashtagAggregatorConsumer.Contracts.Settings;
using HashTagAggregatorConsumer.Data.Twitter.Messages;
using HashTagAggregatorConsumer.Data.Vk.Messages;
using MediatR;
using Microsoft.Extensions.Options;

namespace HashTagAggregatorConsumer.Service.Infrastructure.Messages
{
    public class MessageSaverFactory : IMessageSaverFactory
    {
        private readonly IOptions<QueueSettings> queueSettings;
        private readonly IMediator mediator;

        public MessageSaverFactory(IOptions<QueueSettings> queueSettings, IMediator mediator)
        {
            this.queueSettings = queueSettings;
            this.mediator = mediator;
        }

        public IMessageSaver GetSaver(string queueName)
        {
            IMessageSaver saver = null;
            if (queueSettings.Value.TwitterQueueName.Equals(queueName))
            {
                saver = new TwitterMessageSaver(mediator);
            }
            else if (queueSettings.Value.VkQueueName.Equals(queueName))
            {
                saver = new VkMessageSaver(mediator);
            }
            return saver;
        }
    }
}