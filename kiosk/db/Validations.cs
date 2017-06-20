using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.db
{
    public class Validations
    {
        public String nm;
        public Double amount;
        public Validations(String name, Double amt)
        {
            this.nm = name;
            this.amount = amt;

        }
        public Validations[] populate()
        {
            Validations[] valid;
            valid = new Validations[5];
            valid[0] = new Validations("HP", 7.00);
            valid[1] = new Validations("dog", 9.00);
            valid[2] = new Validations("uncle", 2.00);
            valid[3] = new Validations("senior", 3.00);
            valid[4] = new Validations("trainwreck", 14.00);
            return valid;
        }
    }
}
