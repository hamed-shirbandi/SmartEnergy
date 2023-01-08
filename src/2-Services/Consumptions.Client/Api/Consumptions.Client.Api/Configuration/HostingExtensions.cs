using MediatR;
using SmartEnergy.Services.Consumptions.Client.Api.Features.GetConsumptions;
using SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.Behaviors;
using SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.Mapper;

namespace SmartEnergy.Services.Consumptions.Client.Api.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddCors();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddMediatR(typeof(GetConsumptionsHandler));

            builder.Services.AddCachingBehavior();

            builder.Services.AddGrpcClients(builder.Configuration);

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.MapGet("/", () => "Hello from Consumptions.Client.Api! \n\n Try this to skip 0 and take 4 records: https://localhost:6003/consumptions/0/4");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}