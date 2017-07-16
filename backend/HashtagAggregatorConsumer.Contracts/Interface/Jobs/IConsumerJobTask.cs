using System;
using HashtagAggregator.Service.Contracts.Queues;

namespace HashtagAggregatorConsumer.Contracts.Interface.Jobs
{
    public interface IConsumerJobTask
    {
        int Interval { get; }

        QueueParams QueueParameters { get; }

        string JobId { get; }
    }
}
