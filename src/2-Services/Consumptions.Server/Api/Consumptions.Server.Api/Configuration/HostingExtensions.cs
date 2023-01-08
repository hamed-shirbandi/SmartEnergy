using MediatR;
using SmartEnergy.Services.Consumptions.Server.Api.Features.GetConsumptions;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.DI;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Mapper;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Repositories;

namespace SmartEnergy.Services.Consumptions.Server.Api.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddModules();

            builder.Services.AddGrpc();

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseRouting();

            app.MapGet("/", () => "Hello from Consumptions.Server.Api!");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcServices();
            });

            return app;
        }



    }
}