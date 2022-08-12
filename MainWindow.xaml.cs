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
using WPFUIKitProfessional.Themes;
using WPFUIKitProfessional.Pages;

namespace WPFUIKitProfessional
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PagesNavigation.Navigate(new System.Uri("Welcome.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
            else
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdreboot_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("SoundsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdroot_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("NotesPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdrec_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("pagerec.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdother_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("pageother.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdmessage_click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("xinxi.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdxiaoxi_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("tongzhi.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdsettings_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("settings.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
