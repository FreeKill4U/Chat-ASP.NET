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
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
