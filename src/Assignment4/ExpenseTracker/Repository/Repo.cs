using ExpenseTracker.Models;
using Spectre.Console;

namespace ExpenseTracker.Repository
{
    internal class Repo
    {
        private List<Ledger> _ledgerList = new List<Ledger>();

        internal void AddNewTransation(Ledger ledger)
        {
            this._ledgerList.Add(ledger);

            Console.Clear();
            var table = new Table();
            table.AddColumn("Date");
            table.AddColumn("Transaction ID");
            table.AddColumn("Description");
            table.AddColumn("Type");
            table.AddColumn("Balance");
            foreach (var item in this._ledgerList)
            {
                table.AddRow(item.Date.ToString("yyyy-MM-dd"), item.TransactionID.ToString(), item.Description, item.TransactionType, item.NetBalance.ToString());
            }

            AnsiConsole.Write(table);
        }

        internal decimal GetCurrentBalance()
        {
            if (this._ledgerList.Count == 0)
            {
                return 0;
            }
            else
            {
                return this._ledgerList.Last().NetBalance;
            }
        }
    }
}
