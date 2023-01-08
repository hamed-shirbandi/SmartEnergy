using AutoMapper;
using MediatR;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Repositories;

namespace SmartEnergy.Services.Consumptions.Server.Api.Features.GetConsumptions
{
    public class GetConsumptionsHandler : IRequestHandler<GetConsumptionsRequest, IEnumerable<GetConsumptionDto>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly ConsumptionReqpository _consumptionReqpository;

        #endregion

        #region Ctors

        public GetConsumptionsHandler(IMapper mapper, ConsumptionReqpository consumptionReqpository)
        {
            _mapper = mapper;
            _consumptionReqpository = consumptionReqpository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetConsumptionDto>> Handle(GetConsumptionsRequest request, CancellationToken cancellationToken)
        {
            var consumptions = await _consumptionReqpository.GetConsumptions(request.Skip,request.Take);

            return _mapper.Map<IEnumerable<GetConsumptionDto>>(consumptions);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
