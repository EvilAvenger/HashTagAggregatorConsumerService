using System;
using HashtagAggregator.Data.DataAccess.Context;

namespace HashTagAggregatorConsumer.Queries.Handlers
{
    public abstract class BaseQueryHandler
    {
        public SqlApplicationDbContext Context { get; set; }

        public BaseQueryHandler(SqlApplicationDbContext context)
        {
            Context = context;
        }
    }
}
