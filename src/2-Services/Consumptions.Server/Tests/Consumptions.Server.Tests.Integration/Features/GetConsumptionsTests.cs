using FluentAssertions;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using SmartEnergy.Services.Consumptions.Server.Api.Features.GetConsumptions;
using SmartEnergy.Services.Consumptions.Server.Tests.Integration.Fixtures;
using Xunit;

namespace SmartEnergy.Services.Consumptions.Server.Tests.Integration.Features
{
    [Collection(nameof(ConsumptionCollectionFixture))]
    public class GetConsumptionsTests
    {

        #region Fields

        private readonly ConsumptionCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetConsumptionsTests(ConsumptionCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Consumptions_list_are_fetched()
        {
            //Arrange
            var getBoardByIdHandler = new GetConsumptionsHandler(_fixture.Mapper, _fixture.ConsumptionReqpository);
            var request = new GetConsumptionsRequest(skip:0,take:4);

            //Act
            var result = await getBoardByIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().AllBeOfType<GetConsumptionDto>();
        }


        #endregion
    }
}
