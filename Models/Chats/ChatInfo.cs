using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Models.Chats
{
    public class ChatInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Icon { get; set; }
        public string Color { get; set; }
        public string LastMessage { get; set; }
    }
}
