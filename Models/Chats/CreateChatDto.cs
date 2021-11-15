using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;

namespace SzkolaKomunikator.Models.Chat
{
    public class CreateChatDto
    {
        public string Name { get; set; }
        public int Icon { get; set; }
        public string Color { get; set; }
    }
}
