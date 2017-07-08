using System;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;

namespace HashtagAggregatorConsumer.Contracts
{
    public class ConsumerJobTask: IConsumerJobTask
    {
        private const string JobIdPattern = "exchanequeue-dequeue-{0}-id";

        public string QueueName { get; }

        public int Interval { get; }

        public string JobId => String.Format(JobIdPattern, QueueName);

        public ConsumerJobTask(string name, int interval)
        {
            QueueName = name;
            Interval = interval;
        }
    }
}