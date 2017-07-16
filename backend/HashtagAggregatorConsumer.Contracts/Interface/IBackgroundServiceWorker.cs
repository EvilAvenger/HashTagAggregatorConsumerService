using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashtagAggregatorConsumer.Contracts.Interface
{
    public interface IBackgroundServiceWorker
    {
        ICommandResult Start(string name, int interval);

        ICommandResult Stop(string name);
    }
}