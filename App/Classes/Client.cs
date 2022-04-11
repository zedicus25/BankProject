using App.Interfaces;
using System;
using System.Text;


namespace App.Classes
{
    delegate ICard CreateCard(int type);
    internal class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IBAN Iban { get; set; }
        public ICard[] Cards { get; set; }
        private CreateCard[] _createCards;
        public Client()
        {
            Cards = new ICard[0];
            _createCards = new CreateCard[]
            {
                CreateVisa
            };
        }
        public void AddCard()
        {
            int cardType = SelectCardType();
            int currency = SelectCurrencyType();
            
            ICard[] tmp = new ICard[Cards.Length];
            Cards.CopyTo(tmp, 0);
            Cards = new ICard[tmp.Length+1];
            tmp.CopyTo(Cards, 0);
            Cards[Cards.Length-1] = _createCards[currency - 1]?.Invoke(currency);
        }

        private ICard CreateVisa(int type)
        {
            return new VisaCard(0);
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
