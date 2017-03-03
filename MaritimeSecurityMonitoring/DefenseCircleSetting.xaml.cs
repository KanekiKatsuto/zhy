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
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Forms;

using dataAnadll;
using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DefenseCircleSetting.xaml 的交互逻辑
    /// </summary>
    public partial class DefenseCircleSetting : Window
    {
        public static float fHeight;
        public static float fAlarmR;
        public static byte ucAlarmLevel;
        public static int rankNumber;
        public static byte ucCycleAlarmNum;
        public static string color;
        public static string name;
        public DefenseCircleSetting()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();//关闭窗口
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void saveClick(object sender, RoutedEventArgs e)
        {
            if (circleRadius.Text == "" || circleColor.Text == "" || circleName.Text == "")//是否存在空值判定
            {
                System.Windows.MessageBox.Show("输入内容不能为空，请输入。");
            }
            else
            {
                fHeight = 0;
                fAlarmR = (float)double.Parse(circleRadius.Text);
                ucAlarmLevel = (byte)double.Parse(circleRank.Text);
                rankNumber = (int)double.Parse(circleRank.Text);
                ucCycleAlarmNum = (byte)(200 + rankNumber);
                color=circleColor.Text;
                name=circleName.Text;

                Monitoring.AddProtectZoneBack();//调用模拟圈层参数区域设置函数
               
                this.Close();
            }
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("确定取消？", "", MessageBoxButton.YesNo) != MessageBoxResult.No)//是否存在空值判定
            {
                circleRadius.Text = "";
                circleColor.Text = "Red";
                circleName.Text = "";
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}