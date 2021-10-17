using System.Text;
using FluentValidation;
using Lern.Core.Models.Groups;
using Lern.Core.Models.Sets;
using Lern.Core.Models.Users;
using Lern.Core.Models.Users.Settings;
using Lern.Core.Validators;
using Lern.Core.Validators.Groups;
using Lern.Core.Validators.Sets;
using Lern.Core.Validators.Users;
using Lern.Core.Validators.Users.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Lern.Infrastructure
{
    public static class StartupExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterUserModel>, RegisterUserModelValidator>();
            services.AddTransient<IValidator<LoginUserModel>, LoginUserModelValidator>();
            services.AddTransient<IValidator<ChangePasswordModel>, ChangePasswordModelValidator>();
            services.AddTransient<IValidator<ChangeUsernameModel>, ChangeUsernameModelValidator>();
            services.AddTransient<IValidator<CreateSetModel>, CreateSetModelValidator>();
            services.AddTransient<IValidator<EditSetModel>, EditSetModelValidator>();
            services.AddTransient<IValidator<CreateGroupModel>, CreateGroupModelValidator>();
            services.AddTransient<IValidator<DeleteGroupModel>, DeleteGroupModelValidator>();
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
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSection.GetValue<string>("Key"))),
                        ValidateIssuer = true,
                        ValidIssuer = authSection.GetValue<string>("Issuer"),
                        ValidateAudience = true,
                        ValidAudience = authSection.GetValue<string>("Audience"),
                        RequireExpirationTime = true,
                        ValidateLifetime = true
                    };
                });
        }

        public static void AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lern.Api", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT header",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                });
            });
        }
    }
}