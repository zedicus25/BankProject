using App.Classes;

namespace App.Interfaces
{
    internal interface ICard
    {
        string GenerateNumber(string bankID);
        int GenerateCVV();
        int GeneratePin();
        void ChangePin();
        string GetNumber();
        CurrencyType GetCurrency();
        IBAN GetIban();
        void SendMoney(string cardNumber);
        void TopUpTheCard(string cardNumber);
        string ShowAllInfo();
        string ShowBalance();

    }
}
