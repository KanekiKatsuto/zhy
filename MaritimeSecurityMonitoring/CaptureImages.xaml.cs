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
using System.Windows.Forms;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// CaptureImages.xaml 的交互逻辑
    /// </summary>
    public partial class CaptureImages : Window
    {
        public CaptureImages()
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

        private void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));
            using (var stm = System.IO.File.Create(filename))
            {
                enc.Save(stm);
            }
        }
        private void saveClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog m_Dialog = new FolderBrowserDialog();
            DialogResult result = m_Dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string LJM = m_Dialog.SelectedPath.Trim();                                            //c存储路径对应的字符串。
            var rtb = new RenderTargetBitmap((int)Picture.Width, (int)Picture.Height, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(Picture);
            SaveRTBAsPNG(rtb, LJM + "/" + System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");      //进行图片存储。   
            System.Windows.MessageBox.Show("图片保存成功。");
        }
        private void identifyClick(object sender, RoutedEventArgs e)
        {
            identifyResult.Text = "CB2043025";//模拟的识别结果
        }
        public static void WriteFile(string Path, string Strings)
        {
            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();
        }
        private void yesClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog m_Dialog = new FolderBrowserDialog();
            DialogResult result = m_Dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string LJM = m_Dialog.SelectedPath.Trim() + "/";
            string ABC = identifyResult.Text;
            WriteFile(LJM + System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".doc", "时间：" + System.DateTime.Now.ToString("yyyy-MM-dd") + "   " + "经度：东经117°38'   纬度：北纬75°8'" + "   " + "MMSI：" + ABC + "   " + "航行状态：动力航行中   转向率：+0度   对地航速：0.00节");                                   //船舶识别码保存为txt文件（以一个参数为文件路径，第二个参数为写入文件的内容。）
            System.Windows.MessageBox.Show("舷舶识别码信息保存成功！");          //保存其他信息。
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
            identifyResult.Text = "";
            Picture.Source = new BitmapImage(new Uri(@"", UriKind.Relative));//取消，删除图片
        }
    }
}
