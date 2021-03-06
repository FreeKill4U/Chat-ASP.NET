using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AuthenticateDto
    {
        [Required]
        public string Nick { get; set; }

        [Required]
        public string Password { get; set; }
    }
}