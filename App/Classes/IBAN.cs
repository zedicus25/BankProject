using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Classes
{
    internal class IBAN
    {
        public string Number { get; set; }
        public float Balance { get; set; }

        public void AddMoney(float money)
        {
            if (money > 0)
                Balance += money;
        }

        public void TakeOffMoney(float money)
        {
            if(money > 0 && TransactionIsPossible(money))
                Balance -= money;
        }

        public bool TransactionIsPossible(float money)
        {
            return (Balance - money) > 0;
        }
    }
}
