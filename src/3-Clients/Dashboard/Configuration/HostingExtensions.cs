using SmartEnergy.Clients.Dashboard.Services;

namespace SmartEnergy.Clients.Dashboard.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static class HostingExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            services.AddHttpClient(configuration);

            services.AddApiServices();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(sp => new HttpClient
            { 
                BaseAddress = new Uri(configuration["Url:Consumptions-Client"]) 
            });
        }


        /// <summary>
        /// 
        /// </summary>
        private static void AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<ConsumptionApiService>();
        }

    }
}
