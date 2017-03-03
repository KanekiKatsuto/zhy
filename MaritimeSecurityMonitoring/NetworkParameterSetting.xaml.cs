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
    /// NetworkParameterSetting.xaml 的交互逻辑
    /// </summary>
    public partial class NetworkParameterSetting : Window
    {
        SetConfig sc = new SetConfig();
        public NetworkParameterSetting()
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
            if (dataServerIP.Text == "" || mixServerIP.Text == "" || firstMonitoringIP.Text == "" || secondMonitoringIP.Text == "")
            {
                System.Windows.MessageBox.Show("输入IP内容不能为空，请输入。");
            }
            else
            {
                sc.write_string("ipAddr", "dataSer",dataServerIP.Text);
                sc.write_string("ipAddr", "fusionSer" ,mixServerIP.Text);
                sc.write_string("ipAddr", "monitor1" ,firstMonitoringIP.Text);
                sc.write_string("ipAddr", "monitor2", secondMonitoringIP.Text);
                System.Windows.MessageBox.Show("IP保存成功。");
                this.Close();
            }
        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataServerIP.Text =sc.read_string("ipAddr","dataSer");
            mixServerIP.Text = sc.read_string("ipAddr", "fusionSer");
            firstMonitoringIP.Text = sc.read_string("ipAddr", "monitor1");
            secondMonitoringIP.Text = sc.read_string("ipAddr", "monitor2");
        }
    }
}
