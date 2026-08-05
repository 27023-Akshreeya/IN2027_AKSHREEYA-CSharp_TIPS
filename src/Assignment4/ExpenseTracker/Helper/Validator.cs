using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Helper
{
    public static class Validator
    {
        public static bool IsValidAmount(string amount)
        {
            if (decimal.TryParse(amount, out decimal expenseAmount) || expenseAmount > 0)
            {
                return true;
            }

            return false;
        }

        public static bool IsValidDate(string date)
        {
            if (DateTime.TryParse(date.ToString(), out DateTime _))
            {
                return true;
            }

            return false;
        }
    }
}
