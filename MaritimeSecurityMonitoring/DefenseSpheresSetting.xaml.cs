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
    /// DefenseSpheresSetting.xaml 的交互逻辑
    /// </summary>
    public partial class DefenseSpheresSetting : Window
    {
        SetConfig sc = new SetConfig();
        public DefenseSpheresSetting()
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
        private void save(object sender, RoutedEventArgs e)
        {
            if (expelRadius.Text == "" || alertRadius.Text == "" || photoelectricRadius.Text == "" || radarDetectionRadius.Text == "")//是否存在空值判定
            {
                System.Windows.MessageBox.Show("输入内容不能为空，请输入。");
            }
            else
            {
                sc.write_string("radius","expulsionZone",expelRadius.Text);
                sc.write_string("radius","warningArea",alertRadius.Text);
                sc.write_string("radius","photoelectric",photoelectricRadius.Text);
                sc.write_string("radius","radar",radarDetectionRadius.Text);
                System.Windows.MessageBox.Show("参数保存成功。");
                this.Close();
            }      
        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("确定取消保存？", "", MessageBoxButton.YesNo) != MessageBoxResult.No)//是否存在空值判定
            {
                expelRadius.Text = "";
                alertRadius.Text = "";
                photoelectricRadius.Text = "";
                radarDetectionRadius.Text = "";
            }    
         }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            expelRadius.Text = sc.read_string("radius", "expulsionZone");
            alertRadius.Text = sc.read_string("radius", "warningArea");
            photoelectricRadius.Text = sc.read_string("radius", "photoelectric");
            radarDetectionRadius.Text = sc.read_string("radius", "radar");
        }
    }
}