using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHierarchy.Model
{
    internal class Helper
    {
        internal bool IsNameValid(string? name)
        {
            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool IsPositionValid(string? position)
        {
            if (string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(position))
            {
                return false;
            }
            else if (position.ToLower() != "manager" && position.ToLower() != "developer")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal bool IsSalaryValid(string? input)
        {
            if(string.IsNullOrWhiteSpace(input) || !input.All(char.IsDigit) || string.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
