using MediatR;

namespace SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.Behaviors
{
    public static class BehaviorsExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddCachingBehavior(this IServiceCollection services)
        {
            services.AddEasyCaching(option=>option.UseInMemory());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        }


    }
}
