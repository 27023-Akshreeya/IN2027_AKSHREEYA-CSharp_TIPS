using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQchallenges.Application
{
    internal class ArrayManipulationService
    {
        public int GetSecondHighestArrayElement(int[] array)
        {
            return array
                .Distinct()
                .OrderByDescending(x => x)
                .Skip(1)
                .First();
        }

        public IEnumerable<(int, int)> GetSumPairs(int[] array, int target)
        {
            return array
                .SelectMany((a, i) => array.Skip(i + 1), (a, b) => (a, b))
                .Where(pair => pair.a + pair.b == target);
        }
    }
}
