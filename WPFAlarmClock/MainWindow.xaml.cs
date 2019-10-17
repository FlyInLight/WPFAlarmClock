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
using System.Threading;
using System.Windows.Threading;
using System.Media;

namespace WPFAlarmClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //计时器
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        public MainWindow()
        {

            InitializeComponent();
            StartVoice();
            #region 初始化时间
            secondPointer.Angle = DateTime.Now.Second * 6;
            minutePointer.Angle = DateTime.Now.Minute * 6;
            hourPointer.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
            //this.labTime.Content = DateTime.Now.ToString("HH:mm:ss");
            #endregion
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
       
        }
        private void StartVoice()
        {

            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"C:\Users\Maibenben\Desktop\psd素材\7987.wav";
            player.Load(); //同步加载声音
            //player.Play(); //启用新线程播放
            player.PlayLooping(); //循环播放模式
            //player.PlaySync(); //UI线程同步播放
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //UI异步更新
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                //秒针转动,秒针绕一圈360度，共60秒，所以1秒转动6度
                secondPointer.Angle = DateTime.Now.Second * 6;
                //分针转动,分针绕一圈360度，共60分，所以1分转动6度
                minutePointer.Angle = DateTime.Now.Minute * 6;
                //时针转动,时针绕一圈360度，共12时，所以1时转动30度。
                //另外同一个小时内，随着分钟数的变化(绕一圈60分钟），时针也在缓慢变化（转动30度，30/60=0.5)
                hourPointer.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
                ////更新时间值
                //this.labTime.Content = DateTime.Now.ToString("HH:mm:ss");
            }));
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnSetUp_Click(object sender, RoutedEventArgs e)
        {
            SetUp setUp = new SetUp();
            setUp.Show();
        }
    }
}
