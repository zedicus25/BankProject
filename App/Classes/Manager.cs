using App.Interfaces;
using System;

namespace App.Classes
{
    internal class Manager
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        private Func<int,IBAN, ICard>[] _createCards;
        private IBank _bank;

        public Manager(string name, string lastName, IBank bank)
        {
            Name = name;
            LastName = lastName;
            _bank = bank;
            _createCards = new Func<int, IBAN, ICard>[]
            {
                CreateVisa,
                CreateMasterCard
            };
        }

        public void AddClient()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            string lastName = Console.ReadLine();
            Client cl = new Client(name,lastName,_bank.GetID());
            _bank.AddClient(cl);
        }
        public void CreateNewCard(Client client)
        {
            ICard[] cards = new ICard[client.Cards.Length]; 
            client.Cards.CopyTo(cards, 0);
            Array.Resize(ref cards, cards.Length+1);
            int type = SelectCardType();
            int curency = SelectCurrencyType();
            client.Cards = new ICard[cards.Length];
            cards.CopyTo(client.Cards, 0);
            client.Cards[client.Cards.Length - 1] = _createCards[type-1]?.Invoke(curency-1, client.Iban);
        }

        private ICard CreateVisa(int type, IBAN iban)
        {
            return new VisaCard((CurrencyType)type, iban, _bank);
        }
        private ICard CreateMasterCard(int type, IBAN iban)
        {
            return new MasterCard((CurrencyType)type,iban ,_bank);
        }
        private int SelectCardType()
        {
            int cardType = 0;
            while (true)
            {
                Console.WriteLine("Select type of card:");
                Console.WriteLine("1-Visa");
                Console.WriteLine("2-MasterCard");
                string str = Console.ReadLine();
                if (int.TryParse(str, out cardType))
                    if (cardType > 0 && cardType <= 2)
                        return cardType;
                    else
                        Console.WriteLine("No such type!");
                else
                    Console.WriteLine("Incorect input!");
                Console.Clear();
            }
        }
        private int SelectCurrencyType()
        {
            int currency = 0;
            while (true)
            {
                Console.WriteLine("Select currency:");
                Console.WriteLine("1-USD");
                Console.WriteLine("2-EUR");
                Console.WriteLine("3-GRN");
                string str = Console.ReadLine();
                if (int.TryParse(str, out currency))
                    if (currency > 0 && currency <= 3)
                        return currency;
                    else
                        Console.WriteLine("No such type!");
                else
                    Console.WriteLine("Incorect input!");
                Console.Clear();
            }
        }
    }
}
