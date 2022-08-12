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
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.ComponentModel;    
using System.Windows.Threading;


namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Lógica de interacción para SoundsPage.xaml
    /// </summary>
    public partial class SoundsPage : Page
    {
        public static int aaa = 0;
        public SoundsPage()
        {

            InitializeComponent();



        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread multi = new Thread(new ThreadStart(StartWork));
            aaa = 1;
            multi.IsBackground = true;
            multi.Start();
            


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread multi = new Thread(new ThreadStart(StartWork));
            aaa = 2;
            multi.IsBackground = true;
            multi.Start();

            


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Thread multi = new Thread(new ThreadStart(StartWork));
            aaa = 3;
            multi.IsBackground = true;
            multi.Start();




            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Thread multi = new Thread(new ThreadStart(StartWork));
            aaa = 4;
            multi.IsBackground = true;
            multi.Start();
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            Thread multi = new Thread(new ThreadStart(StartWork));
            aaa = 5;
            multi.IsBackground = true;
            multi.Start();



        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            Thread multi = new Thread(new ThreadStart(StartWork));
            aaa = 6;
            multi.IsBackground = true;
            multi.Start();
            
        }


    

        private delegate void DelegateFunction(int ipos);

        //执行函数
        void StartWork()
        {

            //...........
            //在这里执行一个非常非常耗时的函数 DoLongTimeWork()
            if (aaa == 1)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("adb reboot");
                p.StandardInput.WriteLine("exit");
                p.WaitForExit(100);
                p.Close();
            }

            if (aaa == 2)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("fastboot reboot");
                p.StandardInput.WriteLine("exit");
                p.WaitForExit(100);
                p.Close();
            }

            if (aaa == 3)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("adb reboot-bootloader");
                p.StandardInput.WriteLine("exit");
                p.WaitForExit(100);
                p.Close();
            }

            if (aaa == 4)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("adb reboot recovery");
                p.StandardInput.WriteLine("exit");
                p.WaitForExit(500);
                p.Close();
            }

            if (aaa == 5)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("adb reboot edl");
                p.StandardInput.WriteLine("exit");
                p.WaitForExit(500);
                p.Close();
            }

            if (aaa == 6)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("fastboot oem edl");
                p.StandardInput.WriteLine("exit");
                p.WaitForExit(500);
                p.Close();
            }


        }







    }


}
