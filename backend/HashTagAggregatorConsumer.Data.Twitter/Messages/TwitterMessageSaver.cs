using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using HashTagAggregatorConsumer.Data.Twitter.Extensions;
using HashTagAggregatorConsumer.Data.Twitter.Mappers;
using MediatR;
using Microsoft.WindowsAzure.Storage.Queue;

namespace HashTagAggregatorConsumer.Data.Twitter.Messages
{
    public class TwitterMessageSaver : IMessageSaver
    {
        private readonly IMediator mediator;

        public TwitterMessageSaver(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ICommandResult> Save(CloudQueueMessage message)
        {
            var tweet = message.ToTweet();
            var mapper = new TwitterMessageMapper();
            var command = mapper.MapSingle(tweet);
            return await mediator.Send(command);
        }
    }
}