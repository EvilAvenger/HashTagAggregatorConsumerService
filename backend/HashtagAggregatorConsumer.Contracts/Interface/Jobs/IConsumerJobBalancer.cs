using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashtagAggregatorConsumer.Contracts.Interface.Jobs
{
    public interface IConsumerJobBalancer
    {
        ICommandResult TryCreateJob(string name, int interval);

        ICommandResult DeleteJob(string name);
    }
}