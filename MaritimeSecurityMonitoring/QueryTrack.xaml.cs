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
    /// QueryTrack.xaml 的交互逻辑
    /// </summary>
    public partial class QueryTrack : Window
    {
        public QueryTrack()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void window_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void tuodong(object sender, MouseButtonEventArgs e)
        {
            window.DragMove();//实现整个窗口的拖动
        }
        private void queding(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void quxiao(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
