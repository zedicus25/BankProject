using App.Interfaces;
using System;
using System.Text;

namespace App.Classes
{
    internal class MasterCard : ICard
    {
        public string Number { get; private set; }
        public int CVV { get; private set; }
        public int Pin { get; private set; }
        public CurrencyType Currency { get; private set; }
        public MasterCard(CurrencyType currency, string bankID)
        {
            Currency = currency;
            Number = GenerateNumber(bankID);
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

        public int GenerateCVV()
        {
            Random r = new Random();
            return r.Next(100, 999);
        }

        public string GenerateNumber(string bankID)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            sb.Append("4");
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

        public CurrencyType GetCurrency()
        {
            return Currency;
        }

        public void SendMoney(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public void SendMoney(string lastName, string name)
        {
            throw new NotImplementedException();
        }

        public void SendMoneyToAnotherCard()
        {
            throw new NotImplementedException();
        }

        public void TopUpTheCard(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public string GetNumber()
        {
            throw new NotImplementedException();
        }

        public void ShowAllInfo()
        {
            throw new NotImplementedException();
        }

        public void ShowBalance(CurrencyType type)
        {
            throw new NotImplementedException();
        }
    }
}
