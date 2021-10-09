using System.Text;
using FluentValidation;
using Lern.Core.Models.Users;
using Lern.Core.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Lern.Infrastructure
{
    public static class StartupExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterUserModel>, RegisterUserModelValidator>();
        }
        
        public static void AddJwtDefault(this IServiceCollection services, IConfiguration configuration)
        {
            var authSection = configuration.GetSection("Auth");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSection.GetValue<string>("Key"))),
                        ValidateIssuer = true,
                        ValidIssuer = authSection.GetValue<string>("Issuer"),
                        ValidateAudience = true,
                        ValidAudience = authSection.GetValue<string>("Audience"),
                        RequireExpirationTime = true,
                        ValidateLifetime = true
                    };
                });
        }
    }
}