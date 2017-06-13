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
using System.Runtime.InteropServices;
using kiosk.vInfoViewModel;

namespace kiosk
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Scanscreen : UserControl
    {
       vViewModel viewmod;
        public Scanscreen()
        {

            reinitialize();
        }
        
        public void replayvid(object sender, EventArgs e)
        {
            med.Position = TimeSpan.FromSeconds(0);
            med.Play();
        }

        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           
            time.Text = DateTime.Now.ToString("h:mm:ss tt");
            
        }
        public void scanclick(object sender, RoutedEventArgs e)
        {
           
            this.Content = new valetinfo(viewmod);
        }

        public void onload(object sender, RoutedEventArgs e)
        {
            kiosk.vInfoViewModel.vViewModel valetViewModelObject = new kiosk.vInfoViewModel.vViewModel();
            valetViewModelObject.LoadTicket();
            viewctrl.DataContext = valetViewModelObject;
            viewmod = valetViewModelObject;
        }


        public void reinitialize()
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            InitializeComponent();
           

        }

       





    }
}


//[DllImport("testreader.dll")] testing calls to dll have to build dll then move it to bin directory of working project
//public static extern int add();