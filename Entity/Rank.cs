using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Entity
{
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual List<User>  Users { get; set; }

        //Setting
        public bool SendMessege { get; set; } = true;
        public bool SendPhoto { get; set; } = true;
        public bool AddUser { get; set; } = false;
        public bool RemoveUser { get; set; } = false;
        public bool GiveRank { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public bool NewUser { get; set; } = true;

        public bool Mention { get; set; } = true;
        public bool ColorText { get; set; } = true;
        public bool Reaction { get; set; } = true;
    }
}
