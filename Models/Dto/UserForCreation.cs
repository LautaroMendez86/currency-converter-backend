using System.ComponentModel.DataAnnotations;

namespace CurrencyController.Models.Dto
{
    public class UserForCreation
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
