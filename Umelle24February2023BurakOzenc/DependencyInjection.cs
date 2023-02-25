using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Umelle24February2023BurakOzenc.Authentication;
using Umelle24February2023BurakOzenc.Persistence;
using Umelle24February2023BurakOzenc.Persistence.IRepository;
using Umelle24February2023BurakOzenc.Persistence.Repository;
using Umelle24February2023BurakOzenc.Services;

namespace Umelle24February2023BurakOzenc;

public static class DependecyInjection
{
    public static void AddPersistence(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        
        services.AddDbContext<UserDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                dbOptions => dbOptions.EnableRetryOnFailure()));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddAuth(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        
        services.AddAuthentication(i =>
            {
                i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => ConfigureJwt(options, jwtSettings));
    }
    private static void ConfigureJwt(JwtBearerOptions options, JwtSettings jwtSettings)
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret))
        };
    }
}