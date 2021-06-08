using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Models.Chats
{
    public class AddUserDto
    {
        public string UserNick { get; set; }
        public int ChatId { get; set; }
    }
}
