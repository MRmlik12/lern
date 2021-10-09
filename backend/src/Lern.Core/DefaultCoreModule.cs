using Autofac;
using Lern.Core.Interfaces;
using Lern.Core.Services;
using Module = Autofac.Module;

namespace Lern.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();
        }
    }
}