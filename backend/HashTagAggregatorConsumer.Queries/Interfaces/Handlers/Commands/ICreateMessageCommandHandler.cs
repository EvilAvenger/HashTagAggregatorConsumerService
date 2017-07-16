using HashTagAggregatorConsumer.Queries.Cqrs.Commands;
using HashTagAggregatorConsumer.Queries.Cqrs.Results.Commands;
using MediatR;

namespace HashTagAggregatorConsumer.Queries.Interfaces.Handlers.Commands
{
    public interface ICreateMessageCommandHandler : IAsyncRequestHandler<CreateMessageCommand, CommandResult>
    {
    }
}