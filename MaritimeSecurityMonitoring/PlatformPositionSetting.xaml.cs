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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// PlatformPositionSetting.xaml 的交互逻辑
    /// </summary>
    public partial class PlatformPositionSetting : Window
    {
        public PlatformPositionSetting()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void saveClick(object sender, RoutedEventArgs e)
        {
            if (longitude.Text == "" || latitude.Text == "")
            {
                System.Windows.MessageBox.Show("输入经纬度内容不能为空，请输入。");
            }
            else
            {
                double longitudeValue = double.Parse(longitude.Text);
                double latitudeValue = double.Parse(latitude.Text);
                App app = (App)App.Current;
                app.chartCtrl.SetPlatform(longitudeValue, latitudeValue);
                System.Windows.MessageBox.Show("经纬度设置成功。");
            }
            this.Close();
        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            longitude.Text = "";
            latitude.Text = "";
            this.Close();
        }
    }
}
