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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DeviceOperationStatus.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceOperationStatus : Page
    {
        public DeviceOperationStatus()
        {
            InitializeComponent();
            content.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
        private void AISClick(object sender, RoutedEventArgs e)
        {
            AISPage p = new AISPage();
            content.Content = p;
        }
        private void radarFirstClick(object sender, RoutedEventArgs e)
        {
            RadarFirstPage p = new RadarFirstPage();
            content.Content = p;
        }
        private void radarSecondClick(object sender, RoutedEventArgs e)
        {
            RadarSecondPage p = new RadarSecondPage();
            content.Content = p;
        }
        private void optoelectronicClick(object sender, RoutedEventArgs e)
        {
            OptoelectronicPage p = new OptoelectronicPage();
            content.Content = p;
        }
        private void mixServerClick(object sender, RoutedEventArgs e)
        {
            MixServerPage p = new MixServerPage();
            content.Content = p;
        }
        private void dataServerClick(object sender, RoutedEventArgs e)
        {
            DataServerPage p = new DataServerPage();
            content.Content = p;
        }
        private void interchangeClick(object sender, RoutedEventArgs e)
        {
            InterchangePage p = new InterchangePage();
            content.Content = p;
        }
        private void mornitoringFirstClick(object sender, RoutedEventArgs e)
        {
            MonitoringFirstPage p = new MonitoringFirstPage();
            content.Content = p;
        }
        private void mornitoringSecondClick(object sender, RoutedEventArgs e)
        {
            MonitoringSecondPage p = new MonitoringSecondPage();
            content.Content = p;
        }
    }
}
