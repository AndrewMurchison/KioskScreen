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
using kiosk.vInfoViewModel;
namespace kiosk
{
    /// <summary>
    /// Interaction logic for valetinfo.xaml
    /// </summary>
    public partial class valetinfo : UserControl
    {
        vViewModel viewmod;
        public valetinfo(vViewModel fish)
        {
            viewmod = fish;
            reinitialize();
        }

        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            time.Text = DateTime.Now.ToString("h:mm:ss tt");

        }
       


        public void reinitialize()
        {
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            InitializeComponent();


        }

        private void valetviewctrl_Loaded(object sender, RoutedEventArgs e)
        {


            valetviewctrl.DataContext = viewmod;
        }

        public void gohome(object sender, EventArgs e)
        {

            this.Content = new Scanscreen();
           
        }
    }
}
