using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class BankAccount
    {
        public delegate void OverdrawnEventHandler(object sender,OverDrawnArgs args);
        public event OverdrawnEventHandler Overdrawn;
        public decimal Balance;

        public void Credit(decimal amount)
        {
            if (amount < 0) throw new
                ArgumentOutOfRangeException(
                    "Credit amount must be positive.");
            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Debit amount must be positive.");

            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                if (Overdrawn != null)
                {
                    OverDrawnArgs args = new OverDrawnArgs();
                    args.DebitAmount = amount;
                    Overdrawn(this, args);
                }
            }
        }
    }
}
