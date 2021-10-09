using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Lern.Core.ProjectAggregate.User;
using Lern.Infrastructure.Database;
using Lern.Infrastructure.Database.Interfaces;
using Lern.Infrastructure.Handlers.Users;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace Lern.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new();
        private readonly string _dbConnectionString;

        public DefaultInfrastructureModule(string dbConnectionString)
        {
            _assemblies.Add(Assembly.GetAssembly(typeof(User)));
            _assemblies.Add(Assembly.GetAssembly(typeof(RegisterUserRequestHandler)));
            _dbConnectionString = dbConnectionString;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<AppDbContext>()
                .WithParameter("connectionString", _dbConnectionString)
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            
            var mediatorOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionHandler<,>),
                typeof(INotificationHandler<>),
            };
            
            foreach (var mediatorOpenType in mediatorOpenTypes)
            {
                builder.RegisterAssemblyTypes(_assemblies.ToArray())
                    .AsClosedTypesOf(mediatorOpenType)
                    .AsImplementedInterfaces();
            }
        }
    }
}