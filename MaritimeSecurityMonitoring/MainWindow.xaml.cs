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
using System.Windows.Forms;
using System.Windows.Threading;
using System.Diagnostics;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

using dmSqldll;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private ObservableDataSource<Point> dataSource = new ObservableDataSource<Point>();
        private PerformanceCounter cpuPerformance = new PerformanceCounter();
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//窗口位置出现在电脑中央
            userName.Text = "Test";
            //passWord.Password = "123";//便于测试的初始化用户名，密码
        }
        private void closeWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();//点击按钮，本窗口关闭
        }
        private void dragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//按住鼠标左键，拖动窗口
        }
        private void loginClick(object sender, RoutedEventArgs e)
        {
            dmSql login = new dmSql();
            //int result=login.Login(userName.Text.Trim(),passWord.Password.Trim());
            int result = 1;
            if (result == 1)
            {
                MonitoringInterface w1 = new MonitoringInterface();
                System.Windows.Application.Current.MainWindow = w1;
                this.Close();
                w1.Show();
                /*if (extendScrean.IsChecked == true)//判断是否启动扩展屏
                {
                    try
                    {
                        MonitoringInterface w1 = new MonitoringInterface();
                        System.Windows.Application.Current.MainWindow = w1;
                        this.Close();
                        w1.Show();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("未检测到扩展屏，请确定扩展屏正常连接，再进行勾选。");//显示异常信息
                    }
                }
                else
                {
                    MonitoringInterface w1 = new MonitoringInterface();
                    System.Windows.Application.Current.MainWindow = w1;
                    this.Close();
                    w1.Show();
                }*/
            }
            else
            {
                if (userName.Text == "" || passWord.Password == "")
                {
                    System.Windows.MessageBox.Show("登录名或者密码为空，请输入。");
                }
                else
                {
                    System.Windows.MessageBox.Show("登录名或者密码有误，请确认后输入。");
                }
            }
        }
    }
}