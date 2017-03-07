using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// MessageBoxX.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxX : Window
    {
        private MessageBoxX()
        {
            InitializeComponent();
        }

        public new string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }  
        }

        public string Message
        {
            get { return this.lblMsg.Text; }
            set { this.lblMsg.Text = value; }
        }

        public static bool? Show(string title, string msg)
        {
            var msgBox = new MessageBoxX();
            msgBox.Title = title;
            msgBox.Message = msg;
            return msgBox.ShowDialog();
        }

        private void OK_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }  
    }
}
