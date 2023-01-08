using SmartEnergy.Services.Consumptions.Server.Api.Domain;
using System.Text.Json;

namespace SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.DbContext
{
    /// <summary>
    /// To fake the databse and get data from a text file
    /// It sould be a real Time Serie Database like InfluxData on production
    /// </summary>
    public static class TimeSeriesDb
    {

        /// <summary>
        /// Mocked Consumptions table
        /// </summary>
        public static IEnumerable<Consumption> Consumptions => GetConsumptionsFromTextFile();


        /// <summary>
        ///
        /// </summary>
        private static IEnumerable<Consumption> GetConsumptionsFromTextFile()
        {
            string consumptionJsonText = File.ReadAllText(@"./Infrastructure/DB/meterusage.json");
            return JsonSerializer.Deserialize<IEnumerable<Consumption>>(consumptionJsonText);
        }
    }
}
