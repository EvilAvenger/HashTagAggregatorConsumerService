using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashtagAggregatorConsumer.Contracts.Interface
{
    public interface IConsumerJobBalancer
    {
        ICommandResult TryCreateJob(string name, int interval);

        void DeleteJob(string name);
    }
}