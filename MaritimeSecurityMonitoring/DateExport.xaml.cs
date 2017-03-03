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
using System.Windows.Forms;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DateExport.xaml 的交互逻辑
    /// </summary>
    public partial class DateExport : Page
    {
        public DateExport()
        {
            InitializeComponent();
        }
        private void chooseFilePathClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog m_Dialog = new FolderBrowserDialog();
            DialogResult result = m_Dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string filePath = m_Dialog.SelectedPath.Trim();
            filePathText.Text = filePath;
        }
        private void exportClick(object sender, RoutedEventArgs e)
        {
            if (filePathText.Text != "")
            {
                if (System.Windows.MessageBox.Show("确认导出。", "", MessageBoxButton.YesNo) != MessageBoxResult.No)
                {
                    System.Windows.MessageBox.Show("导出文件路径为空，请选择文件路径。");
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
