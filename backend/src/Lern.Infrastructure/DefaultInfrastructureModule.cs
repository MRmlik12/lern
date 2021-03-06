using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;
using Lern.Core.Configuration;
using Lern.Core.ProjectAggregate.User;
using Lern.Infrastructure.AzureServices;
using Lern.Infrastructure.Cloudinary;
using Lern.Infrastructure.Cloudinary.Interfaces;
using Lern.Infrastructure.Database;
using Lern.Infrastructure.Database.Interfaces;
using Lern.Infrastructure.Database.Repositories;
using Lern.Infrastructure.Handlers.Users;
using Lern.Infrastructure.Mapper;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace Lern.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new();
        private readonly string _dbConnectionString;
        private readonly CloudinaryConfiguration _cloudinaryConfiguration;
        private readonly AzureComputerVisionConfiguration _azureComputerVisionConfiguration;

        public DefaultInfrastructureModule(
            string dbConnectionString,
            CloudinaryConfiguration cloudinaryConfiguration,
            AzureComputerVisionConfiguration azureComputerVisionConfiguration
            )
        {
            _assemblies.Add(Assembly.GetAssembly(typeof(User)));
            _assemblies.Add(Assembly.GetAssembly(typeof(RegisterUserRequestHandler)));
            _dbConnectionString = dbConnectionString;
            _cloudinaryConfiguration = cloudinaryConfiguration;
            _azureComputerVisionConfiguration = azureComputerVisionConfiguration;
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

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SetRepository>()
                .As<ISetRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GroupRepository>()
                .As<IGroupRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CloudinaryClient>()
                .WithParameter("configuration", _cloudinaryConfiguration)
                .As<ICloudinaryClient>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UploadImageService>()
                .As<IUploadImageService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<TextRecognitionService>()
                .As<ITextRecognitionService>()
                .WithParameter("configuration", _azureComputerVisionConfiguration)
                .InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(c => { c.AddProfile<AutoMapperProfile>(); }));

            builder.Register(c =>
                {
                    var context = c.Resolve<IComponentContext>();
                    var config = context.Resolve<MapperConfiguration>();
                    return config.CreateMapper(context.Resolve);
                })
                .As<IMapper>()
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
                typeof(INotificationHandler<>)
            };

            foreach (var mediatorOpenType in mediatorOpenTypes)
                builder.RegisterAssemblyTypes(_assemblies.ToArray())
                    .AsClosedTypesOf(mediatorOpenType)
                    .AsImplementedInterfaces();
        }
    }
}