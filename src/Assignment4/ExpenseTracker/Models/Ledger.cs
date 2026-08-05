using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public abstract class Ledger
    {
        public Ledger(decimal netBalance, DateTime date, string description, string transactionType, Guid transactionID)
        {
            this.NetBalance = netBalance;
            this.Date = date;
            this.Description = description;
            this.TransactionType = transactionType;
            this.TransactionID = transactionID;
        }

        public decimal NetBalance { get; set; }

        public DateTime Date { get; set; }

        public Guid TransactionID { get; }

        public string Description { get; set; }

        public string TransactionType { get; set; }

        public abstract decimal CalculateNetBalance(decimal amount);
    }
}
