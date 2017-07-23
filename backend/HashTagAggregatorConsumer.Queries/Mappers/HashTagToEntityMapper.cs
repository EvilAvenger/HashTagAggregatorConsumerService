using System.Collections.Generic;
using System.Linq;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregatorConsumer.Models;
using HashtagAggregatorConsumer.Models.Comparers;

namespace HashTagAggregatorConsumer.Queries.Mappers
{
    public class HashTagCommandToEntityMapper
    {
        public List<HashTagEntity> MapBunch(IEnumerable<HashtagModel> tags)
        {
            var results = new List<HashTagEntity>();
            if (tags != null)
            {
                tags = tags.Distinct(new HashtagEqualityComparer());
                results.AddRange(tags.Select(tag => new HashTagEntity
                {
                    HashTag = tag.HashTag.TagWithHash,
                    IsEnabled = tag.IsEnabled
                }));
            }
            return results;
        }
    }
}
