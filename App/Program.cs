using System;
using App.Classes;
namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.AddCard();
            client.AddCard();
        }
    }
}
