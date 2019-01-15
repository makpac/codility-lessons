using Exercises.BinarySearch;
using Xunit;

namespace Exercises.Tests.BinarySearch
{
    public class NailingPlanksTests
    {
        [Theory]
        [InlineData(new object[] { new int[] {1,4,5,8}, new int[] {4,5,9,10}, new int[] {4,6,7,10,2}, 4})]
        public void MinNumberOfNails_SuccessCases (int[] plankStarts, int[] plankEnds, int[] nails, int expectedMinNumberOfNails)
        {
            // arrange
            var sud = new NailingPlanks(plankStarts, plankEnds, nails);

            // act
            var minNumberOfNails = sud.MinNumberOfNails();

            // assert
            Assert.Equal(expectedMinNumberOfNails, minNumberOfNails);
        }
    }
}