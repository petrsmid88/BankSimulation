﻿using System;
using Bank.Types;

namespace Bank.Objects
{
    public class Customer : User
    {
        public String SSN { get; set; }

        public String Password { get; set; }

        public CustomerType CustomerType { get; set; }

    }
}
