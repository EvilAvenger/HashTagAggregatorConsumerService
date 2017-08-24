using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Entities.VkEntities;
using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using HashTagAggregatorConsumer.Data.Vk.Mappers;
using HashTagAggregatorConsumer.Queries.Cqrs.Results.Commands;
using MediatR;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace HashTagAggregatorConsumer.Data.Vk.Messages
{
    public class VkMessageSaver : IMessageSaver
    {
        private readonly IMediator mediator;

        public VkMessageSaver(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ICommandResult> Save(CloudQueueMessage message)
        {
            var feed = JsonConvert.DeserializeObject<VkNewsFeed>(message.AsString);
            var mapper = new VkMessageResultMapper();
            var results = mapper.MapBunch(feed);
            var commandResult = new CommandResult
            {
                Success = true
            };
            foreach (var command in results)
            {
                var result = await mediator.Send(command);
                commandResult.Success = commandResult.Success && result.Success;
                commandResult.Message += result.Message;
            }
            return commandResult;
        }
    }
}