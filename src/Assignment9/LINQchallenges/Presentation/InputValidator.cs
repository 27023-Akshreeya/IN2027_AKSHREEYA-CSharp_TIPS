using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQchallenges.Presentation
{
    public static class InputValidator
    {
        public static bool IsPriceValid(string inputPrice)
        {
            return decimal.TryParse(inputPrice, out decimal price) && price >= 1;
        }

        internal static bool IsNumberValid(string userInput)
        {
            return int.TryParse(userInput, out int _);
        }
    }
}
