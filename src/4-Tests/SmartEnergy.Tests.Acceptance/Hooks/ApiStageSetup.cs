using BoDi;
using Microsoft.Extensions.Configuration;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using TechTalk.SpecFlow;

namespace SmartEnergy.Tests.Acceptance.Hooks
{
    [Binding]
    public class ApiStageSetup
    {
        private readonly IObjectContainer _objectContainer;
        private readonly IConfiguration _configuration;

        public ApiStageSetup(IObjectContainer objectContainer, IConfiguration configuration)
        {
            _objectContainer = objectContainer;
            _configuration = configuration;
        }


        /// <summary>
        /// This hook runs beafor each senario with API-Level tag
        /// </summary>
        [BeforeScenario("API_Level")]
        public void StageSetup()
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility> { CallAnApi.At(_configuration["Url:Consumptions-Client"]) });
            var stage = new Stage(cast);
            _objectContainer.RegisterInstanceAs(stage);
        }
    }
}
