using Suzianna.Core.Screenplay.Questions;
using SmartEnergy.Tests.Acceptance.Screenplay.Questions;
using SmartEnergy.BuildingBlocks.Contracts.Dtos;

namespace SmartEnergy.Tests.Acceptance.Screenplay
{

    /// <summary>
    /// Holds all Questions
    /// It is used just to bring out technical decisions from spec definitions
    /// </summary>
    public static class DataFrom
    {

        /// <summary>
        /// 
        /// </summary>
        public static IQuestion<IEnumerable<GetConsumptionDto>> GetConsumptions(int skip, int take)
        {
            return new GetConsumptionsQuestion(skip,take);
        }
    }
}
