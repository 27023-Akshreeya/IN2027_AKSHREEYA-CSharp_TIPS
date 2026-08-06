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
        }

        internal List<Ledger> GetLedger()
        {
            return this._ledgerList;
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
