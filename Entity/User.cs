using Microsoft.EntityFrameworkCore;
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
        public string Token { get; set; }
        public string Color { get; set; }
        public int Icon { get; set; }
        public string IconColor { get; set; }
    }
}
