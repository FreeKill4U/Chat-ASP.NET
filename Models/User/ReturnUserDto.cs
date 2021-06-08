using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Models.User
{
    public class ReturnUserDto
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Token { get; set; }
    }
}
