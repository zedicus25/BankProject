using App.Classes;

namespace App.Interfaces
{
    internal interface ICard
    {
        string GenerateNumber(string bankID);
        int GenerateCVV();
        int GeneratePin();
        void ChangePin();
        CurrencyType GetCurrency();
    }
}
