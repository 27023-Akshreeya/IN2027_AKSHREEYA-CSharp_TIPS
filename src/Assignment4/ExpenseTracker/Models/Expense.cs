using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    internal class Expense : Ledger
    {
        public Expense(decimal netbalance, decimal amount, DateTime date, string category, Guid guid)
            : base(netbalance, date, category, "Expense", guid)
        {
            this.NetBalance = this.CalculateNetBalance(amount);
            this.Date = date;
            this.Description = category;
            this.TransactionType = "Expense";
        }

        public decimal Amount { get; set; }

        public string? Category { get; set; }

        public override decimal CalculateNetBalance(decimal amount) => this.NetBalance - amount;
    }
}
