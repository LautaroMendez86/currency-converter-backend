using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Entities
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set;}
        public int Price { get; set; }
        public int TotalAvailableConversions { get; set; }
        public List<User>? Users { get; set; }
    }
}
