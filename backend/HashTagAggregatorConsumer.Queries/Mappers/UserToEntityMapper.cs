using HashtagAggregator.Core.Entities.EF;
using HashtagAggregatorConsumer.Models;

namespace HashTagAggregatorConsumer.Queries.Mappers
{
    public class UserToEntityMapper
    {
        public UserEntity MapSingle(UserModel item)
        {
            UserEntity query = null;
            if (item != null)
            {
                query = new UserEntity
                {
                    Id = item.Id,
                    NetworkId = item.NetworkId,
                    UserName = item.UserName,
                    ProfileId = item.ProfileId,
                    MediaType = item.MediaType,
                    Url = item.Url,
                    AvatarUrl50 = item.AvatarUrl50
                };
            }
            return query;
        }
    }
}
