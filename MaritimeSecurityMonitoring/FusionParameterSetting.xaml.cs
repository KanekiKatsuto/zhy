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

using dataAnadll;
using MaritimeSecurityMonitoring.MainInterfacePage;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// FusionParameterSetting.xaml 的交互逻辑
    /// </summary>
    public partial class FusionParameterSetting : Window
    {
        SetConfig sc = new SetConfig();
        dataAna s = new dataAna();
        public static float fXYZThreshold = 5000;
        public static float fDisThreshold = 0;
        public static float fAngleThreshold = 0;
        public static byte ucAlarmThreshold = 1;
        public static long lRdDieTime = 36;
        public static long lAISDieTime = 36;
        public static long lM = 2;
        public static long lN = 3;
        public static byte UcEstiArith = 1;

        public FusionParameterSetting()
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
        private void promptClick(object sender, RoutedEventArgs e)
        {

        }
        private void warnClick(object sender, RoutedEventArgs e)
        {

        }
        private void optimalClick(object sender, RoutedEventArgs e)
        {

        }
        private void weightedClick(object sender, RoutedEventArgs e)
        {

        }
        private void SF(object sender, RoutedEventArgs e)
        {

        }

        private void yesClick(object sender, RoutedEventArgs e)
        {
            float ftry;
            long ltry;
            if (!float.TryParse(xyzParameter.Text, out ftry) || !float.TryParse(abrDistance.Text, out ftry) || !float.TryParse(abrAngle.Text, out ftry) || !long.TryParse(radarDisappearTime.Text, out ltry) || !long.TryParse(AISDisappearTime.Text, out ltry) || !long.TryParse(IMParameter.Text, out ltry) || !long.TryParse(INParameter.Text, out ltry))
            {
                MessageBoxX.Show("错误信息", "输入数据有误！请重新输入！");
            }
            else
            {
                sc.write_string("fusion", "xyz", xyzParameter.Text);
                sc.write_string("fusion", "abrDistance", abrDistance.Text);
                sc.write_string("fusion", "abrAngle", abrAngle.Text);
                sc.write_string("fusion", "radarMiss", radarDisappearTime.Text);
                sc.write_string("fusion", "AISMiss", AISDisappearTime.Text);
                sc.write_string("fusion", "IM", IMParameter.Text);
                sc.write_string("fusion", "IN", INParameter.Text);
                sc.write_bool("fusionRadio", "prompt", (bool)prompt.IsChecked);
                sc.write_bool("fusionRadio", "warn", (bool)warn.IsChecked);
                sc.write_bool("fusionRadio", "optimal", (bool)RadioB3.IsChecked);
                sc.write_bool("fusionRadio", "weighted", (bool)RadioB4.IsChecked);
                sc.write_bool("fusionRadio", "SF", (bool)RadioB5.IsChecked);

                fXYZThreshold = (float)double.Parse(xyzParameter.Text);
                fDisThreshold = (float)double.Parse(abrDistance.Text);
                fAngleThreshold = (float)double.Parse(abrAngle.Text);
                if ((bool)prompt.IsChecked) {
                    ucAlarmThreshold = 1;
                }
                else
                {
                    ucAlarmThreshold = 2;
                }
                lRdDieTime = (long)double.Parse(radarDisappearTime.Text);
                lAISDieTime = (long)double.Parse(AISDisappearTime.Text);
                lM = (long)double.Parse(IMParameter.Text);
                lN = (long)double.Parse(INParameter.Text);
                if ((bool)RadioB3.IsChecked)
                {
                    UcEstiArith = 1;
                }
                else if ((bool)RadioB4.IsChecked)
                {
                    UcEstiArith = 2;
                }
                else if ((bool)RadioB5.IsChecked)
                {
                    UcEstiArith = 3;
                }

                Monitoring.FusionBack();
                MessageBoxX.Show("提示信息", "参数保存成功！");
                this.Close();
            }
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
                xyzParameter.Text = "";
                abrDistance.Text = "";
                abrAngle.Text = "";
                radarDisappearTime.Text = "";
                AISDisappearTime.Text = "";
                IMParameter.Text = "";
                INParameter.Text = "";
                prompt.IsChecked = false;
                warn.IsChecked = false;
                RadioB3.IsChecked = false;
                RadioB4.IsChecked = false;
                RadioB5.IsChecked = false;
                this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*xyzParameter.Text=sc.read_string("fusion", "xyz");
            abrDistance.Text = sc.read_string("fusion", "abrDistance");
            abrAngle.Text = sc.read_string("fusion", "abrAngle");
            radarDisappearTime.Text = sc.read_string("fusion", "radarMiss");
            AISDisappearTime.Text = sc.read_string("fusion", "AISMiss");
            IMParameter.Text = sc.read_string("fusion", "IM");
            INParameter.Text = sc.read_string("fusion", "IN");*/
            FusionParameter fp = new FusionParameter
            {
                xyzParameter = (float)double.Parse(sc.read_string("fusion", "xyz")),
                abrDistance = (float)double.Parse(sc.read_string("fusion", "abrDistance")),
                abrAngle = (float)double.Parse(sc.read_string("fusion", "abrAngle")),
                radarMiss = (long)double.Parse(sc.read_string("fusion", "radarMiss")),
                AISMiss = (long)double.Parse(sc.read_string("fusion", "AISMiss")),
                IM = (long)double.Parse(sc.read_string("fusion", "IM")),
                IN = (long)double.Parse(sc.read_string("fusion", "IN")),
            };
            DataContext = fp;
            prompt.IsChecked = sc.read_bool("fusionRadio", "prompt");
            warn.IsChecked = sc.read_bool("fusionRadio", "warn");
            RadioB3.IsChecked = sc.read_bool("fusionRadio", "optimal");
            RadioB4.IsChecked = sc.read_bool("fusionRadio", "weighted");
            RadioB5.IsChecked = sc.read_bool("fusionRadio", "SF");
        }
    }
}
