using System.Collections.Generic;
using HashtagAggregator.Shared.Common.Infrastructure;
using HashtagAggregator.Shared.Contracts.Enums;
using HashtagAggregatorConsumer.Models;
using HashTagAggregatorConsumer.Queries.Cqrs.Commands;
using Tweetinvi.Models;

namespace HashTagAggregatorConsumer.Data.Twitter.Mappers
{
    public class TwitterMessageMapper
    {
        public CreateMessageCommand MapSingle(ITweet tweet)
        {
            var user = new UserModel
            {
                NetworkId = tweet.CreatedBy.IdStr,
                Url = tweet.Url,
                UserName = tweet.CreatedBy.Name,
                AvatarUrl50 = tweet.CreatedBy.ProfileImageUrl,
                MediaType = SocialMediaType.Twitter
            };

            List<HashtagModel> tags = tweet.Hashtags.Select(x => new HashtagModel
            {
                HashTag = new HashTagWord(x.Text),
                IsEnabled = false
            }).ToList();

            var message = new CreateMessageCommand
            {
                MessageText = tweet.Text,
                HashTags = tags,
                MediaType = SocialMediaType.Twitter,
                PostDate = tweet.TweetLocalCreationDate.ToUniversalTime(),
                NetworkId = tweet.IdStr,
                User = user
            };
            return message;
        }
    }
}