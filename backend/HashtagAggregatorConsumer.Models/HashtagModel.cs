using System;
using HashtagAggregator.Shared.Common.Infrastructure;

namespace HashtagAggregatorConsumer.Models
{
    public class HashtagModel
    {
        public long Id { get; set; }

        public HashTagWord HashTag { get; set; }

        public bool IsEnabled { get; set; }

        public long? ParentId { get; set; }
    }
}