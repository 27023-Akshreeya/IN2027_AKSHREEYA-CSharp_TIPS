using System.Collections.Generic;
using System.Linq;

namespace LINQchallenges.Application
{
    /// <summary>
    /// Provides utility methods for array manipulation using LINQ.
    /// </summary>
    public class ArrayManipulationService
    {
        /// <summary>
        /// Gets the second highest distinct element from the array.
        /// </summary>
        /// <param name="array">The input integer array.</param>
        /// <returns>The second highest unique value.</returns>
        public int GetSecondHighestArrayElement(int[] array)
        {
            return array
                .Distinct()
                .OrderByDescending(x => x)
                .Skip(1)
                .First();
        }

        /// <summary>
        /// Finds all unique pairs of integers in the array that sum to a target value.
        /// </summary>
        /// <param name="array">The array of integers to search.</param>
        /// <param name="target">The target sum.</param>
        /// <returns>A collection of integer pairs summing to the target.</returns>
        public IEnumerable<(int, int)> GetSumPairs(int[] array, int target)
        {
            return array
                .SelectMany((a, i) => array.Skip(i + 1), (a, b) => (a, b))
                .Where(pair => pair.a + pair.b == target);
        }
    }
}
