using Autofac;
using HashtagAggregator.Service.Contracts;
using HashtagAggregatorConsumer.Contracts.Interface;
using HashtagAggregatorConsumer.Contracts.Interface.Jobs;
using HashtagAggregatorConsumer.Contracts.Interface.Messages;
using HashtagAggregatorConsumer.Data;
using HashTagAggregatorConsumer.Service.Infrastructure;
using HashTagAggregatorConsumer.Service.Infrastructure.Jobs;
using HashTagAggregatorConsumer.Service.Infrastructure.Messages;
using HashTagAggregatorConsumer.Service.Infrastructure.Queues;
using IBackgroundServiceWorker = HashtagAggregatorConsumer.Contracts.Interface.IBackgroundServiceWorker;

namespace HashTagAggregatorConsumer.Service.Configuration.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RecurringJobManager>().As<IConsumerJobManager>();
            builder.RegisterType<BackgroundServiceWorker>().As<IBackgroundServiceWorker>();
            builder.RegisterType<ConsumerJobBalancer>().As<IConsumerJobBalancer>();
            builder.RegisterType<AzureQueueDictionary>().As<IAzureQueueDictionary>();
            builder.RegisterType<HangfireStorageAccessor>().As<IStorageAccessor>().SingleInstance();
            builder.RegisterType<ConsumerJob>().As<IConsumberJob>();
            builder.RegisterType<QueueConsumer>().As<IQueueConsumer>();
            builder.RegisterType<MessageSaverFactory>().As<IMessageSaverFactory>();
        }
    }
}