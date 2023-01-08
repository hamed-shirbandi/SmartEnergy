using Xunit;

namespace SmartEnergy.Services.Consumptions.Server.Tests.Integration.Fixtures
{


    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition(nameof(ConsumptionCollectionFixture))]
    public class ConsumptionCollectionFixtureDefinition : ICollectionFixture<ConsumptionCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }



    /// <summary>
    /// 
    /// </summary>
    public class ConsumptionCollectionFixture : TestsBaseFixture
    {

        public ConsumptionCollectionFixture() : base()
        {
        }
    }
}