using System.Threading.Tasks;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregatorConsumer.Contracts.Interface;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;

namespace HashTagAggregatorConsumer.Service.Infrastructure
{
    public class BackgroundServiceWorker : IBackgroundServiceWorker
    {
        private readonly IConsumerJobBalancer jobBalancer;

        public BackgroundServiceWorker(IConsumerJobBalancer jobBalancer)
        {
            this.jobBalancer = jobBalancer;
        }

        public ICommandResult Start(string name, int interval)
        {
            return jobBalancer.TryCreateJob(name, interval);
        }

        public ICommandResult Stop(string name)
        {
            return jobBalancer.DeleteJob(name);
        }
    }
}