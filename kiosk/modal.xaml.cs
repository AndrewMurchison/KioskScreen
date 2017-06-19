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
    /// Interaction logic for modal.xaml
    /// </summary>
    public partial class modal : Window
    {
        Window win;
        public modal(Window window)
        {
            win = window;
            InitializeComponent();
            
            
        }
        public void close(object sender, RoutedEventArgs e)
        {
            this.Close();
            win.Opacity = 1.0;
        }
    }
}
