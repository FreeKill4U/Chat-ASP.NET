using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public virtual List<Chat> Chats { get; set; }
        public string Role { get; set; } = "user";
        public string Token { get; set; }
    }
}
