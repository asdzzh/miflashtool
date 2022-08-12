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
    /// fuckitout.xaml 的交互逻辑
    /// </summary>
    public partial class fuckitout : Page
    {
        public static int caches = 0;
        public static int delviks = 0;
        public static int systems = 0;
        public static int vendors = 0;
        public static int datas = 0;
        public static int formatdatas = 0;
        public static int metadatas = 0;
        public fuckitout()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Thread multi = new Thread(new ThreadStart(StartWork));
            multi.IsBackground = true;
            multi.Start();
        }

        private void cacheyes(object sender, RoutedEventArgs e)
        {
            caches = 1;
        }

        private void cacheun(object sender, RoutedEventArgs e)
        {
            caches = 0;

        }

        private void delvikyes(object sender, RoutedEventArgs e)
        {
            delviks = 1;
        }

        private void delvikun(object sender, RoutedEventArgs e)
        {
            delviks = 0;
        }

        private void systemyes(object sender, RoutedEventArgs e)
        {
            systems = 1;
        }

        private void systemun(object sender, RoutedEventArgs e)
        {
            systems = 0;
        }

        private void vendores(object sender, RoutedEventArgs e)
        {
            vendors = 1;
        }

        private void vendorun(object sender, RoutedEventArgs e)
        {
            vendors = 0;
        }

        private void datayes(object sender, RoutedEventArgs e)
        {
            datas = 1;
        }

        private void dataun(object sender, RoutedEventArgs e)
        {
            datas = 0;
        }

        private void formatdatayes(object sender, RoutedEventArgs e)
        {
            formatdatas = 1;
        }

        private void formatdataun(object sender, RoutedEventArgs e)
        {
            formatdatas = 0;
        }

        private void metadatayes(object sender, RoutedEventArgs e)
        {
            metadatas = 1;
        }

        private void metadataun(object sender, RoutedEventArgs e)
        {
            metadatas = 0;
        }

        private delegate void DelegateFunction(int ipos);

        //执行函数
        void StartWork()
        {
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                //ADB检测
                Process f = new Process();
                string adb = "";
                f.StartInfo.FileName = "cmd.exe";
                f.StartInfo.UseShellExecute = false;
                f.StartInfo.RedirectStandardInput = true;
                f.StartInfo.RedirectStandardError = true;
                f.StartInfo.RedirectStandardOutput = true;
                f.StartInfo.CreateNoWindow = true;

                f.Start();
                f.StandardInput.WriteLine("adb");
                f.StandardInput.WriteLine("adb start-server");
                f.StandardInput.WriteLine("exit");

                adb = f.StandardError.ReadToEnd();

                string location1 = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.Delete(location1 + @"\adbdownload.txt");
                String rs3 = location1 + @"\adbdownload.txt";
                FileStream fs2 = new FileStream(rs3, FileMode.Create);
                StreamWriter wr3 = null;
                wr3 = new StreamWriter(fs2);
                wr3.WriteLine(adb);
                wr3.Close();
                string[] line3 = File.ReadAllLines(location1 + @"\adbdownload.txt");
                String s = line3[0];
                if (s == "'adb' 不是内部或外部命令，也不是可运行的程序")
                {
                    MessageBox.Show("还没有安装ADB驱动哦，请先安装后再来吧，位置(更多功能-驱动安装及检测)");
                    f.WaitForExit();
                    f.Close();
                }
                else
                {

                    f.WaitForExit();
                    f.Close();
                    //连接检测
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

                        MessageBox.Show("请先连接手机并打开手机的ADB调试并连接手机哦，若已连接并已打开的话请检查驱动是否正常安装，位置(更多功能-驱动安装及检测)");
                        File.Delete(locations + @"\adbtest.txt");
                        p.WaitForExit();
                        p.Close();


                    }
                    else
                    {
                        Process y = new Process();
                        y.StartInfo.FileName = "cmd.exe";
                        y.StartInfo.UseShellExecute = false;
                        y.StartInfo.RedirectStandardInput = true;
                        y.StartInfo.RedirectStandardError = true;
                        y.StartInfo.RedirectStandardOutput = true;
                        y.StartInfo.CreateNoWindow = true;

                        y.Start();
                        y.StandardInput.WriteLine("adb reboot-bootloader");
                        if (caches == 1)
                        {
                            y.StandardInput.WriteLine("fastboot erase cache");
                        }

                        if (delviks == 1)
                        {
                            y.StandardInput.WriteLine("fastboot erase delvik");
                        }

                        if (systems == 1)
                        {
                            y.StandardInput.WriteLine("fastboot erase system");
                        }

                        if (datas == 1)
                        {
                            y.StandardInput.WriteLine("fastboot erase data");
                        }

                        if (formatdatas == 1)
                        {
                            y.StandardInput.WriteLine("fastboot format data");
                        }

                        if (metadatas == 1)
                        {
                            y.StandardInput.WriteLine("fastboot erase metadata");
                        }

                        if (vendors == 1)
                        {
                            y.StandardInput.WriteLine("fastboot erase vendore");
                        }
                        y.StandardInput.WriteLine("exit");
                        y.WaitForExit(30000);
                        y.Close();



                    }

                }

            });

        }
    }
}
