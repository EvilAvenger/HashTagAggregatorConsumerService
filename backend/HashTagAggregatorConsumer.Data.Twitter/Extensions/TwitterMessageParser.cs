using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using Tweetinvi;
using Tweetinvi.Models;

namespace HashTagAggregatorConsumer.Data.Twitter.Extensions
{
    public static class TwitterMessage
    {
        public static ITweet ToTweet(this CloudQueueMessage message)
        {
            return (ITweet) JsonConvert.DeserializeObject(message.AsString, typeof(Tweet));
        }
    }
}