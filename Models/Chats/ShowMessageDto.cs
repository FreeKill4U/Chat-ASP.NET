using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Models.Chats
{
    public class ShowMessageDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string ColorAuth { get; set; } = "#00D700";
        public DateTime Date { get; set; }
        public int ChatId { get; set; }
    }
}
