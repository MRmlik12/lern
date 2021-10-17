using Autofac;
using Lern.Core.Configuration;
using Lern.Core.Interfaces;
using Lern.Core.Services;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace Lern.Core
{
    public class DefaultCoreModule : Module
    {
        private readonly IConfiguration _configuration;

        public DefaultCoreModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtService>()
                .As<IJwtService>()
                .InstancePerLifetimeScope();

            builder.RegisterInstance(new AuthConfiguration
                {
                    Key = _configuration["Auth:Key"],
                    Issuer = _configuration["Auth:Issuer"],
                    Audience = _configuration["Auth:Audience"]
                })
                .As<IAuthConfiguration>();
        }
    }
}