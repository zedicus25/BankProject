using System;
using App.Classes;
namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleBank simpleBank = new SimpleBank("MonoBank");
            simpleBank.GetManger(0).AddClient();
            simpleBank.GetManger(0).AddClient();
            simpleBank.GetManger(0).CreateNewCard(simpleBank.GetClient(0));
            simpleBank.GetManger(0).CreateNewCard(simpleBank.GetClient(1));
            Console.WriteLine();
            Console.WriteLine(simpleBank.GetClient(1).Cards[0].ShowAllInfo());
            Console.WriteLine();
            simpleBank.GetClient(0).TopUpTheCard();
            simpleBank.GetClient(0).SendMoney();
            Console.WriteLine();
            Console.WriteLine(simpleBank.GetClient(0).Cards[0].ShowBalance());
            Console.WriteLine(simpleBank.GetClient(1).Cards[0].ShowBalance());
        }
    }
}
