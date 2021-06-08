using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Helpers.Exceptions
{
    public class ThisUserExistsException : Exception
    {
        public ThisUserExistsException(string message) : base(message)
        {
        }
    }
}
