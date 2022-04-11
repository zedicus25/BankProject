using App.Interfaces;
using System;
using System.Text;


namespace App.Classes
{
    internal class SimpleBank : IBank
    {
        public Client[] Clients { get; private set; }
        public void AddClient(Client client)
        {
          
        }

        public Client GetClient(int ind)
        {
            if(ind > 0 && ind < Clients.Length)
                return Clients[ind];
            return null;
        }

        public Client[] GetClients()
        {
            return Clients;
        }
    }
}
