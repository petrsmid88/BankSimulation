using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Bank.Types;

namespace Bank.Objects
{
    class Official : User
    {
        private OfficialType OfficialType { get; set; }
        public String CompanyNumber { get; set; }
        public String Password { get; set; }
    }
}
