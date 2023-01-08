using FluentAssertions;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using SmartEnergy.Tests.Acceptance.Screenplay;
using Suzianna.Core.Screenplay;
using TechTalk.SpecFlow;

namespace SmartEnergy.Tests.Acceptance.Steps
{
    [Binding]
    public class GetConsumptionsSteps
    {
        #region Fields

        private Stage _stage;
        private IEnumerable<GetConsumptionDto> _consumptions;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        public GetConsumptionsSteps(Stage stage)
        {
            _stage = stage;
        }

        #endregion

        #region Scenario: Geting consumptions list as requested number



        [Given(@"John is an Operator")]
        public void GivenJohnIsNotAnOperator()
        {
            _stage.ShineSpotlightOn("John");
        }



        [When(@"John request for consumptions list by skiping <skip> and taking <take>")]
        public void WhenJohnRequestForConsumptionsListBySkipingAndTaking(int skip, int take)
        {
            _consumptions= _stage.ActorInTheSpotlight.AsksFor(DataFrom.GetConsumptions(skip,take));
        }




        [Then(@"John can see the consumptions list successfully")]
        public void ThenJohnCanSeeTheConsumptionsListSuccessfully()
        {
            _consumptions.Should().NotBeNull();
        }


        #endregion

    }
}
