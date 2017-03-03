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
    /// RolePermisionManage.xaml 的交互逻辑
    /// </summary>
    public partial class RolePermisionManage : Window
    {
        List<RolePermissionDate> items = new List<RolePermissionDate>();
        public RolePermisionManage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            items.Add(new RolePermissionDate() { Number = "1", Role = "管理员", Permission = "信息录入，发布解除预警，安保资源更新，系统管理，分析参数设置" });
            items.Add(new RolePermissionDate() { Number = "2", Role = "工程师", Permission = "分析参数设置" });
            items.Add(new RolePermissionDate() { Number = "3", Role = "操作员", Permission = "信息录入" });
            items.Add(new RolePermissionDate() { Number = "4", Role = "观察员", Permission = "发布解除预警" });
            dataList.ItemsSource = items;
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//实现整个窗口的拖动
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void addingClick(object sender, RoutedEventArgs e)
        {
            dataList.ItemsSource = "";
            items.Add(new RolePermissionDate() { Number = numberText.Text, Role = roleText.Text, Permission = permissionText.Text });
            dataList.ItemsSource = items;
        }
        private void changeClick(object sender, RoutedEventArgs e)
        {

        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {

        }
    }
    public class RolePermissionDate
    {
        public string Number { get; set; }
        public string Role { get; set; }
        public string Permission { get; set; }
    }
}
