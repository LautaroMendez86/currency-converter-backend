using System.ComponentModel.DataAnnotations;

namespace CurrencyController.Models.Dto
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
