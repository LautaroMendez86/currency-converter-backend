namespace CurrencyController.Models.Dto
{
    public class CurrencyConversionDto
    {
        public int FromCurrency { get; set; }
        public int ToCurrency { get; set; }
        public double Amount { get; set; }
    }
}
