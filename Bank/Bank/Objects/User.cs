using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Objects
{
    class User
    {
        public String Name { get; set; }
        public String SurName { get; set; }
        public Address Address { get; set; }
        public String Mail { get; set; }
        public String Phone { get; set; }
        public Boolean Valid { get; set; }
    }
}
