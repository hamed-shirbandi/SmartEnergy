using AutoMapper;
using Grpc.Core;
using MediatR;
using SmartEnergy.BuildingBlocks.Contracts.Protos;

namespace SmartEnergy.Services.Consumptions.Server.Api.Features.GetConsumptions
{
    public class GetConsumptionsGrpcEndpoint : GetConsumptionsGrpcService.GetConsumptionsGrpcServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GetConsumptionsGrpcEndpoint(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        public override async Task Handle(GetConsumptionsGrpcRequest request, IServerStreamWriter<GetConsumptionsGrpcResponse> responseStream, ServerCallContext context)
        {
            var consumptions = await _mediator.Send(new GetConsumptionsRequest(request.Skip, request.Take));

            foreach (var consumption in consumptions)
                await responseStream.WriteAsync(_mapper.Map<GetConsumptionsGrpcResponse>(consumption));
        }

    }

}