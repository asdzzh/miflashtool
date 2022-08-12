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

namespace UIKitTutorials
{
    /// <summary>
    /// finishrec.xaml 的交互逻辑
    /// </summary>
    public partial class finishrec : Page
    {
        public finishrec()
        {
            InitializeComponent();
        }

        private void PagesNavigation_Navigated(object sender, NavigationEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                PagesNavigation.Navigate(new System.Uri("payforme.xaml", UriKind.RelativeOrAbsolute));
            });
        }
    }
}
