using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Szkolka.Entity
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Messege> Messeges { get; set; }
        public virtual List<Rank> Ranks { get; set; }
    }
}
