using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using Tweetinvi.Logic.JsonConverters;
using Tweetinvi.Models.DTO;

namespace HashTagAggregatorConsumer.Data.Twitter.Extensions
{
    public static class TwitterMessage
    {
        public static ITweetDTO ToTweet(this CloudQueueMessage message)
        {
            return JsonConvert.DeserializeObject<ITweetDTO>(message.AsString,
                JsonPropertiesConverterRepository.Converters);
        }
    }
}