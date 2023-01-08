using MediatR;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;

namespace SmartEnergy.Services.Consumptions.Server.Api.Features.GetConsumptions
{
    public class GetConsumptionsRequest : IRequest<IEnumerable<GetConsumptionDto>>
    {
        public GetConsumptionsRequest(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; }
        public int Take { get; }

    }
}
