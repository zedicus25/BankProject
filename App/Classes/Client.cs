using App.Interfaces;
using System;
using System.Text;


namespace App.Classes
{
    internal class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IBAN Iban { get; private set; }
        public ICard[] Cards { get; set; }

        public Client(string name, string lastName, string bankID)
        {
            Iban = new IBAN(bankID);
            Name = name;
            LastName = lastName;
            Cards = new ICard[0];
        }
        public void AddCard(Manager manager)
        {
            manager.CreateNewCard(this);
        }

        public void SendMoney()
        {
            int card = 0;
            Console.WriteLine("Select card which one to send: ");
            for (int i = 0; i < Cards.Length; i++)
            {
                Console.WriteLine($"{i+1} - {Cards[i].ToString()}");
            }
            string str = Console.ReadLine();
            int.TryParse(str, out card);

            if (card <= 0 || card > Cards.Length)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Press any key to exit");
                return;
            }
            Console.WriteLine("Enter card number ");
            string number = Console.ReadLine();
            if(number.Length < 16)
            {
                Console.WriteLine("Incorrect number");
                Console.WriteLine("Press any key to exit");
                return;
            }
            Cards[card - 1].GetAction(0)?.Invoke(number);
        }

        public void TopUpTheCard()
        {
            int card = 0;
            Console.WriteLine("Select the card which one to top up: ");
            for (int i = 0; i < Cards.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {Cards[i].ToString()}");
            }
            string str = Console.ReadLine();
            int.TryParse(str, out card);

            if(card <= 0 || card > Cards.Length)
            {
                Console.WriteLine("Incorrect input!");
                Console.WriteLine("Press any key to exit");
                return;
            }
            Cards[card - 1].GetAction(1)?.Invoke(Cards[card - 1].GetNumber());
        }
    }
}
