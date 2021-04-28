using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Helpers.Exceptions
{
    public class IncorrectDataException : Exception
    {
        public IncorrectDataException(string message) : base(message)
        {
        }
    }
}
