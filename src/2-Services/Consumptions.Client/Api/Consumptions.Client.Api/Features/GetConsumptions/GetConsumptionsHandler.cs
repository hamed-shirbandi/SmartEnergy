using AutoMapper;
using Grpc.Core;
using MediatR;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using SmartEnergy.BuildingBlocks.Contracts.Protos;
using static SmartEnergy.BuildingBlocks.Contracts.Protos.GetConsumptionsGrpcService;

namespace SmartEnergy.Services.Consumptions.Client.Api.Features.GetConsumptions
{
    public class GetConsumptionsHandler : IRequestHandler<GetConsumptionsRequest, IEnumerable<GetConsumptionDto>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly GetConsumptionsGrpcServiceClient _getConsumptionsGrpcServiceClient;

        #endregion

        #region Ctors

        public GetConsumptionsHandler(IMapper mapper, GetConsumptionsGrpcServiceClient getConsumptionsGrpcServiceClient)
        {
            _mapper = mapper;
            _getConsumptionsGrpcServiceClient = getConsumptionsGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetConsumptionDto>> Handle(GetConsumptionsRequest request, CancellationToken cancellationToken)
        {
            var consumptions = new List<GetConsumptionDto>();

            var getConsumptionsGrpcCall = _getConsumptionsGrpcServiceClient.Handle(new GetConsumptionsGrpcRequest { Skip = request.Skip, Take = request.Take }, cancellationToken: cancellationToken);

            await foreach (var response in getConsumptionsGrpcCall.ResponseStream.ReadAllAsync())
                consumptions.Add(_mapper.Map<GetConsumptionDto>(response));

            return consumptions;
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
