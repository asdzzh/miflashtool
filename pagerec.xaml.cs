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
using System.Threading;


namespace UIKitTutorials.Pages
{
    /// <summary>
    /// pagerec.xaml 的交互逻辑
    /// </summary>
    public partial class pagerec : Page
    {
        public pagerec()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Thread multi = new Thread(new ThreadStart(StartWork));
            multi.IsBackground = true;
            multi.Start();

            
        }

        private delegate void DelegateFunction(int ipos);

        //执行函数
        void StartWork()
        {
            string messageBoxText = "请确认手机现在是否在系统界面，若在锁屏或桌面请点'是'，若在fastboot界面请点'否'，若都不是(如官方rec界面)就点取消";
            string caption = "确认目前的手机状态";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);



            switch (result)
            {
                case MessageBoxResult.Cancel:
                    // User pressed Cancel
                    MessageBox.Show("请长按电源键重启至系统后再尝试使用本功能");
                    break;
                case MessageBoxResult.Yes:

                    // User pressed Yes
                    // Configure open file dialog box
                    var dialog = new Microsoft.Win32.OpenFileDialog();
                    dialog.FileName = "请选择下载好的第三方rec的img文件"; // Default file name
                    dialog.DefaultExt = ".img"; // Default file extension
                    dialog.Filter = "img镜像文件 (.img)|*.img"; // Filter files by extension

                    // Show open file dialog box

                    // Process open file dialog box results
                    if (dialog.ShowDialog() == true)
                    {
                        // Open document
                        string filename1 = dialog.FileName;
                        //本行仅用于调试   MessageBox.Show(filename1);
                        Process b = new Process();
                        b.StartInfo.FileName = "cmd.exe";
                        b.StartInfo.UseShellExecute = false;
                        b.StartInfo.RedirectStandardInput = true;
                        b.StartInfo.RedirectStandardError = true;
                        b.StartInfo.RedirectStandardOutput = true;
                        b.StartInfo.CreateNoWindow = true;

                        b.Start();
                        b.StandardInput.WriteLine("adb reboot-bootloader");
                        System.Threading.Thread.Sleep(6000);
                        b.StandardInput.WriteLine("fastboot flash recovery " + filename1);
                        b.StandardInput.WriteLine("fastboot flash misc misc.bin");
                        b.StandardInput.WriteLine("fastboot reboot");
                        MessageBox.Show("已成功刷入，正在自动重启至rec", "恭喜!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        b.StandardInput.WriteLine("exit");
                        b.WaitForExit();
                        b.Close();
                    }



                    break;
                case MessageBoxResult.No:
                    // User pressed No
                    // Configure open file dialog box
                    var aaa = new Microsoft.Win32.OpenFileDialog();
                    aaa.FileName = "请选择下载好的第三方rec的img文件"; // Default file name
                    aaa.DefaultExt = ".img"; // Default file extension
                    aaa.Filter = "img镜像文件 (.img)|*.img"; // Filter files by extension

                    // Show open file dialog box

                    // Process open file dialog box results
                    if (aaa.ShowDialog() == true)
                    {
                        // Open document
                        string filename = aaa.FileName;
                        //本行仅用于调试 MessageBox.Show(filename);
                        Process p = new Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.CreateNoWindow = true;

                        p.Start();
                        p.StandardInput.WriteLine("fastboot flash recovery " + filename);
                        p.StandardInput.WriteLine("fastboot flash misc misc.bin");
                        p.StandardInput.WriteLine("fastboot reboot");
                        this.Dispatcher.BeginInvoke((Action)delegate ()
                        {
                            PagesNavigation.Navigate(new System.Uri("finishrec.xaml", UriKind.RelativeOrAbsolute));
                        });
                        p.StandardInput.WriteLine("exit");
                        p.WaitForExit();
                        p.Close();

                    }

                    break;
            }
        }
    }
}
