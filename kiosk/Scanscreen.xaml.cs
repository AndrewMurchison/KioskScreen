﻿using System;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Scanscreen : UserControl
    {
        public Scanscreen()
        {
            InitializeComponent();
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
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
        
       

       
       
    }
}
