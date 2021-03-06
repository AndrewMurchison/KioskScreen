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
using System.Windows.Shapes;
using kiosk.db;

namespace kiosk
{
    /// <summary>
    /// Interaction logic for modal.xaml
    /// </summary>
    public partial class modal : Window
    {
        Window win;

        String name;



        public modal(Window window, String nm, kiosk.vInfoViewModel.vViewModel sTicket)
        {
            InitializeComponent();
            amount.DataContext = sTicket;
           
            name = nm;
            win = window;

           


        }

        public void replayvid(object sender, EventArgs e)
        {
           
            video.Position = TimeSpan.FromSeconds(0);
            video.Play();
            
        }

        public void close(object sender, RoutedEventArgs e)
        {
            
            Button btn = (Button)sender;

            if (btn.Name.Equals("finish")){
                Window home = new MainWindow();
                
                home.Show();
                win.Close();


            }
            
            win.Opacity = 1.0;
            this.Close();
            
        }

        public void loadmodal(object sender, RoutedEventArgs e)
        {
            if (name.Equals("cash"))
            {
                kiosk.vInfoViewModel.ModalViewModel mod = new kiosk.vInfoViewModel.ModalViewModel();
                mod.LoadCashModal();
                ldmodal.DataContext = mod;
                video.Source = new Uri(@"../../Img/cash.avi", UriKind.RelativeOrAbsolute);
            }
            else
            {
                kiosk.vInfoViewModel.ModalViewModel mod = new kiosk.vInfoViewModel.ModalViewModel();
                mod.LoadCreditModal();
                ldmodal.DataContext = mod;
                video.Source = new Uri(@"../../Img/credit.avi", UriKind.RelativeOrAbsolute);
            }

        }
    }
}
