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
using System.Windows.Shapes;

namespace kiosk
{
    /// <summary>
    /// Interaction logic for notifications.xaml
    /// </summary>
    public partial class notifications : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        double height;
        double width;
        
        public notifications(double wt, double ht)
        //public notifications(String title, String msg, int time)
        {
            
            width = wt;
            height = ht;
            this.Top = 0;
            this.Left = (width/2)-300;
            this.Opacity = 0;
            fadeIn();
            

        }

        public async void fadeOut(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            while (this.Top > 0)
            {
                await Task.Delay(1);
                this.Top = this.Top - 30;
                this.Opacity = this.Opacity - 0.1;
            }
            this.Close();


        }
        public async void fadeIn()
        {
            InitializeComponent();
            while (this.Top<(height/2)-150)
            {
                await Task.Delay(1);
                this.Top = this.Top + 30;
                this.Opacity = this.Opacity + 0.1;
                
            }
            
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(fadeOut);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();


        }

       

        

    }
}
