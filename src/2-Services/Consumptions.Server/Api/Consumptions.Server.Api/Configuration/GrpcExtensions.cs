using SmartEnergy.Services.Consumptions.Server.Api.Features.GetConsumptions;

namespace SmartEnergy.Services.Consumptions.Server.Api.Configuration
{
    public static class GrpcExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void MapGrpcServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<GetConsumptionsGrpcEndpoint>();
        }


    }
}
