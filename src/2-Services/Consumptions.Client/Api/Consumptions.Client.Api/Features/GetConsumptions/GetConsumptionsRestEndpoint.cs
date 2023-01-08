using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;

namespace SmartEnergy.Services.Consumptions.Client.Api.Features.GetConsumptions
{
    public class GetConsumptionsRestEndpoint : Controller
    {
        private readonly IMediator _mediator;

        public GetConsumptionsRestEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }



        /// <summary>
        /// get consumptions as chunks
        /// </summary>
        [HttpGet]
        [Route("consumptions/{skip}/{take}")]
        public async Task<IEnumerable<GetConsumptionDto>> Get(int skip, int take)
        {
            return await _mediator.Send(new GetConsumptionsRequest(skip, take));
        }
    }

}