using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.DI;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Repositories;

namespace SmartEnergy.Services.Consumptions.Server.Tests.Integration.Fixtures
{
    public abstract class TestsBaseFixture
    {
        private readonly IServiceProvider _serviceProvider;
        public readonly IMapper Mapper;
        public readonly ConsumptionReqpository ConsumptionReqpository;
        

        protected TestsBaseFixture() 
        {
            _serviceProvider = GetServiceProvider();
            Mapper = GetRequiredService<IMapper>();
            ConsumptionReqpository = GetRequiredService<ConsumptionReqpository>();
        }




        /// <summary>
        /// 
        /// </summary>
        public IServiceProvider GetServiceProvider( )
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                                //Copy from Consumptions.Server.Api during the build event
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .AddJsonFile("appsettings.Development.json", optional: true)
                                .Build();

            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            services.AddModules();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }



        /// <summary>
        /// 
        /// </summary>
        private T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

    }
}