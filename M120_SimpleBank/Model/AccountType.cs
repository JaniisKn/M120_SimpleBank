using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_SimpleBank.Model
{
    public class AccountType
    {
        public int AccountTypeID { get; set; }
        public string Name { get; set; }
        public float InterestRate { get; set; }
    }
}
