using System;
using System.Collections.Generic;
using System.Text;

namespace HashtagAggregatorConsumer.Contracts.Interface.Messages
{
    public interface IMessageSaverFactory
    {
        IMessageSaver GetSaver(string queueName);
    }
}
