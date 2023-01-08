using MediatR;
using SmartEnergy.Services.Consumptions.Server.Api.Features.GetConsumptions;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Mapper;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Repositories;

namespace SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.DI
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

            services.AddRepositories();
        }




        /// <summary>
        /// 
        /// </summary>
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ConsumptionReqpository>();
        }

    }
}
