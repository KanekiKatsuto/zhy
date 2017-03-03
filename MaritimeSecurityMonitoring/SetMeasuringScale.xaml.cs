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

namespace MaritimeSecurityMonitoring.Video
{
    /// <summary>
    /// SetMeasuringScale.xaml 的交互逻辑
    /// </summary>
    public partial class SetMeasuringScale : Window
    {
        public SetMeasuringScale()
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
        private void sureClick(object sender, RoutedEventArgs e)
        {
            if (rad1.IsChecked == false)
            {
                string A = test1.Text;
                float bili = (float)double.Parse(A);
                App app = (App)App.Current;
                app.chartCtrl.SetScale(bili);
                this.Close();
            }
            else
            {
                string B = com.Text;
                float bili = (float)double.Parse(B);
                App app = (App)App.Current;
                app.chartCtrl.SetScale(bili);
                this.Close();
            }
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {

            test1.Text = "";
            this.Close();
        }
    }
}