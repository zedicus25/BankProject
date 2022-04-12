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
            Console.WriteLine(simpleBank.GetClient(0).Cards[0].ShowAllInfo()); 
            simpleBank.GetClient(0).TopUpTheCard();
            Console.WriteLine(simpleBank.GetClient(0).Cards[0].ShowBalance());
        }
    }
}
