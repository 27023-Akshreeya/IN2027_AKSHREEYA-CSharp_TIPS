using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    internal class Income : Ledger
    {
        public Income(decimal netbalance,  decimal amount, DateTime date, string source, Guid guid)
            : base(netbalance, date, source, "Expense", guid)
        {
            this.NetBalance = this.CalculateNetBalance(amount);
            this.Date = date;
            this.Description = source;
            this.TransactionType = "Income";
        }

        public decimal Amount { get; set; }

        public string? Source { get; set; }

        public override decimal CalculateNetBalance(decimal amount)
        {
            return this.NetBalance + amount;
        }
    }
}
