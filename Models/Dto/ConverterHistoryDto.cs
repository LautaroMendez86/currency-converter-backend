namespace CurrencyController.Models.Dto;

public class ConverterHistoryDto
{
    public int CurrencyTo { get; set; }
    public int CurrencyFrom { get; set; }
    public double Amount { get; set; }
    public int UserId { get; set; }
    public double Result { get; set; }
    public DateTime Date { get; set; }
}