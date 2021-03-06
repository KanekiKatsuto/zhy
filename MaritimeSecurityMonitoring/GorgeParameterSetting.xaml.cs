﻿using System;
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
    /// GorgeParameterSetting.xaml 的交互逻辑
    /// </summary>
    public partial class GorgeParameterSetting : Window
    {
        SetConfig sc = new SetConfig();
        public GorgeParameterSetting()
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
            if (baudRate.Text == "" || dataBits.Text == "" || evenOddCheck.Text == "" || stopBit.Text == "")
            {
                System.Windows.MessageBox.Show("输入IP内容不能为空，请输入。");
            }
            else
            {
                sc.write_string("serialPort", "baudRate",baudRate.Text);
                sc.write_string("serialPort", "dataBits", dataBits.Text);
                sc.write_string("serialPort", "parityBit",evenOddCheck.Text);
                sc.write_string("serialPort", "stopBit", stopBit.Text);
                System.Windows.MessageBox.Show("IP保存成功。");
            }
        }
        private void deleteClick(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("确定删除IP数据？", "", MessageBoxButton.YesNo) != MessageBoxResult.No)
            {
                baudRate.Text = "";
                dataBits.Text = "";
                evenOddCheck.Text = "";
                stopBit.Text = "";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            baudRate.Text =sc.read_string("serialPort","baudRate");
            dataBits.Text = sc.read_string("serialPort", "dataBits");
            evenOddCheck.Text = sc.read_string("serialPort", "parityBit");
            stopBit.Text = sc.read_string("serialPort","stopBit");
        }
    }
}
