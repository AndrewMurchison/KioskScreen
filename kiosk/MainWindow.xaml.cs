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

namespace kiosk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            InitializeComponent();
            valetviewctrl.DataContext = null;
           
           
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
            if (e.Key == Key.Return)
            {
                kiosk.vInfoViewModel.homeViewModel homedata = new kiosk.vInfoViewModel.homeViewModel();
                homedata.LoadScreen2();
                MainGrid.DataContext = homedata;

                if (valetviewctrl.DataContext != null)
                {
                    Button scanned = new Button();
                    scanned.Name = "scn";
                    popup(scanned, e);
                }
                else
                {
                    
                    popup(sender, e);
                }
                kiosk.vInfoViewModel.vViewModel vdata = new kiosk.vInfoViewModel.vViewModel();
                vdata.LoadTicket();
                valetviewctrl.DataContext = vdata;
                vdata.ClearTicket();
                cash.IsEnabled = true;
                card.IsEnabled = true;
                
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
        


        }

        public void popup(object sender, RoutedEventArgs e)
        {
            var name = (Control)sender;
            Window noti = new notifications(name.Name,System.Windows.SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenHeight);
            noti.ShowDialog();
        }

        public void payClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Window newin = new modal(this, button.Name);
            this.Opacity = 0.1;
            newin.ShowDialog();
           
        }

        


    }
    
}


//[DllImport("testreader.dll")] testing calls to dll have to build dll then move it to bin directory of working project
//public static extern int add();