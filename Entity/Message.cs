using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public virtual Chat Chat { get; set; }
        public int AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
