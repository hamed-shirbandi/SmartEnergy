using AutoMapper;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using SmartEnergy.BuildingBlocks.Contracts.Protos;

namespace SmartEnergy.Services.Consumptions.Client.Api.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetConsumptionsGrpcResponse, GetConsumptionDto>();
        }
    }
}
