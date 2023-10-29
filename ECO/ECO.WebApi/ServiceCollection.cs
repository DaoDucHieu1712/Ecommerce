using System.Net;

namespace ECO.WebApi
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(ECO.Infrastructure.Mappers.MapperProfile).Assembly);
            return services;
        }
    }
}
