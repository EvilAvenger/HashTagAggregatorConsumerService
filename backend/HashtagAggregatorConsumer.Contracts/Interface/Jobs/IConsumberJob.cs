using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Service.Contracts.Jobs;

namespace HashtagAggregatorConsumer.Contracts.Interface.Jobs
{
    public interface IConsumberJob : IJob
    {
        Task<ICommandResult> Execute(ConsumerJobTask task);
    }
}
