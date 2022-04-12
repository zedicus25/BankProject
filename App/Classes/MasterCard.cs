using App.Interfaces;
using System;
using System.Text;

namespace App.Classes
{
    internal class MasterCard : ICard
    {
        public IBank Bank { get; private set; }
        public string Number { get; private set; }
        public int CVV { get; private set; }
        public int Pin { get; private set; }
        public CurrencyType Currency { get; private set; }
        public IBAN Iban { get; private set; }

        public MasterCard(CurrencyType currency, IBAN iban, IBank bank)
        {
            Bank = bank;
            Iban = iban;
            Currency = currency;
            Number = GenerateNumber(bank.GetID());
            CVV = GenerateCVV();
            Pin = GeneratePin();
        }

        public void ChangePin()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.Write("Confrim current PIN ");
                string str = Console.ReadLine();
                int pin = 0;
                int.TryParse(str, out pin);
                if (pin == Pin)
                {
                    break;
                }
                if (pin == 0 || pin != Pin)
                {
                    Console.WriteLine($"Wrong pin or input! {i + 1} attempt from 3");
                }

                if (i == 2)
                {
                    Console.WriteLine("You not confrim PIN, try later!");
                    Console.WriteLine("Enter any key to close");
                    Console.ReadKey();
                    return;
                }
            }

            while (true)
            {
                int newPin = 0;
                Console.Write("Enter new Pin ");
                string str = Console.ReadLine();
                int.TryParse(str, out newPin);
                if (newPin > 0 && newPin != Pin && newPin < 9999)
                {
                    Pin = newPin;
                    Console.WriteLine($"New pin is {Pin} Remeber it!");
                    break;
                }
                Console.Clear();
            }

        }

        public CurrencyType GetCurrency()
        {
            return Currency;
        }

        public string GetNumber()
        {
            return Number;
        }
        public IBAN GetIban()
        {
            return Iban;
        }

        public void SendMoney(string cardNumber)
        {
            cardNumber.Trim();
            ICard target = null;
            Client[] clients = new Client[0];
            Bank.GetClients().CopyTo(clients, 0);
            for (int i = 0; i < clients.Length; i++)
            {
                ICard[] clientsCards = new ICard[0];
                clients[i].Cards.CopyTo(clientsCards, 0);
                for (int j = 0; j < clientsCards.Length; j++)
                {
                    if (clientsCards[j].GetNumber() == cardNumber)
                    {
                        target = clientsCards[j];
                        break;
                    }
                }
            }

            if (target == null)
            {
                Console.WriteLine("Сard is not in the database");
                Console.WriteLine("Press anykey to close");
                Console.ReadKey();
                return;
            }

            float money = 0;
            Console.Write("Enter amount of money: ");
            string str = Console.ReadLine();
            if (float.TryParse(str, out money) == false)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Press anykey to close");
                Console.ReadKey();
                return;
            }

            if (Iban.TransactionIsPossible(money))
            {
                target?.GetIban().AddMoney(money);
                Iban.TakeOffMoney(money);
                Console.WriteLine("Succes!");
                Console.WriteLine("Press anykey to close");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Insufficient funds");
                Console.WriteLine("Press anykey to close");
                Console.ReadKey();
            }
        }

        public void TopUpTheCard(string cardNumber)
        {
            cardNumber.Trim();
            ICard target = null;
            Client[] clients = new Client[Bank.GetClients().Length];
            Bank.GetClients().CopyTo(clients, 0);
            for (int i = 0; i < clients.Length; i++)
            {
                ICard[] clientsCards = new ICard[clients[i].Cards.Length];
                clients[i].Cards.CopyTo(clientsCards, 0);
                for (int j = 0; j < clientsCards.Length; j++)
                {
                    if (clientsCards[j].GetNumber() == cardNumber)
                    {
                        target = clientsCards[j];
                        break;
                    }
                }
            }

            if (target == null)
            {
                Console.WriteLine("Сard is not in the database");
                Console.WriteLine("Press anykey to close");
                Console.ReadKey();
                return;
            }

            float money = 0;
            Console.Write("Enter amount of money: ");
            string str = Console.ReadLine();
            if (float.TryParse(str, out money) == false)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Press anykey to close");
                Console.ReadKey();
                return;
            }

            target?.GetIban().AddMoney(money);
            Console.Write("Succes!");
        }

        public string ShowAllInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Card number " + Number);
            sb.AppendLine("Card CVV " + CVV);
            sb.AppendLine("Card PIN " + Pin);
            sb.AppendLine("Card balance " + Iban.Balance + " " + Currency);
            return sb.ToString();
        }

        public string ShowBalance()
        {
            return String.Format("Balance {0} {1}", Iban.Balance, Currency);
        }

        public int GenerateCVV()
        {
            Random r = new Random();
            return r.Next(100, 999);
        }

        public string GenerateNumber(string bankID)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            sb.Append("5");
            sb.Append(bankID);
            for (int i = 0; i < 10; i++)
            {
                int num = random.Next(10000, 99999);
                sb.Append(num % 10);
            }
            return sb.ToString();
        }

        public int GeneratePin()
        {
            Random r = new Random();
            return r.Next(1000, 9999);
        }
        public override string ToString()
        {
            return String.Format("MasterCard {0}", Number);
        }
    }
}
