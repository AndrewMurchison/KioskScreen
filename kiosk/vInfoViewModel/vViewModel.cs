using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.vInfoModel;
using System.Collections.ObjectModel;
using kiosk.db;

namespace kiosk.vInfoViewModel
{
    public class vViewModel
    {
        Validations[] valid;
        mockdb.Ticket[] ticketlist;
        public ObservableCollection<ticketinfo> Tik
        { 
            get;
            set;
        }

        public vViewModel()
        {

            ticketlist = ticketmaker();
            
        }

        public mockdb.Ticket[] ticketmaker()
        {
            var v = new Validations("fish", 12.0).populate();
            valid = v;
            mockdb.Ticket[] tiklist;
            tiklist = new mockdb.Ticket[5];
            tiklist[0] = new mockdb.Ticket(9004, valid, 20.00);
            tiklist[1] = new mockdb.Ticket(8096, valid, 16.00);
            tiklist[2] = new mockdb.Ticket(5076, valid, 95.00);
            tiklist[3] = new mockdb.Ticket(1009, valid, 30.00);
            tiklist[4] = new mockdb.Ticket(7056, valid, 23.00);
            return tiklist;
        }

        public void LoadTicket()
        {
            ObservableCollection<ticketinfo> ticket = new ObservableCollection<ticketinfo>();

            ticket.Add(new ticketinfo { TicketNum = ticketlist[0].tiknum.ToString(), Validations = ticketlist[0].valid[0].nm, Amt = ticketlist[0].total.ToString(), Payopt = "Credit/Debit"});
           

            Tik = ticket;
        }

        public void ClearTicket()
        {
            ObservableCollection<ticketinfo> ticket = new ObservableCollection<ticketinfo>();

            ticket.Add(new ticketinfo { TicketNum = null, Validations = null, Amt = null, Payopt = null });


            Tik = ticket;
        }
    }
}
