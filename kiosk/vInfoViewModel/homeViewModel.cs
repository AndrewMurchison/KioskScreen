using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.vInfoModel;
using System.Collections.ObjectModel;

namespace kiosk.vInfoViewModel
{
    public class homeViewModel
    {
        
        public ObservableCollection<homescreen> Home
        {
            get;
            set;
        }

        public void LoadScreen1()
        {
            ObservableCollection<homescreen> home = new ObservableCollection<homescreen>();

            home.Add(new homescreen { Greeting = "Welcome\nPlease Scan your Valet Ticket", Scanimg = "ticketimg", ScanningMsg="Bar Code Faces Up" });


            Home = home;
        }

        public void LoadScreen2()
        {
            ObservableCollection<homescreen> home = new ObservableCollection<homescreen>();

            home.Add(new homescreen { Greeting = "Scan Validations or\nPick a Payment Option", Scanimg = "validationimg", ScanningMsg="Validation Bar Code Faces Up"});


            Home = home;
        }

    }
}
