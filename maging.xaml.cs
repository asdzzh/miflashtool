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

namespace UIKitTutorials.Pages
{
    /// <summary>
    /// maging.xaml 的交互逻辑
    /// </summary>
    public partial class maging : Page
    {

        public maging()
        {
            InitializeComponent();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread multi = new Thread(new ThreadStart(StartWork));
            multi.IsBackground = true;
            multi.Start();

            


        }

        private delegate void DelegateFunction(int ipos);

        //执行函数
        void StartWork()
        {
            string messageBoxText = "请确认手机现在是否在系统桌面!要是暂时还没准备好就点取消吧!";
            string caption = "确认目前的手机状态";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            switch (result)
            {
                case MessageBoxResult.Cancel:
                    // User pressed Cancel

                    break;
                case MessageBoxResult.Yes:
                    // User pressed Yes

                    MessageBox.Show("请先按照提示，修补boot文件，等修补完boot文件后再点击下面的确定", "其实啥时候点都无所谓，反正后面还得选文件", MessageBoxButton.OK, MessageBoxImage.Warning);

                    //等待修补完成

                    var dialog = new Microsoft.Win32.OpenFileDialog();
                    dialog.FileName = "请选择修补完的magisk开头的.img文件"; // Default file name
                    dialog.DefaultExt = ".img"; // Default file extension
                    dialog.Filter = "img镜像文件 (.img)|*.img"; // Filter files by extension

                    // Show open file dialog box

                    // Process open file dialog box results
                    if (dialog.ShowDialog() == true)
                    {
                        // Open document
                        string filestart = dialog.FileName;
                        string filename = dialog.SafeFileName;
                        string fileend = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string fileendd = fileend + @"\" + filename;

                        File.Copy(filestart, fileendd);
                        Process p = new Process();
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.CreateNoWindow = true;

                        p.Start();
                        p.StandardInput.WriteLine("fastboot flash boot " + fileendd);
                        p.StandardInput.WriteLine("fastboot boot " + fileendd);


                        p.StandardInput.WriteLine("exit");
                        p.WaitForExit();
                        p.Close();
                        this.Dispatcher.BeginInvoke((Action)delegate ()
                        {
                             PagesNavigation.Navigate(new System.Uri("finishflash.xaml", UriKind.RelativeOrAbsolute));
                        });
                       







                    }
                    break;
                case MessageBoxResult.No:
                    // User pressed No
                    MessageBox.Show("如果是其他不认识的界面就长按电源键知道自动重启，重启之后解锁进桌面后再试!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

            }

        }



    }
}
