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
            Name = "Jonh";
            LastName = "Brush";
            Cards = new ICard[0];
        }
        public void AddCard(Manager manager)
        {
            manager.CreateNewCard(this);
        }

        public void SendMoney()
        {
            Cards[0].SendMoney(Cards[1].GetNumber());
        }

        public void TopUpTheCard()
        {
            Cards[0].TopUpTheCard(Cards[0].GetNumber());
        }
    }
}
