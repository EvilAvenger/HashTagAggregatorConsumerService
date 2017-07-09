using System.Collections.Generic;

using HashtagAggregator.Core.Entities.EF;
using HashtagAggregatorConsumer.Models;

namespace HashTagAggregatorConsumer.Queries.Mappers
{
    public class HashTagCommandToEntityMapper
    {
        public List<HashTagEntity> MapBunch(IEnumerable<HashtagModel> tags)
        {
            var results = new List<HashTagEntity>();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    var entity = new HashTagEntity
                    {
                        HashTag = tag.HashTag.NoHashTag,
                        IsEnabled = tag.IsEnabled
                    };
                    results.Add(entity);
                }
            }
            return results;
        }
    }
}
