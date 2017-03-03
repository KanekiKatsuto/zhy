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
    /// PolygonDialog.xaml 的交互逻辑
    /// </summary>
    
    public partial class PolygonDialog : Window
    {
        public static String polygonNameText;
        public static String polygonWidthText;
        public static String aLarmRankText;
        
       
        public PolygonDialog()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void sureClick(object sender, RoutedEventArgs e)
        {

            polygonNameText=polygonName.Text;
            aLarmRankText = aLarmRank.Text;
            polygonWidthText = polygonWidth.Text;
            this.Close();
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


