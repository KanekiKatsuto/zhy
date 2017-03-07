using System;
using System.Windows;

using MaritimeSecurityMonitoring.MainInterfacePage;
using YimaEncCtrl;
using MaritimeSecurityMonitoring.Video;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// Interface.xaml 的交互逻辑
    /// </summary>
    public partial class MonitoringInterface : Window
    {
        private bool isInShowingTrackMode = false;
        private bool isInShowingTrack = true;
        private bool isHandRoam = false;
        public MonitoringInterface()
        {
            InitializeComponent();
            this.Closing += closeSoftware;
        }

        private void closeSoftware(object o, System.ComponentModel.CancelEventArgs e)//关闭主界面时界面完全关闭
        {
            System.Windows.Application.Current.Shutdown();
        }

        //***********************************************************************************
        //*******************************主菜单事件******************************************
        //***********************************************************************************
        private void AISSituationClick(object sender, RoutedEventArgs e)//态势显示->AIS态势
        {

        }

        private void radarSituationClick(object sender, RoutedEventArgs e)//态势显示->雷达态势
        {

        }

        private void mixSituationClick(object sender, RoutedEventArgs e)//态势显示->融合态势
        {

        }

        private void optoelectronicSituationClick(object sender, RoutedEventArgs e)//态势显示->光电态势
        {

        }

        private void radarScanningLineClick(object sender, RoutedEventArgs e)//态势显示->雷达扫描线
        {

        }

        private void optoelectronicRangeClick(object sender, RoutedEventArgs e)//态势显示->光电观察范围
        {

        }

        private void targetDisplayMethodsClick(object sender, RoutedEventArgs e)//态势显示->目标显示方式设置
        {
            TargetDisplayMethods w = new TargetDisplayMethods();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void listWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->列表报警
        {

        }

        private void imageWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->图像报警
        {

        }

        private void voiceWarnClick(object sender, RoutedEventArgs e)//报警管理->报警方式->声音报警
        {

        }

        private void defenseSpheresSettingClick(object sender, RoutedEventArgs e)//报警管理->防护圈层设置
        {
            DefenseCircleSetting w = new DefenseCircleSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void areaLabelClick(object sender, RoutedEventArgs e)//多边形
        {
            Monitoring.AddedForbiddenZoneBack();
        }
        private void pipelineClick(object sender, RoutedEventArgs e)//管道区域
        {
            Monitoring.AddedPipelineBack();
        }

        private void warnAreaSettingClick(object sender, RoutedEventArgs e)//报警管理->报警区域设置
        {

        }

        private void captureImagesClick(object sender, RoutedEventArgs e)//视频管理->图片抓取
        {
            CaptureImages w = new CaptureImages();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void trackVideoClick(object sender, RoutedEventArgs e)//视频管理->视频跟踪
        {

        }

        private void automaticLinkageClick(object sender, RoutedEventArgs e)//联动控制->自动控制
        {
            AutomaticLinkage w = new AutomaticLinkage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void manualControlClick(object sender, RoutedEventArgs e)//联动控制->手动控制
        {

        }

        private void fusionParameterSettingClick(object sender, RoutedEventArgs e)//融合参数
        {
            FusionParameterSetting w = new FusionParameterSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void showBasisDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->基础显示
        {

        }
        private void showStandardDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->标准显示
        {

        }
        private void showAllDataClick(object sender, RoutedEventArgs e)//海图管理->海图显示->全部显示
        {

        }

        private void toBiggerClick(object sender, RoutedEventArgs e)//海图管理->海图操作->缩小
        {
            App app = (App)App.Current;
            app.chartCtrl.ZoomIn();
        }
        private void toSmallerClick(object sender, RoutedEventArgs e)//海图管理->海图操作->放大
        {
            App app = (App)App.Current;
            app.chartCtrl.ZoomOut();
        }

        private void settingMeasuringScaleClick(object sender, RoutedEventArgs e)//海图管理->海图操作->指定比例尺
        {
            SetMeasuringScale w = new SetMeasuringScale();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void measureDistanceClick(object sender, RoutedEventArgs e)//海图管理->海图操作->测距
        {
            Monitoring.StartRangingBack();
        }

        private void topMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->上移
        {
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Up);
        }
        private void bottomMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->下移
        {
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Down);
        }
        private void leftMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->左移
        {
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Left);
        }
        private void rightMoveClick(object sender, RoutedEventArgs e)//海图管理->海图操作->右移
        {
            App app = (App)App.Current;
            app.chartCtrl.MoveMap(MovingDirection.Right);
        }
        private void convertClick(object sender, RoutedEventArgs e)//海图管理->海图操作->归心
        {
            App app = (App)App.Current;
            app.chartCtrl.CenterMap();
        }

        private void moveClick(object sender, RoutedEventArgs e)//漫游
        {
            App app = (App)App.Current;
            if (isHandRoam == false)
            {
                app.chartCtrl.StartHandRoam();
                isHandRoam = true;
            }
            else
            {
                app.chartCtrl.EndHandRoam();
                isHandRoam = false;
            }

        }

        private void mapManageClick(object sender, RoutedEventArgs e)//海图管理->图库管理
        {
            MapManage w = new MapManage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void dataQueryClick(object sender, RoutedEventArgs e)//数据管理->数据查询
        {
            DataQuery p = new DataQuery();
            content.Content = p;
        }
        private void dateStatisticsClick(object sender, RoutedEventArgs e)//数据管理->数据统计
        {
            DateStatistics p = new DateStatistics();
            content.Content = p;
        }
        private void queryTrackClick(object sender, RoutedEventArgs e)//数据管理->航迹查询
        {
            if (!isInShowingTrackMode)
            {
                QueryTrack wqt = new QueryTrack();
                System.Windows.Application.Current.MainWindow = wqt;
                wqt.ShowDialog();
            }
            queryTrack(sender, e);
        }
        private void queryTrack(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            if (isInShowingTrack == false)
            {
                app.chartCtrl.SetShowTrackOrNot(true);
                isInShowingTrack = true;
            }
            else
            {
                app.chartCtrl.SetShowTrackOrNot(false);
                isInShowingTrack = false;
            }
        }

        private void situationPlaybackClick(object sender, RoutedEventArgs e)//数据管理->态势回放
        {

        }

        private void dateExportClick(object sender, RoutedEventArgs e)//数据管理->数据导出
        {
            DateExport p = new DateExport();
            content.Content = p;
        }
        private void deviceOperationStatusClick(object sender, RoutedEventArgs e)//设备管理->设备运行状态
        {
            DeviceOperationStatus p = new DeviceOperationStatus();
            content.Content = p;
        }
        private void deviceNetworkStatuisClick(object sender, RoutedEventArgs e)//设备管理->设备网络状态
        {
            DeviceNetworkStatuis p = new DeviceNetworkStatuis();
            content.Content = p;
        }

        private void userManagementClick(object sender, RoutedEventArgs e)//系统管理->用户管理
        {
            UserManagement p = new UserManagement();
            content.Content = p;
        }
        private void roleManageClick(object sender, RoutedEventArgs e)//系统管理->权限管理->角色管理
        {
            RoleManage w = new RoleManage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }
        private void rolePermissionManageClick(object sender, RoutedEventArgs e)//系统管理->权限管理->角色权限管理
        {
            RolePermisionManage w = new RolePermisionManage();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void networkParameterSettingClick(object sender, RoutedEventArgs e)//系统管理->参数设置->网络参数设置
        {
            NetworkParameterSetting w = new NetworkParameterSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }
        private void platformPositionSettingClick(object sender, RoutedEventArgs e)//系统管理->参数设置->平台位置设置
        {
            PlatformPositionSetting w = new PlatformPositionSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }
        private void gorgeParameterSettingClick(object sender, RoutedEventArgs e)//系统管理->参数设置->串口参数设置
        {
            GorgeParameterSetting w = new GorgeParameterSetting();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();
        }

        private void helpClick(object sender, RoutedEventArgs e)
        {

        }

        //***********************************************************************************
        //*******************************工具栏事件******************************************
        //***********************************************************************************
        private void doubleScreenShowClick(object sender, RoutedEventArgs e)//双屏显示
        {
            //video1.Visibility = Visibility.Collapsed;
            //video2.Visibility = Visibility.Collapsed;
            //video3.Visibility = Visibility.Collapsed;
            try
            {
/*              Window28 w2 = new Window28();
                System.Windows.Application.Current.MainWindow = w2;
                w2.Show();

                //buju.ColumnDefinitions.RemoveAt(0);

                Window27 w1 = new Window27();
                System.Windows.Application.Current.MainWindow = w1;
                w1.Show();
                this.Close();*/
            }
            catch (Exception ex)
            {
                MessageBoxX.Show("异常信息", "未检测到扩展屏，请确定扩展屏正常连接！");//显示异常信息
            }

        }

        private void platformCenteringClick(object sender, RoutedEventArgs e)//平台归心
        {

        }

        private void partToBiggerClick(object sender, RoutedEventArgs e)//区域放大
        {

        }

        private void followingVideoClick(object sender, RoutedEventArgs e)//视频跟踪
        {

        }

        private void returnClick(object sender, RoutedEventArgs e)//返回主界面
        {
            content.Content = Monitoring.MonitoringObj;
        }
    }
}
