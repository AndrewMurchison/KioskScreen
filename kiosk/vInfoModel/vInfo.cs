using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace kiosk.vInfoModel
{
    class vInfo
    {
    }

    public class ticketinfo : INotifyPropertyChanged
    {
        private string ticketnum;
        private string validations;
        private string amt;
      

        public string TicketNum
        {
            get
            {
                return ticketnum;
            }

            set
            {
                if (ticketnum != value)
                {
                    ticketnum = value;
                    RaisePropertyChanged("TicketNum");
                    RaisePropertyChanged("TicketInfo");

                }
            }
        }

        public string Validations
        {
            get { return validations; }

            set
            {
                if (validations != value)
                {
                    validations = value;
                    RaisePropertyChanged("Validations");
                    RaisePropertyChanged("TicketInfo");

                }
            }
        }

        public string Amt
        {
            get { return amt; }

            set
            {
                if (amt != value)
                {
                    amt = value;
                    RaisePropertyChanged("Amt");
                    RaisePropertyChanged("TicketInfo");

                }
            }
        }


        public string TicketInfo
        {
            get
            {
                return ticketnum + " " + validations + " " + amt;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
