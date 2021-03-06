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
        int time;

        
        //public notifications(double wt, double ht)
        public notifications(String name, double wt, double ht)
        {
            
            width = wt;
            height = ht;
            this.Top = 0;
            this.Left = (width/2)-300;
            this.Opacity = 0;
            InitializeComponent();
            if (name.Equals("help"))
            {
                message.Text = "A valet worker has been alerted and will assist you shortly";
                time = 3;
            }
           else if (name.Equals("scn"))
            {
                message.Text = "Ticket already scanned. Please scan any validations/proceed to the payment screen or cancel the transaction.";
                time = 3;
            }
            else if (name.Equals("invalid"))
            {
                message.Text = "Invalid Ticket! Please scan a valid ticket.";
                time = 3;
            }
            else if (name.Equals("vValid"))
            {
                message.Text = "Validation Scanned";
                time = 1;
            }
            else if (name.Equals("vInvalid"))
            {
                message.Text = "Invalid Validation Ticket! Scan active Validation or proceed to payment checkout.";
                time = 3;
            }
            else
            {
                message.Text = "Ticket Scanning";
                time = 1;
            }
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
            
            while (this.Top<(height/2)-150)
            {
                await Task.Delay(1);
                this.Top = this.Top + 30;
                this.Opacity = this.Opacity + 0.1;
                
            }
            
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(fadeOut);
            dispatcherTimer.Interval = new TimeSpan(0, 0, time);
            dispatcherTimer.Start();


        }

       

        

    }
}
