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
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace WPFUIKitProfessional
{
    /// <summary>
    /// boot.xaml 的交互逻辑
    /// </summary>
    public partial class boot : Page
    {
        public boot()
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
            Process p = new Process();
            string bllock = "";
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.StandardInput.WriteLine("adb devices");

            p.StandardInput.WriteLine("exit");

            bllock = p.StandardOutput.ReadToEnd();
            string locations = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.Delete(locations + @"\adbtest.txt");
            String rs1 = locations + @"\adbtest.txt";
            FileStream fs = new FileStream(rs1, FileMode.Create);
            StreamWriter wr = null;
            wr = new StreamWriter(fs);
            wr.WriteLine(bllock);
            wr.Close();
            string[] line = File.ReadAllLines(locations + @"\adbtest.txt");
            String a = line[5];
            //调试用 MessageBox.Show(a);
            if (a == "")
            {

                MessageBox.Show("请先连接手机并打开手机的ADB调试哦，若已连接并已打开的话请检查驱动是否正常安装，位置(更多功能-驱动安装及检测)");
                File.Delete(locations + @"\adbtest.txt");
                p.WaitForExit();
                p.Close();
                this.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    PagesNavigation.Navigate(new System.Uri("boot.xaml", UriKind.RelativeOrAbsolute));
                });


            }
            else
            {

                File.Delete(locations + @"\adbtest.txt");
                p.WaitForExit();
                p.Close();
                Process d = new Process();
                d.StartInfo.FileName = "cmd.exe";
                d.StartInfo.UseShellExecute = false;
                d.StartInfo.RedirectStandardInput = true;
                d.StartInfo.RedirectStandardError = true;
                d.StartInfo.RedirectStandardOutput = true;
                d.StartInfo.CreateNoWindow = true;
                d.Start();

                d.StandardInput.WriteLine("adb reboot recovery");
                System.Threading.Thread.Sleep(30000);
                d.StandardInput.WriteLine("adb shell");
                System.Threading.Thread.Sleep(1000);
                d.StandardInput.WriteLine("dd if=/dev/block/bootdevice/by-name/boot of=sdcard/boot.img");
                System.Threading.Thread.Sleep(5000);
                d.StandardInput.WriteLine("exit");
                d.StandardInput.WriteLine("exit");
                d.WaitForExit();
                d.Close();



                if (MessageBox.Show("备份成功！是否要进入fastboot清除缓存并开机？",
                        "确认!",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {


                    Process b = new Process();
                    b.StartInfo.FileName = "cmd.exe";
                    b.StartInfo.UseShellExecute = false;
                    b.StartInfo.RedirectStandardInput = true;
                    b.StartInfo.RedirectStandardError = true;
                    b.StartInfo.RedirectStandardOutput = true;
                    b.StartInfo.CreateNoWindow = true;
                    b.Start();
                    b.StandardInput.WriteLine("adb reboot-bootloader");   //目前有bug
                    b.StandardInput.WriteLine("fastboot erase cache");
                    b.StandardInput.WriteLine("fastboot erase Dalvik");
                    b.StandardInput.WriteLine("fastboot reboot");
                    b.StandardInput.WriteLine("exit");
                    b.WaitForExit();
                    b.Close();

                    MessageBox.Show("已成功清除！");

                }
            }
        }


    }
}

