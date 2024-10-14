using Microsoft.Extensions.DependencyInjection;

namespace EventZen.Shared.Infrastructure.Authentication;
internal static class AuthenticationExtensions
{
    internal static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();

        services.AddAuthentication()
            .AddJwtBearer();

        services.ConfigureOptions<JwtBearerConfigureOptions>();

        services.AddHttpContextAccessor();

        return services;
    }
}
