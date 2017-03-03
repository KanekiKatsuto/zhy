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
    /// MapManage.xaml 的交互逻辑
    /// </summary>
    public partial class MapManage : Window
    {
        private string[] mapInformation = { "", "", "", "", "", "", "", "", "" };
        SetConfig sc = new SetConfig();
        public MapManage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void addMaps(object sender, SelectionChangedEventArgs e)
        {
            string mapName = ((sender as System.Windows.Controls.ListBox).SelectedItem as ListBoxItem).Content.ToString();
            if (mapName == "GB4X0000")
            {
                mapInformation[0] = "78000";
                mapInformation[1] = "3";
                mapInformation[2] = "2";
                mapInformation[3] = "3562";
                mapInformation[4] = "52度46.00分E";
                mapInformation[5] = "23度46.00分E";
                mapInformation[6] = "69度19.00分W";
                mapInformation[7] = "52度19.00分W";
                mapInformation[8] = "GB4X0000";
            }
            if (mapName == "US1WCO4M")
            {
                mapInformation[0] = "45000";
                mapInformation[1] = "6";
                mapInformation[2] = "1";
                mapInformation[3] = "66862";
                mapInformation[4] = "23度72.00分E";
                mapInformation[5] = "15度96.00分E";
                mapInformation[6] = "36度12.00分W";
                mapInformation[7] = "03度26.00分W";
                mapInformation[8] = "US1WCO4M";
            }
            if (mapName == "UESTCTA")
            {
                mapInformation[0] = "12350";
                mapInformation[1] = "4";
                mapInformation[2] = "1";
                mapInformation[3] = "661352";
                mapInformation[4] = "16度60.00分E";
                mapInformation[5] = "76度36.00分E";
                mapInformation[6] = "29度12.00分W";
                mapInformation[7] = "46度56.00分W";
                mapInformation[8] = "UESTCTA";
            }
            if (mapName == "AYNLD2L5")
            {
                mapInformation[0] = "89250";
                mapInformation[1] = "1";
                mapInformation[2] = "1";
                mapInformation[3] = "235698";
                mapInformation[4] = "53度63.00分E";
                mapInformation[5] = "45度47.00分E";
                mapInformation[6] = "67度15.00分W";
                mapInformation[7] = "25度63.00分W";
                mapInformation[8] = "AYNLD2L5";
            }
            if (mapName == "6PIG5F68")
            {
                mapInformation[0] = "12850";
                mapInformation[1] = "8";
                mapInformation[2] = "5";
                mapInformation[3] = "243998";
                mapInformation[4] = "93度42.00分E";
                mapInformation[5] = "35度47.00分E";
                mapInformation[6] = "46度15.00分W";
                mapInformation[7] = "22度63.00分W";
                mapInformation[8] = "6PIG5F68";
            }
            if (mapName == "2354AVFPK")
            {
                mapInformation[0] = "96920";
                mapInformation[1] = "4";
                mapInformation[2] = "3";
                mapInformation[3] = "135568";
                mapInformation[4] = "46度62.00分E";
                mapInformation[5] = "03度89.00分E";
                mapInformation[6] = "67度15.00分W";
                mapInformation[7] = "35度14.00分W";
                mapInformation[8] = "2354AVFPK";
            }
            if (mapName == "UFRHKBL")
            {
                mapInformation[0] = "13490";
                mapInformation[1] = "5";
                mapInformation[2] = "4";
                mapInformation[3] = "964698";
                mapInformation[4] = "47度82.00分E";
                mapInformation[5] = "93度47.00分E";
                mapInformation[6] = "64度14.00分W";
                mapInformation[7] = "29度43.00分W";
                mapInformation[8] = "UFRHKBL";
            }
        }
        private void preview_Click(object sender, RoutedEventArgs e)
        {
            measuring.Text = mapInformation[0];
            edition.Text = mapInformation[1];
            upgradedVersion.Text = mapInformation[2];
            memory.Text = mapInformation[3];
            rightBoundary.Text = mapInformation[4];
            leftBoundary.Text = mapInformation[5];
            topBoundary.Text = mapInformation[6];
            bottomBoundary.Text = mapInformation[7];
        }
        private void upload_Click(object sender, RoutedEventArgs e)
        {
            deleteMapsSelection.Items.Add(mapInformation[8]);
        }
        private void unload_Click(object sender, RoutedEventArgs e)
        {
            deleteMapsSelection.Items.Remove(mapInformation[8]);
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("保存成功。", "", MessageBoxButton.YesNo) != MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            measuring.Text = sc.read_string("chartInfo", "measuring");
            edition.Text = sc.read_string("chartInfo", "edition");
            upgradedVersion.Text = sc.read_string("chartInfo", "upgradedVersion");
            memory.Text = sc.read_string("chartInfo", "memory");
            leftBoundary.Text = sc.read_string("chartRange", "leftBoundary");
            rightBoundary.Text = sc.read_string("chartRange", "rightBoundary");
            topBoundary.Text = sc.read_string("chartRange", "topBoundary");
            bottomBoundary.Text = sc.read_string("chartRange", "bottomBoundary");
        }
    }
}
