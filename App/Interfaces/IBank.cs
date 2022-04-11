using System;
using System.Text;
using App.Classes;

namespace App.Interfaces
{
    internal interface IBank
    {
        Client GetClient(int ind);
        void AddClient(Client client);
        Client[] GetClients();
    }
}
