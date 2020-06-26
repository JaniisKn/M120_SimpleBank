using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Model
{
    class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EMail { get; set; }
        public string TelNumber { get; set; }
        public string Address { get; set; }
        public int PostCode { get; set; }
        public DateTime Birthday { get; set; }
    }
}
