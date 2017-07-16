using System.Threading.Tasks;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashtagAggregatorConsumer.Contracts.Interface.Jobs
{
    public interface IConsumerJobManager
    {
        ICommandResult AddJob(IConsumerJobTask task);

        ICommandResult DeleteJob(IConsumerJobTask task);

        ICommandResult ReconfigureJob(IConsumerJobTask task);

        Task<ICommandResult> StartNow(IConsumerJobTask task);
    }
}