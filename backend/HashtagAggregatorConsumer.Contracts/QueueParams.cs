using System;

namespace HashtagAggregatorConsumer.Contracts
{
    public class QueueParams
    {
        private string name;

        public string Name => name;

        public QueueParams(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}