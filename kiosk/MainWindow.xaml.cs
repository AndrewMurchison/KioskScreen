using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using kiosk.db;


namespace kiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        mockdb.Ticket searchedTicket;
        kiosk.vInfoViewModel.vViewModel lddata;
        public MainWindow()
        {
           var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            InitializeComponent();
            valetviewctrl.DataContext = null;
            tikimg.Source = new BitmapImage(new Uri(@"/Images/scanTicket.png", UriKind.Relative));



        }

       public void dispatcherTimer_Tick(object sender, EventArgs e)
        {

           time.Text = DateTime.Now.ToString("h:mm:ss tt");

        }

       public void replayvid(object sender, EventArgs e)
       {
            med.Position = TimeSpan.FromSeconds(0);
            med.Play();
        }

        private void homescreenctrl(object sender, RoutedEventArgs e)
        {
            kiosk.vInfoViewModel.homeViewModel homedata = new kiosk.vInfoViewModel.homeViewModel();
            homedata.LoadScreen1();
            MainGrid.DataContext = homedata;

            cash.IsEnabled = false;
            card.IsEnabled = false;

        }
        public void scantik(object sender, KeyEventArgs e)
        {
            var name = (Control)sender;
            if (e.Key == Key.Return)
            {

                String scanned = entr.Text;
                if (valetviewctrl.DataContext != null)
                {
                    
                    kiosk.vInfoViewModel.vViewModel vdata = new kiosk.vInfoViewModel.vViewModel();
                    bool isValid = vdata.searchValidations(searchedTicket, scanned);
                    
                    if (isValid)
                    { 
                        popup("vValid");
                        lddata = vdata;
                        valetviewctrl.DataContext = vdata;
                    }
                    else
                    {
                        popup("vInvalid");
                        valetviewctrl.DataContext = lddata;
                    }
                    

                }
                else
                {

                    
                    kiosk.vInfoViewModel.vViewModel vdata = new kiosk.vInfoViewModel.vViewModel();
                    vdata.searchTickets(scanned);
                    searchedTicket = vdata.getTicket();
                    if (searchedTicket == null)
                    {
                        
                        popup("invalid");
                    }
                    else
                    {
                        popup(name.Name);
                        kiosk.vInfoViewModel.homeViewModel homedata = new kiosk.vInfoViewModel.homeViewModel();
                        homedata.LoadScreen2();
                        MainGrid.DataContext = homedata;

                        valetviewctrl.DataContext = vdata;
                        lddata = vdata;
                        
                        cash.IsEnabled = true;
                        card.IsEnabled = true;
                        tikimg.Source = new BitmapImage(new Uri(@"scanValidation.png", UriKind.Relative));
                    }
                }
            }
        }

        public void cancelscan(object sender, RoutedEventArgs e)
        {
            kiosk.vInfoViewModel.homeViewModel homedata = new kiosk.vInfoViewModel.homeViewModel();
            homedata.LoadScreen1();
            MainGrid.DataContext = homedata;
            valetviewctrl.DataContext = null;

            cash.IsEnabled = false;
            card.IsEnabled = false;
            tikimg.Source = new BitmapImage(new Uri(@"/Images/scanTicket.png", UriKind.Relative));


        }

        public void msgdelegator(object sender, RoutedEventArgs e)
        {
            var name = (Control)sender;
            popup(name.Name);
        }

        public void popup(String name)
        {
            
            Window noti = new notifications(name,System.Windows.SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenHeight);
            noti.ShowDialog();
        }

        public void payClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Window newin = new modal(this, button.Name, lddata);
            this.Opacity = 0.1;
            newin.ShowDialog();
           
        }

        


    }
    
}


//[DllImport("testreader.dll")] testing calls to dll have to build dll then move it to bin directory of working project
//public static extern int add();