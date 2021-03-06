using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Entity
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Message> Messeges { get; set; }
        public string Color { get; set; }
        public int Icon { get; set; }
    }
}
