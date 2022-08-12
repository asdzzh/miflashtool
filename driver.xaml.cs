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

namespace WPFUIKitProfessional
{
    /// <summary>
    /// driver.xaml 的交互逻辑
    /// </summary>
    public partial class driver : Page
    {
        public driver()
        {
            InitializeComponent();
        }


        private delegate void DelegateFunction(int ipos);

        //执行函数
        void StartWork()
        {
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                //ADB检测
                Process f = new Process();
                f.StartInfo.FileName = "cmd.exe";
                f.StartInfo.UseShellExecute = false;
                f.StartInfo.RedirectStandardInput = true;
                f.StartInfo.RedirectStandardError = true;
                f.StartInfo.RedirectStandardOutput = true;
                f.StartInfo.CreateNoWindow = true;

                f.Start();
                f.StandardInput.WriteLine("cd drivers");
                f.StandardInput.WriteLine("start adb-setup-1.4.2.exe");
                f.StandardInput.WriteLine("exit");
                f.WaitForExit();
                f.Close();
            });
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread multi = new Thread(new ThreadStart(StartWork));
            multi.IsBackground = true;
            multi.Start();
        }
    }
}
