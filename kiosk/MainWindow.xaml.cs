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
            homeinfo.DataContext = homedata;
        }
        public void renderpg(object sender, RoutedEventArgs e)
        {
            kiosk.vInfoViewModel.homeViewModel homedata = new kiosk.vInfoViewModel.homeViewModel();
            homedata.LoadScreen2();
            homeinfo.DataContext = homedata;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}


