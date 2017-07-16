using Autofac;
using HashTagAggregatorConsumer.Queries.Handlers;

namespace HashTagAggregatorConsumer.Service.Configuration.Modules
{
    public class HandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseQueryHandler).Assembly)
                .Where(t => t.IsClass && t.Name.EndsWith("Query"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BaseQueryHandler).Assembly)
                .Where(t => t.IsClass && t.Name.EndsWith("QueryHandler"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BaseQueryHandler).Assembly)
                .Where(t => t.IsClass && t.Name.EndsWith("CommandHandler"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(BaseQueryHandler).Assembly)
                .Where(t => t.IsClass && t.Name.EndsWith("Command"))
                .AsImplementedInterfaces();
        }
    }
}