using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace kiosk.vInfoModel
{
    class homeModel
    {
    }

    public class homescreen : INotifyPropertyChanged
    {
        private String greeting;
        private String scanimg;
        // This might be linked to other model private String infofield;
        

        public string Greeting
        {
            get
            {
                return greeting;
            }
            set
            {
                if (greeting != value)
                {
                    greeting = value;
                    RaisePropertyChanged("Greeting");
                   

                }
            }
        }

        public string Scanimg
        {
            get
            {
                return scanimg;
            }
            set
            {
                if (scanimg != value)
                {
                    scanimg = value;
                    RaisePropertyChanged("Scanimg");


                }
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
