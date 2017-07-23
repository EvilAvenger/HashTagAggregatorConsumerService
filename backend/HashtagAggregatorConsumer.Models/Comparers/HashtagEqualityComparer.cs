using System;
using System.Collections.Generic;

namespace HashtagAggregatorConsumer.Models.Comparers
{
    public class HashtagEqualityComparer : IEqualityComparer<HashtagModel>
    {
        public bool Equals(HashtagModel first, HashtagModel second)
        {
            if (ReferenceEquals(null, first) || ReferenceEquals(null, second))
            {
                return false;
            }

            return first.HashTag.OriginalTag.Equals(
                second.HashTag.OriginalTag,
                StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(HashtagModel model)
        {
            var hashCode = model.HashTag != null ? model.HashTag.OriginalTag.ToLower().GetHashCode() : 0;
            return hashCode;
        }
    }
}