using System;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using MediatR;
using Microsoft.WindowsAzure.Storage.Queue;

namespace HashTagAggregatorConsumer.Data.Vk.Messages
{
    public class VkMessageSaver: IMessageSaver
    {
        private readonly IMediator mediator;

        public VkMessageSaver(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<ICommandResult> Save(CloudQueueMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
