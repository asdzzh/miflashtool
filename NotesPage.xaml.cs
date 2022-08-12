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
using UIKitTutorials.Pages;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Lógica de interacción para NotesPage.xaml
    /// </summary>
    public partial class NotesPage : Page
    {
        public NotesPage()
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
                        MessageBox.Show("点击确定后手机会自动进入Fastboot以进行BL锁解锁检测，请勿重启手机，检测完成后手机会自动重启~",
                "重要提示!一定要看完再继续!");

                        //BL检测
                        Process d = new Process();
                        string bllock1 = "";
                        d.StartInfo.FileName = "cmd.exe";
                        d.StartInfo.UseShellExecute = false;
                        d.StartInfo.RedirectStandardInput = true;
                        d.StartInfo.RedirectStandardError = true;
                        d.StartInfo.RedirectStandardOutput = true;
                        d.StartInfo.CreateNoWindow = true;

                        d.Start();
                        d.StandardInput.WriteLine("adb reboot-bootloader");
                        d.StandardInput.WriteLine("CLS");

                        d.StandardInput.WriteLine("fastboot oem device-info");
                        System.Threading.Thread.Sleep(3000);
                        d.StandardInput.WriteLine("fastboot reboot");
                        d.StandardInput.WriteLine("exit");

                        bllock1 = d.StandardError.ReadToEnd();
                        string location = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        File.Delete(location + @"\bl.txt");
                        String rs2 = location + @"\bl.txt";
                        FileStream fs1 = new FileStream(rs2, FileMode.Create);
                        StreamWriter wr1 = null;
                        wr1 = new StreamWriter(fs1);
                        wr1.WriteLine(bllock1);
                        wr1.Close();
                        string[] lines = File.ReadAllLines(location + @"\bl.txt");
                        String b = lines[3];
                        if (b == "(bootloader) Device unlocked: true")
                        {


                            File.Delete(locations + @"\bl.txt");
                            d.WaitForExit();
                            d.Close();

                            PagesNavigation.Navigate(new System.Uri("magblunlock.xaml", UriKind.RelativeOrAbsolute));



                        }
                        else
                        {

                            File.Delete(locations + @"\bl.txt");
                            d.WaitForExit();
                            d.Close();

                            PagesNavigation.Navigate(new System.Uri("bllock.xaml", UriKind.RelativeOrAbsolute));


                        }
                    }

                }

            });

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("这真的只是个占位置的按键啦，也许再等等就可以用了~", "这个作者很懒，所以这个功能还不能用！", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    } 
}