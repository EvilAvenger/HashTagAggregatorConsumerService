using System;
using System.Threading.Tasks;
using HashtagAggregator.Data.DataAccess.Context;
using HashTagAggregatorConsumer.Queries.Cqrs.Commands;
using HashTagAggregatorConsumer.Queries.Cqrs.Results.Commands;
using HashTagAggregatorConsumer.Queries.Interfaces.Handlers.Commands;

namespace HashTagAggregatorConsumer.Queries.Handlers.Commands
{
    public class CreateMessageCommandHandler: BaseQueryHandler, ICreateMessageCommandHandler
    {
        public CreateMessageCommandHandler(SqlApplicationDbContext context) : base(context)
        {
        }

        public Task<CommandResult> Handle(CreateMessageCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
