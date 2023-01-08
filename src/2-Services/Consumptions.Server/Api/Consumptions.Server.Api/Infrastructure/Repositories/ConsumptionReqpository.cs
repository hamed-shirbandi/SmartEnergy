using SmartEnergy.Services.Consumptions.Server.Api.Domain;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.DbContext;

namespace SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Repositories
{
    public class ConsumptionReqpository
    {
        public ConsumptionReqpository()
        {
        }

        public async Task<IEnumerable<Consumption>> GetConsumptions(int skip, int take)
        {
            return TimeSeriesDb.Consumptions.Skip(skip).Take(take);
        }
    }
}
