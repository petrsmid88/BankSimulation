using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Types;

namespace Bank.Objects
{
    class Customer : User
    {
        private String SSN { get; set; }

        private String Password { get; set; }

        private Boolean Valid { get; set; }

        private CustomerType CustomerType { get; set; }

    }
}
