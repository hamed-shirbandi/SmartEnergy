using EasyCaching.Core;
using MediatR;
using System.Reflection;

namespace SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.Behaviors
{

    /// <summary>
    /// Caching response for queries using Pipeline Pattern
    /// </summary>
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region Fields

        private readonly IEasyCachingProvider _cachingProvider;
        private readonly IConfiguration _configuration;

        #endregion

        #region Ctors


        public CachingBehavior(IEasyCachingProvider cachingProvider, IConfiguration configuration)
        {
            _cachingProvider = cachingProvider;
            _configuration = configuration;
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var configurationCacheEnabled = bool.Parse(_configuration["Caching:Enabled"]);
            if (!configurationCacheEnabled)
                return await next();

            var cacheKey = GenerateKeyFromRequest(request);
            var cachedResponse = await _cachingProvider.GetAsync<TResponse>(cacheKey);

            if (cachedResponse.Value != null)
                return cachedResponse.Value;

            var response = await next();

            //better way is to calculate the time from now to the next quarter
            //for example if now time is 01:02:00 then cache time should be 13 min
            var cacheTimeInMinutes = int.Parse(_configuration["Caching:CacheTimeInMinutes"]);

            var expirationTime = DateTime.Now.AddMinutes(cacheTimeInMinutes);
            await _cachingProvider.SetAsync(cacheKey, response, expirationTime.TimeOfDay);

            return response;
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private string GenerateKeyFromRequest(TRequest request)
        {
            var properties = new List<PropertyInfo>(request.GetType().GetProperties());
            var key = request.GetType().Name;

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(request, property.GetIndexParameters());

                string name = property.Name;
                string value = propValue != null ? propValue.ToString() : "";
                key += $"_{name}:{value}";
            }

            return key;
        }


        #endregion
    }
}
