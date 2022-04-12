using App.Interfaces;
using System;
using System.Text;


namespace App.Classes
{
    internal class SimpleBank : IBank
    {
        public Manager[] Managers;
        string Name { get; set; }
        public string BankID { get; private set; }
        private Client[] _clients = new Client[0];
        public SimpleBank(string name)
        {
            Name = name;
            Managers = new Manager[]
            {
                new Manager("John","Brakey",this)
            };
            BankID = GenerateID().ToString();
        }

        public void AddClient(Client client)
        {
            Array.Resize(ref _clients, _clients.Length+1);
            _clients[_clients.Length - 1] = client;
        }
        public void AddManager(Manager manager)
        {
            Array.Resize(ref Managers, Managers.Length + 1);
            Managers[Managers.Length - 1] = manager;
        }

        public string GetID()
        {
            return BankID;
        }
        public Manager GetManger(int ind)
        {
            if (ind >= 0 && ind < Managers.Length)
                return Managers[ind];
            return null;
        }
        public Client GetClient(int ind)
        {
            if (ind >= 0 && ind < _clients.Length)
                return _clients[ind];
            return null;
        }
        public Client[] GetClients()
        {
            return _clients;
        }

        private int GenerateID()
        {
            Random rand = new Random();
            return rand.Next(10000, 99999);
        }
    }
}
