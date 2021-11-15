using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Models.User
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Color { get; set; }
        public int Icon { get; set; }
        public string IconColor { get; set; }
    }
}
