﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.db
{
    public class mockdb
    {
        public class Ticket
        {
            public String tiknum;
            public Validations[] valid;
            public Double total;

            public Ticket(String tik, Validations[] v, Double amt)
            {
                tiknum = tik;
                valid = v;
                total = amt;
            }
           

        }
    }
}
