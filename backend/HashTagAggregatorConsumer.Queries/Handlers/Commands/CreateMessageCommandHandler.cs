using System;

using HashtagAggregator.Data.DataAccess.Context;

namespace HashTagAggregatorConsumer.Queries.Handlers.Commands
{
    public class CreateMessageCommandHandler: BaseQueryHandler
    {
        public CreateMessageCommandHandler(SqlApplicationDbContext context) : base(context)
        {
        }
    }
}
