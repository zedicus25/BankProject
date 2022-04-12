using System;
using System.Text;

namespace App.Classes
{
    internal class IBAN
    {
        public string Number { get; private set; }
        public float Balance { get; set; }
        public IBAN(string bankId)
        {
            Number = GenerateIban(bankId);
            Balance = 0;
        }
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

        private string GenerateIban(string bankId)
        {
            Random random = new Random(); 
            StringBuilder sb = new StringBuilder();
            sb.Append("UA");
            sb.Append(random.Next(10,100));
            sb.Append(bankId + 3);
            for (int i = 0; i < 19; i++)
            {
                sb.Append(random.Next(0, 10));
            }
            return sb.ToString();
        }
    }
}
