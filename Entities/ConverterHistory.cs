using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Entities;

public class ConverterHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public double Amount { get; set; }
    public double Result { get; set; }
    public DateTime Date { get; set; }
    
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [ForeignKey(nameof(CurrencyTo))]
    public int CurrencyToId { get; set; }
    public Currency? CurrencyTo { get; set; }
    
    [ForeignKey(nameof(CurrencyFrom))]
    public int CurrencyFromId { get; set; }
    public Currency? CurrencyFrom { get; set; }
}