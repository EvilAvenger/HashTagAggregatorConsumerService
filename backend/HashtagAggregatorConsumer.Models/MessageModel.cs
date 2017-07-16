using System;
using System.Collections.Generic;
using HashtagAggregator.Shared.Contracts.Enums;

namespace HashtagAggregatorConsumer.Models
{
    public class MessageModel
    {
        public long Id { get; set; }

        public string MessageText { get; set; }

        public List<HashtagModel> HashTags { get; set; }

        public SocialMediaType MediaType { get; set; }

        public DateTime? PostDate { get; set; }

        public string NetworkId { get; set; }

        public UserModel User { get; set; }
    }
}