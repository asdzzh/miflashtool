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

namespace UIKitTutorials.Pages
{
    /// <summary>
    /// pageother.xaml 的交互逻辑
    /// </summary>
    public partial class pageother : Page
    {
        public pageother()
        {
            InitializeComponent();
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("bltestt.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdreboot_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("driver.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdroot_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("fuckitout.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdrec_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("boot.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdother_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("pageother.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
