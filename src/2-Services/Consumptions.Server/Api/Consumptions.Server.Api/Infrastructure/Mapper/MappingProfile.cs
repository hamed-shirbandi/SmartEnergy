using AutoMapper;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using SmartEnergy.BuildingBlocks.Contracts.Protos;
using SmartEnergy.Services.Consumptions.Server.Api.Domain;

namespace SmartEnergy.Services.Consumptions.Server.Api.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Consumption, GetConsumptionDto>();
            CreateMap<GetConsumptionDto, GetConsumptionsGrpcResponse>();
        }
    }
}
