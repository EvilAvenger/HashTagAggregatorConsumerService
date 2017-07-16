using System.Linq;
using System.Threading.Tasks;
using HashtagAggregator.Core.Entities.EF;
using HashtagAggregator.Data.DataAccess.Context;
using HashTagAggregatorConsumer.Queries.Cqrs.Commands;
using HashTagAggregatorConsumer.Queries.Cqrs.Results.Commands;
using HashTagAggregatorConsumer.Queries.Interfaces.Handlers.Commands;
using HashTagAggregatorConsumer.Queries.Mappers;

namespace HashTagAggregatorConsumer.Queries.Handlers.Commands
{
    public class CreateMessageCommandHandler : BaseQueryHandler, ICreateMessageCommandHandler
    {
        private readonly SqlApplicationDbContext context;

        public CreateMessageCommandHandler(SqlApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<CommandResult> Handle(CreateMessageCommand command)
        {
            lock (this)
            {
                var mapper = new MessageCommandToEntityMapper();
                var message = mapper.MapSingle(command);
                if (!context.Messages.Any(z => z.NetworkId == message.NetworkId &&
                                               z.User.NetworkId == message.User.NetworkId))
                {
                    if (!context.Users.Any(x => x.NetworkId == message.User.NetworkId))
                    {
                        context.Users.Add(message.User);
                        context.SaveChanges();
                    }

                    message.User = context.Users.FirstOrDefault(x => x.NetworkId == message.User.NetworkId);
                    message.PostDate = message.PostDate?.ToUniversalTime();
                    context.Messages.Add(message);

                    foreach (var tag in message.HashTags)
                    {
                        var tagToLink = context.Hashtags.FirstOrDefault(x => x.HashTag == tag.HashTag);

                        if (tagToLink != null)
                        {
                            var tag2Message = new MessageHashTagRelationsEntity
                            {
                                HashTagEntity = tagToLink,
                                MessageEntity = message
                            };
                            context.TaggedMessages.Add(tag2Message);
                        }
                    }
                    context.SaveChanges();
                }
                return new CommandResult {Success = true};
            }
        }
    }
}