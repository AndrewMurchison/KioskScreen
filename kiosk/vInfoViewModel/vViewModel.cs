using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.vInfoModel;
using System.Collections.ObjectModel;

namespace kiosk.vInfoViewModel
{
    public class vViewModel
    {
        public ObservableCollection<ticketinfo> Tik
        { 
            get;
            set;
        }

        public void LoadTicket()
        {
            ObservableCollection<ticketinfo> ticket = new ObservableCollection<ticketinfo>();

            ticket.Add(new ticketinfo { TicketNum = "", Validations = "HP", Amt = "$7.00", Payopt = "Credit/Debit"});
           

            Tik = ticket;
        }
    }
}
