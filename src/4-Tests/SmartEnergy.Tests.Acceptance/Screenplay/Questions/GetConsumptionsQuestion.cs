using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace SmartEnergy.Tests.Acceptance.Screenplay.Questions
{
    public class GetConsumptionsQuestion : IQuestion<IEnumerable<GetConsumptionDto>>
    {
        private readonly int _skip;
        private readonly int _take;
        public GetConsumptionsQuestion(int skip, int take)
        {
            _skip = skip;
            _take = take;
        }


        public IEnumerable<GetConsumptionDto> AnsweredBy(Actor actor)
        {
            actor.AttemptsTo(Get.ResourceAt($"consumptions/{_skip}/{_take}"));
            return actor.AsksFor(LastResponse.Content<IEnumerable<GetConsumptionDto>>());
        }
    }
}
