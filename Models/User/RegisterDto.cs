using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Models
{
    public class RegisterDto
    {
        [Required]
        public string Nick { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
