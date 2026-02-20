namespace Company.ApiGateway.WebApi.ModulesExtension.Authorization
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(opciones =>
            {
            });

            return services;
        }
    }
}

