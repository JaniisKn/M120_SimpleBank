using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_SimpleBank.Model
{
    public class Account
    {
        public float Balance { get; set; }
        public int PersonID { get; set; }
        public int AccountTypeID { get; set; }
    }
}
