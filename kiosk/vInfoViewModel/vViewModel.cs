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
        mockdb.Ticket searchedTicket;
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
            tiklist[0] = new mockdb.Ticket("9004", valid, 20.00);
            tiklist[1] = new mockdb.Ticket("8096", valid, 16.00);
            tiklist[2] = new mockdb.Ticket("5076", valid, 95.00);
            tiklist[3] = new mockdb.Ticket("1009", valid, 30.00);
            tiklist[4] = new mockdb.Ticket("7056", valid, 23.00);
            return tiklist;
        }

        public void LoadTicket(mockdb.Ticket ticketinfo, Validations validate)
        {
            ObservableCollection<ticketinfo> ticket = new ObservableCollection<ticketinfo>();
            
            if (ticketinfo == null)
            {

                ticket.Add(new ticketinfo { TicketNum = "Invalid Ticket", Validations = "", Amt = ""});
            }
            else {
                
                if (validate == null)
                {
                    
                    ticket.Add(new ticketinfo { TicketNum = ticketinfo.tiknum, Validations = "", Amt = ticketinfo.total.ToString() });
                }
                else
                {
                    
                    double total = ticketinfo.total - validate.amount;
                    ticket.Add(new ticketinfo { TicketNum = ticketinfo.tiknum, Validations = validate.nm, Amt = total.ToString() });
                }
                
            }
            searchedTicket = ticketinfo;

            Tik = ticket;
        }

       public mockdb.Ticket getTicket()
        {
            
            return searchedTicket;
        }


        public void ClearTicket()
        {
            ObservableCollection<ticketinfo> ticket = new ObservableCollection<ticketinfo>();

            ticket.Add(new ticketinfo { TicketNum = null, Validations = null, Amt = null});

            Tik = ticket;
        }

        public void searchTickets(String ticket)
        {
            mockdb.Ticket found = null;
            
            for(int i = 0; i<ticketlist.Length; i++)
            {
                if (ticket.Equals(ticketlist[i].tiknum))
                {
                    found = ticketlist[i];
                }
            }

            LoadTicket(found, null);
            
            
        }

        public Boolean searchValidations(mockdb.Ticket num, String validations)
        {
            Validations[] validation = num.valid;
            Validations validate = null;
            for(int i = 0; i<validation.Length; i++)
            {
                if (validations.Equals(validation[i].nm))
                {
                    validate = validation[i];
                }
            }
            if (validate == null)
            {
                return false;
            }
            LoadTicket(num, validate);
            return true;

        }
        
    }
}
