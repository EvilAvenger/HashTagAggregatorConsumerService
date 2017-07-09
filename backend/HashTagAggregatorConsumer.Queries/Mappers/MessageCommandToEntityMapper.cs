using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF;
using HashTagAggregatorConsumer.Queries.Cqrs.Commands;

namespace HashTagAggregatorConsumer.Queries.Mappers
{
    public class MessageCommandToEntityMapper
    {
        public List<MessageEntity> MapBunch(IEnumerable<CreateMessageCommand> messages)
        {
            var results = new List<MessageEntity>();
            foreach (var message in messages)
            {
                if (message != null)
                {
                    results.Add(MapSingle(message));
                }
            }
            return results;
        }

        public MessageEntity MapSingle(CreateMessageCommand message)
        {
            var userCommandMapper = new UserToEntityMapper();
            var hashMapper = new HashTagCommandToEntityMapper();
            {
                var entity = new MessageEntity
                {
                    MessageText = message.MessageText,
                    HashTags = hashMapper.MapBunch(message.HashTags),
                    MediaType = message.MediaType,
                    User = userCommandMapper.MapSingle(message.User),
                    PostDate = message.PostDate,
                    Id = message.Id,
                    NetworkId = message.NetworkId
                };

                return entity;
            }
        }
    }
}