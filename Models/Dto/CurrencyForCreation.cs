using System.ComponentModel.DataAnnotations;

namespace CurrencyController.Models.Dto
{
    public class CurrencyForCreation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public double Value { get; set; }
    }
}