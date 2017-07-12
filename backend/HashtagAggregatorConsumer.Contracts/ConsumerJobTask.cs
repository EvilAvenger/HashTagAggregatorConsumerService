using System;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;

namespace HashtagAggregatorConsumer.Contracts
{
    public class ConsumerJobTask: IConsumerJobTask
    {
        private const string JobIdPattern = "exchanequeue-dequeue-{0}-id";

        public QueueParams QueueParameters { get; set; }

        public int Interval { get; }

        public string JobId => String.Format(JobIdPattern, QueueParameters);

        public ConsumerJobTask(QueueParams parameters, int interval)
        {
            QueueParameters = parameters;
            Interval = interval;
        }
    }
}