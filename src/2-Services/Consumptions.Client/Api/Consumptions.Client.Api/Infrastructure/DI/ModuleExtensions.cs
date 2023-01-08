using MediatR;
using SmartEnergy.Services.Consumptions.Client.Api.Features.GetConsumptions;
using SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.Behaviors;
using SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.Mapper;

namespace SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.DI
{

    /// <summary>
    /// 
    /// </summary>
    public static class ModuleExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddModules(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMediatR(typeof(GetConsumptionsHandler));

            services.AddCachingBehavior();
        }

    }
}
