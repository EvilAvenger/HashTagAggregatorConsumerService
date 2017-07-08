using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashTagAggregatorConsumer.Queries.Cqrs.Results.Commands
{
    public class CommandResult: ICommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public int Result { get; set; }
    }
}