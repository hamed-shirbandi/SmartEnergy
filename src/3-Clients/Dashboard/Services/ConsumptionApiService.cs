using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using System.Net.Http.Json;

namespace SmartEnergy.Clients.Dashboard.Services
{
    public class ConsumptionApiService
    {
        #region Fields

        private HttpClient _httpClient;

        #endregion

        #region Ctor

        public ConsumptionApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetConsumptionDto>> GetListAsync(int skip, int take)
        {
            var url = $"/consumptions/{skip}/{take}";
            var httpResponse = await _httpClient.GetAsync(url);
            return await httpResponse.Content.ReadFromJsonAsync<IEnumerable<GetConsumptionDto>>();
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
