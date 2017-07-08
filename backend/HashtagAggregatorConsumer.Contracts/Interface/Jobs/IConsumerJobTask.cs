using System;

namespace HashtagAggregatorConsumer.Contracts.Interface.Jobs
{
    public interface IConsumerJobTask
    {
        int Interval { get; }

        string QueueName { get; }

        string JobId { get; }
    }
}
