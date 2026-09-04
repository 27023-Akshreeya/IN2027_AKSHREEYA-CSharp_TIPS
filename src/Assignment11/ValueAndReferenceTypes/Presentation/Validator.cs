using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes.Presentation
{
    public static class Validator
    {
        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !input.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }
    }
}
