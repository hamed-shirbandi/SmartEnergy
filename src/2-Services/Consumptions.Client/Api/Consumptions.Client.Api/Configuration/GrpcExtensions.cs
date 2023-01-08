using static SmartEnergy.BuildingBlocks.Contracts.Protos.GetConsumptionsGrpcService;

namespace SmartEnergy.Services.Consumptions.Client.Api.Configuration
{
    public static class GrpcExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<GetConsumptionsGrpcServiceClient>(options =>
            {
                options.Address = new Uri(configuration["Url:Consumptions-Server"]);
            });
        }


    }
}
