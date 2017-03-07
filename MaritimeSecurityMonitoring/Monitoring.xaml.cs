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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Threading;
using System.Diagnostics;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Windows.Interop;
using PhotoelectricModule;
using System.Threading;

using dataAnadll;
using YimaWF.data;
using YimaEncCtrl;
using NVRCsharpDemo;


namespace MaritimeSecurityMonitoring.MainInterfacePage
{
    /// <summary>
    /// Monitoring.xaml 的交互逻辑
    /// </summary>
    public delegate void AddedForbiddenZoneDelegate(ForbiddenZone f);
    public partial class Monitoring : Page
    {

        private DispatcherTimer timer = new DispatcherTimer();

        List<AllTarget> allList = new List<AllTarget>();
        List<AISTarget> AISList = new List<AISTarget>();
        List<RadarTarget> radarList = new List<RadarTarget>();
        List<MixTarget> mixList = new List<MixTarget>();
        List<WarnTarget> warnList = new List<WarnTarget>();

        public bool focusDownClickbool = false;
        public bool focusUpClickbool = false;
        public bool focusDownMoreClickbool = false;
        public bool focusUpMoreClickbool = false;
        public int directionValue = 0;
        public int pitchValue = 0;
        public bool hfocusDownClickbool = false;
        public bool hfocusUpClickbool = false;
        public bool hfocusDownMoreClickbool = false;
        public bool hfocusUpMoreClickbool = false;
        public int horizontalLeft = 0;
        public int horizontalRight = 0;
        public int pitchingUp = 0;
        public int pitchingDown = 0;

        public int driveSwitch = 1;
        public int infraredSwitch = 1;
        public int trackingAlgorithm = 0;
        public int trackImage = 0;
        public int leftLimitAngle = 45;
        public int rightLimitAngle = 45;
        public int sweepSpeed=30;

        public int targetId = 0;
        public int radarId = 0;

        //DVRTest是一个DVR播放测试类
        string sDVRIP = "192.6.1.33";//光电设备ip
        //DVR的IP地址
        Int32 WDVRPort = 8000;
        //DVR端口号
        string sUserName = "admin";
        string sPassword = "12345yyz";//登录光电球
        //string sPassword = "12345";//登录硬盘录像机12345";
        //用户名和密码
        IntPtr infraredRayRealWndHandle;
        IntPtr followingPictureRealWndHandle;
        IntPtr telephotoRealWndHandle;
        //标识子
        int []videoState=new int[4];

        public static dataAna s = new dataAna();

        public static Monitoring MonitoringObj;

        public Monitoring()
        {
            InitializeComponent();
            //s.anaInit(new dataAna.DMMmessage(get), "192.6.1.192", 8123, 8066);//融合信息交互接口
            //s.anaInit(new dataAna.DMMmessage(get), "192.168.0.121", 8123, 8066);//测试信息交互接口
            new Photoelectricity().GetDeviceRuningState(new Photoelectricity.GetDRSDelegate(ShowState));//控制面板通信

            App app = (App)App.Current;
            app.chartCtrl = yimaEncCtrl;

            yimaEncCtrl.AddedForbiddenZone += YimaEncCtrl_AddedForbiddenZone;//绘制多边形的回调函数注册
            yimaEncCtrl.AddedPipeline += YimaEncCtrl_AddedPipeline;//绘制管道的回调函数注册
            yimaEncCtrl.ShowRangingResult += YimaEncCtrl_ShowRangingResultDelegate;//测距回调函数注册

            Monitoring.MonitoringObj = this;
        }
        /*光电视频播放模块（start）*************************************************************************************/
        public void realPlay()
        {
            int sign=NVRCsharpDemo.DVRAPI.GetInstance().DVRAPI_Init(sDVRIP, WDVRPort, sUserName, sPassword);
            /*if (sign == -1)
            {
                System.Windows.MessageBox.Show("连接DVR设备，初始化失败");
            }
            else if (sign == -2)
            {
                System.Windows.MessageBox.Show("连接DVR设备，登录失败");
            }
            else if (sign == -3)
            {
                System.Windows.MessageBox.Show("连接DVR设备，已经初始化和登录");
            }
            else if (sign == 0)
            {
                System.Windows.MessageBox.Show("连接DVR设备，登录成功");
            }*/
            videoState[0] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(1, infraredRayRealWndHandle);
            /*if (videoState[0] == -1)
            {
                System.Windows.MessageBox.Show("红外视频播放失败");
            }
            else if (videoState[0] == -2)
            {
                System.Windows.MessageBox.Show("未登录，开始播放红外视频");
            }
            else
            {
                System.Windows.MessageBox.Show("播放跟踪视频成功");
            }*/
            videoState[1] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(2, followingPictureRealWndHandle);
            /*if (videoState[1] == -1)
            {
                System.Windows.MessageBox.Show("跟踪视频播放失败");
            }
            else if (videoState[1] == -2)
            {
                System.Windows.MessageBox.Show("未登录，开始播放跟踪视频");
            }
            else
            {
                System.Windows.MessageBox.Show("播放跟踪视频成功");
            }*/
            videoState[2] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(3, telephotoRealWndHandle);
            /*if (videoState[2] == -1)
            {
                System.Windows.MessageBox.Show("长焦视频播放失败");
            }
            else if (videoState[2] == -2)
            {
                System.Windows.MessageBox.Show("未登录，开始播放长焦视频");
            }
            else
            {
                System.Windows.MessageBox.Show("播放长焦视频成功");
            }*/
            //videoState[3] = NVRCsharpDemo.DVRAPI.GetInstance().Start_RealPlay(4, telephotoRealWndHandle);
            //开始播放
        }
        private void startPlay()
        {
            infraredRayRealWndHandle = infraredRayPictureBox.Handle;//红外
            followingPictureRealWndHandle = followingPictureBox.Handle;//跟踪
            telephotoRealWndHandle = telephotoPictureBox.Handle;//长焦
            Thread Thread = new Thread(new ThreadStart(realPlay));
            //此处demo处理多线程时，使用了最简单的无参法，参数的设置放在了realPlay()里面
            Thread.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState[0]);
            NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState[1]);
            NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState[2]);
          //  NVRCsharpDemo.DVRAPI.GetInstance().Stop_RealPlay(videoState[3]);
            //停止播放
        }
        /*光电视频播放模块（end）*************************************************************************************/

        public static void StartRangingBack()
        {
            App app = (App)App.Current;
            app.chartCtrl.StartRanging();
        }
        private static void YimaEncCtrl_ShowRangingResultDelegate(int len)
        {
            System.Windows.MessageBox.Show("距离为" + len.ToString() + " 毫米");
        }

        /*融合参数设置模块（start）***********************************************************************************/
        public static void FusionBack()//融合参数回调
        {
            //模拟发送融合参数
            FUS_ICD.FusPara_S fuspara = new FUS_ICD.FusPara_S();
            fuspara.fXYZThreshold = FusionParameterSetting.fXYZThreshold;
            fuspara.fDisThreshold = FusionParameterSetting.fDisThreshold;
            fuspara.fAngleThreshold = FusionParameterSetting.fAngleThreshold;
            fuspara.ucAlarmThreshold = FusionParameterSetting.ucAlarmThreshold;
            fuspara.lRdDieTime = FusionParameterSetting.lRdDieTime;
            fuspara.lAISDieTime = FusionParameterSetting.lAISDieTime;
            fuspara.lM = FusionParameterSetting.lM;
            fuspara.lN = FusionParameterSetting.lN;
            fuspara.UcEstiArith = FusionParameterSetting.UcEstiArith;
            byte[] reserve = new byte[2];
            fuspara.reserve = reserve;
            s.SendFusParaS(fuspara);
        }
        /*融合参数设置模块（end）***********************************************************************************/

        /*保护区域设置模块（start）*********************************************************************************/
        public static void AddProtectZoneBack()//添加圈层保护区
        {
            FUS_ICD.Alarm_Dot_S centerPoint = new FUS_ICD.Alarm_Dot_S();
            centerPoint.fHeight = 0f;

            FUS_ICD.Alarm_Circle_S circle = new FUS_ICD.Alarm_Circle_S();
            circle.fAlarmR = DefenseCircleSetting.fAlarmR;
            circle.ucAlarmLevel = DefenseCircleSetting.ucAlarmLevel;
            circle.ucCycleAlarmNum = DefenseCircleSetting.ucCycleAlarmNum;
            circle.AlarmCenter = centerPoint;

            System.Drawing.Color colorValue = ColorTranslator.FromHtml(DefenseCircleSetting.color);
            App app = (App)App.Current;
            app.chartCtrl.AddProtectZone(null, DefenseCircleSetting.fAlarmR, colorValue, DefenseCircleSetting.name);
            s.SetAlarmAear(circle, 1, DefenseCircleSetting.rankNumber);


            //模拟圈层参数区域设置（删除）
            /*
            FUS_ICD.Alarm_Dot_S centerPoint = new FUS_ICD.Alarm_Dot_S();
            centerPoint.dLongti = DefenseCircleSetting.dLongti;
            centerPoint.dLati = DefenseCircleSetting.dLati;
            centerPoint.fHeight = 0f;

            FUS_ICD.Alarm_Circle_S circle = new FUS_ICD.Alarm_Circle_S();
            circle.fAlarmR = DefenseCircleSetting.fAlarmR;
            circle.ucAlarmLevel = DefenseCircleSetting.ucAlarmLevel;
            circle.ucCycleAlarmNum = DefenseCircleSetting.ucCycleAlarmNum;
            circle.AlarmCenter = centerPoint;

            s.CancelAlarmAear(circle, 1, 2);//删除信号数据发出
            yimaEncCtrl.DeleteProtectZoneByName(DefenseCircleSetting.name);
            */
        }
        public static void AddedForbiddenZoneBack()//添加多边形区域
        {
            //模拟多边形区域设置（创建）
            App app = (App)App.Current;
            app.chartCtrl.StartAddForbiddenZone();

            //模拟多边形区域设置（删除）
            /*
            AddedForbiddenZoneStatus = false;
            yimaEncCtrl.ForbiddenZoneList[0].Name = PolygonDialog.polygonNameText;
            int aLarmRank = (int)double.Parse(PolygonDialog.aLarmRankText);

            FUS_ICD.Alarm_Dot_S[] points = new FUS_ICD.Alarm_Dot_S[10];

            for (int i = 0; i < yimaEncCtrl.ForbiddenZoneList[0].PointList.Count; i++)
            {
                points[i].dLati = yimaEncCtrl.ForbiddenZoneList[0].PointList[i].x;
                points[i].dLongti = yimaEncCtrl.ForbiddenZoneList[0].PointList[i].y;
                points[i].fHeight = 0;
            };

            FUS_ICD.Alarm_Polygon_S test = new FUS_ICD.Alarm_Polygon_S();
            test.ucAlarmLevel = (byte)aLarmRank;
            test.ucPolygonAlarmNum = (byte)(210 + aLarmRank);
            test.ucPotNum = 1;
            test.PotArray = points;

            s.CancelAlarmAear(test, 2, 2);//删除信号数据发出
            yimaEncCtrl.DeleteForbiddenZoneByName(PolygonDialog.polygonNameText);//删除海图部分对边形
            */
        }
        public static void AddedPipelineBack()//添加管道区域
        {
            //模拟管道区域设置（创建）
            App app = (App)App.Current;
            app.chartCtrl.StartAddPipeline();

            //模拟管道区域设置（删除）
            /*
            AddedForbiddenZoneStatus = false;
            yimaEncCtrl.PipelineList[0].Name = PolygonDialog.polygonNameText;
            int aLarmRank = (int)double.Parse(PolygonDialog.aLarmRankText);

            FUS_ICD.Alarm_Dot_S[] points = new FUS_ICD.Alarm_Dot_S[10];

            for (int i = 0; i < yimaEncCtrl.PipelineList[0].PointList.Count; i++)
            {
                points[i].dLati = yimaEncCtrl.PipelineList[0].PointList[i].x;
                points[i].dLongti = yimaEncCtrl.PipelineList[0].PointList[i].y;
                points[i].fHeight = 0;
            };

            FUS_ICD.Alarm_Polygon_S test = new FUS_ICD.Alarm_Polygon_S();
            test.ucAlarmLevel = (byte)aLarmRank;
            test.ucPolygonAlarmNum = (byte)(210 + aLarmRank);
            test.ucPotNum = 1;
            test.PotArray = points;

            s.CancelAlarmAear(test, 3, 2);//删除信号数据发出
            yimaEncCtrl.DeletePipelineByName(PolygonDialog.polygonNameText);//删除海图部分对边形
            */
        }
        private static void YimaEncCtrl_AddedForbiddenZone(ForbiddenZone f)//多边形区域回调函数
        {
            PolygonDialog w = new PolygonDialog();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();

            App app = (App)App.Current;

            f.Name = PolygonDialog.polygonNameText;
            int aLarmRank = (int)double.Parse(PolygonDialog.aLarmRankText);

            FUS_ICD.Alarm_Dot_S[] points = new FUS_ICD.Alarm_Dot_S[10];

            int lastList = app.chartCtrl.ForbiddenZoneList.Count - 1;
            for (int i = 0; i < app.chartCtrl.ForbiddenZoneList[lastList].PointList.Count; i++)
            {
                points[i].dLati = app.chartCtrl.ForbiddenZoneList[lastList].PointList[i].x;
                points[i].dLongti = app.chartCtrl.ForbiddenZoneList[lastList].PointList[i].y;
                points[i].fHeight = 0;
            };

            FUS_ICD.Alarm_Polygon_S test = new FUS_ICD.Alarm_Polygon_S();
            test.ucAlarmLevel = (byte)aLarmRank;
            test.ucPolygonAlarmNum = (byte)(210 + aLarmRank);
            test.ucPotNum = Convert.ToByte(app.chartCtrl.ForbiddenZoneList[lastList].PointList.Count);
            test.PotArray = points;

            s.SetAlarmAear(test, 2, 1);
        }
        private static void YimaEncCtrl_AddedPipeline(Pipeline p)//管道区域回调函数
        {
            PolygonDialog w = new PolygonDialog();
            System.Windows.Application.Current.MainWindow = w;
            w.ShowDialog();

            App app = (App)App.Current;

            p.Name = PolygonDialog.polygonNameText;
            p.width = (int)double.Parse(PolygonDialog.polygonWidthText);
            int aLarmRank = (int)double.Parse(PolygonDialog.aLarmRankText);

            FUS_ICD.Alarm_Dot_S[] points = new FUS_ICD.Alarm_Dot_S[10];

            int lastList = app.chartCtrl.PipelineList.Count - 1;
            for (int i = 0; i < app.chartCtrl.PipelineList[lastList].PointList.Count; i++)
            {
                points[i].dLati = app.chartCtrl.PipelineList[lastList].PointList[i].x;
                points[i].dLongti = app.chartCtrl.PipelineList[lastList].PointList[i].y;
                points[i].fHeight = 0;
            };

            FUS_ICD.Alarm_Polygon_S test = new FUS_ICD.Alarm_Polygon_S();
            test.ucAlarmLevel = (byte)aLarmRank;
            test.ucPolygonAlarmNum = (byte)(220 + aLarmRank);
            test.ucPotNum = Convert.ToByte(app.chartCtrl.PipelineList[lastList].PointList.Count);
            test.PotArray = points;

            s.SetAlarmAear(test, 3, 1);
        }
        /*保护区域设置模块（end）*********************************************************************************/

        /*列表数据显示模块（start）******************************************************************************/
        public void get(int tip,object data)//航船目标AIS，雷达，融合数据接收回调函数
        {
            switch ( tip )
           {
                case 100:
                    //statements FusTarget_S，接收到融合数据，告警数据处理
                    FUS_ICD.FusTarget_S fus = (FUS_ICD.FusTarget_S)data;

                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        String dateTypes = "adddata";
                        String warnTypes = "nowarn";

                        for (int i = 0; i < mixDataGrid.Items.Count; i++)//判断输入的数据是新添加的还是已有目标的更新
                        {
                            if (mixList[i].mixBatchNumber == (fus.lFusBatchID).ToString())
                            {
                                dateTypes = "updata";
                            };
                        };

                        if ((int)(fus.ucAlarmNum) != 0)//判断是否具有报警相关信息
                        {
                            warnTypes = "addwarn";
                            for (int i = 0; i < warnDataGrid.Items.Count; i++)//判断输入的警告是新添加还是也已有警告的跟新
                            {
                                if (warnList[i].mixBatchNumber == (fus.lFusBatchID).ToString())
                                {
                                    warnTypes = "updatawarn";
                                };
                            };
                        };


                        if (dateTypes == "adddata")//添加列表对象
                        {
                            targetId++;
                            MixTarget mt = new MixTarget()//添加融合对象
                            {
                                targetId=targetId,
                                mixBatchNumber = (fus.lFusBatchID).ToString(),
                                //MMSI = (ais.ulRecoCode).ToString(),
                                IMO = (fus.ulAISBatchID).ToString(),
                                longitude = (fus.dLongti).ToString(),
                                latitude = (fus.dLati).ToString(),
                                distance = (fus.fDistance).ToString(),
                                speed = (fus.fSpeed).ToString(),
                                steeringAngle = (fus.dNorthCourse).ToString(),
                                boatName = new string(fus.cName),
                                callSign = new string(fus.cCall_ID),
                                cargoType = (fus.ucShipType).ToString(),
                                //sailingStatus = (ais.ucSailStatus).ToString(),
                            };
                            mixList.Add(mt);
                            mixDataGrid.ItemsSource = mixList;

                            AllTarget at = new AllTarget()//添加全部目标对象
                            {
                                targetId = targetId,
                                dataType = "融合",
                                batchNumber = (fus.lFusBatchID).ToString(),
                                //MMSI = (ais.ulRecoCode).ToString(),
                                IMO = (fus.ulAISBatchID).ToString(),
                                longitude = (fus.dLongti).ToString(),
                                latitude = (fus.dLati).ToString(),
                                distance = (fus.fDistance).ToString(),
                                speed = (fus.fSpeed).ToString(),
                                steeringAngle = (fus.dNorthCourse).ToString(),
                                boatName = new string(fus.cName),
                                callSign = new string(fus.cCall_ID),
                                cargoType = (fus.ucShipType).ToString(),
                                //sailingStatus = (ais.ucSailStatus).ToString(),
                            };
                            allList.Add(at);
                            allDataGrid.ItemsSource=allList;

                            float dNorthCourse = (float)(fus.dNorthCourse);
                            Target fu = new Target(targetId, dNorthCourse, fus.fSpeed);

                            int warnTypeNumber = fus.ucAlarmNum & ((ushort)255);//判断告警的类型
                            if (warnTypeNumber >= 201 && warnTypeNumber <= 205)
                            {
                                fu.Alarm = AlarmType.ProtectZone;
                            }
                            else if (warnTypeNumber >= 211 && warnTypeNumber <= 215)
                            {
                                fu.Alarm = AlarmType.ForbiddenZone;
                            }
                            else if (warnTypeNumber >= 221 && warnTypeNumber <= 225)
                            {
                                fu.Alarm = AlarmType.Pipeline;
                            }

                            yimaEncCtrl.AddMergeTarget(fu, fus.dLongti, fus.dLati);//添加全部，融合目标
                        };

                        if (dateTypes == "updata")//更新列表对象
                        {
                            int id = 0;
                            for (int i = 0; i < mixDataGrid.Items.Count; i++)//对已有列表遍历，查找对应数据行
                            {
                                if (mixList[i].mixBatchNumber == (fus.lFusBatchID).ToString())
                                {
                                    id = mixList[i].targetId;
                                    mixList[i].mixBatchNumber = (fus.lFusBatchID).ToString();
                                    //mixList[i].MMSI = (ais.ulRecoCode).ToString();
                                    mixList[i].IMO = (fus.ulAISBatchID).ToString();
                                    mixList[i].longitude = (fus.dLongti).ToString();
                                    mixList[i].latitude = (fus.dLati).ToString();
                                    mixList[i].distance = (fus.fDistance).ToString();
                                    mixList[i].speed = (fus.fSpeed).ToString();
                                    mixList[i].steeringAngle = (fus.dNorthCourse).ToString();
                                    mixList[i].boatName = new string(fus.cName);
                                    mixList[i].callSign = new string(fus.cCall_ID);
                                    mixList[i].cargoType = (fus.ucShipType).ToString();
                                    //mixList[i].sailingStatus = (ais.ucSailStatus).ToString();
                                };
                            };


                            for (int i = 0; i < allDataGrid.Items.Count; i++)
                            {
                                if (allList[i].batchNumber == (fus.lFusBatchID).ToString())
                                {             
                                    allList[i].dataType = "融合";
                                    allList[i].batchNumber = (fus.lFusBatchID).ToString();
                                    //allList[i].MMSI = (ais.ulRecoCode).ToString();
                                    allList[i].IMO = (fus.ulAISBatchID).ToString();
                                    allList[i].longitude = (fus.dLongti).ToString();
                                    allList[i].latitude = (fus.dLati).ToString();
                                    allList[i].distance = (fus.fDistance).ToString();
                                    allList[i].speed = (fus.fSpeed).ToString();
                                    allList[i].steeringAngle = (fus.dNorthCourse).ToString();
                                    allList[i].boatName = new string(fus.cName);
                                    allList[i].callSign = new string(fus.cCall_ID);
                                    allList[i].cargoType = (fus.ucShipType).ToString();
                                    //allList[i].sailingStatus = (ais.ucSailStatus).ToString();
                                };
                            };
                            mixDataGrid.Items.Refresh();
                            allDataGrid.Items.Refresh();

                            float dNorthCourse = (float)(fus.dNorthCourse);
                            Target fu = new Target(id, dNorthCourse, fus.fSpeed);

                            int warnTypeNumber = fus.ucAlarmNum & ((ushort)255);//判断告警的类型
                            if (warnTypeNumber >= 201 && warnTypeNumber <= 205)
                            {
                                fu.Alarm = AlarmType.ProtectZone;
                            }
                            else if (warnTypeNumber >= 211 && warnTypeNumber <= 215)
                            {
                                fu.Alarm = AlarmType.ForbiddenZone;
                            }
                            else if (warnTypeNumber >= 221 && warnTypeNumber <= 225)
                            {
                                fu.Alarm = AlarmType.Pipeline;
                            }

                            yimaEncCtrl.UpdateMergeTarget(fu, fus.dLongti, fus.dLati);//更新全部，融合目标
                        };


                        if (warnTypes == "addwarn")
                        {
                            String AlarmNumtype = "";
                            int warnTypeNumber = fus.ucAlarmNum & ((ushort)255);//判断告警的类型
                            if (warnTypeNumber >= 201 && warnTypeNumber <= 205)
                            {
                                AlarmNumtype = "圈层区域告警";
                                //fusObj.Alarm = AlarmType.None;//AlarmType.ProtectZone;
                            }
                            else if (warnTypeNumber >= 211 && warnTypeNumber <= 215)
                            {
                                AlarmNumtype = "多边形区域告警";
                                //fusObj.Alarm = AlarmType.ForbiddenZone;
                            }
                            else if (warnTypeNumber >= 221 && warnTypeNumber <= 225)
                            {
                                AlarmNumtype = "管道区域告警";
                                //fusObj.Alarm = AlarmType.Pipeline;
                            }

                            String warntime = GetTime((fus.lTime).ToString()).ToString();//转化时间戳为日期

                            WarnTarget wt = new WarnTarget()//添加告警列表对象
                            {
                                mixBatchNumber = (fus.lFusBatchID).ToString(),
                                alarmTime = warntime,
                                //MMSI = MMSIInformation[P % 6],
                                alarmType = AlarmNumtype,
                                alarmContent = "船舶[" + (fus.lFusBatchID).ToString() + "]" + AlarmNumtype,
                                isCheck = false,
                                isConfirmed = false,
                            };
                            warnList.Add(wt);
                            warnDataGrid.ItemsSource=warnList;

                            warnDataGrid.Items.Refresh();
                        };

                        if (warnTypes == "updatawarn")//更新报警数据
                        {
                            for (int i = 0; i < warnDataGrid.Items.Count; i++)//修改已有数据中的告警信息
                            {
                                if (mixList[i].mixBatchNumber == (fus.lFusBatchID).ToString())
                                {
                                    warnList[i].mixBatchNumber = (fus.lFusBatchID).ToString();
                                    warnList[i].alarmTime = GetTime((fus.lTime).ToString()).ToString();
                                    // warnList[i].MMSI = MMSIInformation[P % 6];

                                    String AlarmNumtype = "";
                                    int warnType = fus.ucAlarmNum & ((ushort)255);//转化时间戳为日期

                                    if (warnType >= 201 && warnType <= 205)
                                    {
                                        AlarmNumtype = "圈层区域告警";
                                        //fusObj.Alarm = AlarmType.ProtectZone;
                                    }
                                    else if (warnType >= 211 && warnType <= 215)
                                    {
                                        AlarmNumtype = "多边形区域告警";
                                        //fusObj.Alarm = AlarmType.ForbiddenZone;
                                    }
                                    else if (warnType >= 221 && warnType <= 225)
                                    {
                                        AlarmNumtype = "管道区域告警";
                                        //fusObj.Alarm = AlarmType.Pipeline;
                                    }
                                    warnList[i].alarmType = AlarmNumtype;
                                    warnList[i].alarmContent = "船舶[" + (fus.lFusBatchID).ToString() + "]" + AlarmNumtype;
                                    warnList[i].isCheck = false;
                                };
                            };
                            warnDataGrid.Items.Refresh();
                        };

                    }));
                    break;
                case 2 :
　　                //statements AISMsg_S，接收AIS数据处理
                    FUS_ICD.AISMsg AIS = (FUS_ICD.AISMsg)data;
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        String dateType = "adddata";

                        for (int i = 0; i < AISDataGrid.Items.Count; i++)//判断添加新数据还是更新数据
                        {
                            if (AISList[i].MMSI == (AIS.MMSI).ToString())
                            {
                                dateType = "updata";
                            }
                        };

                        if (dateType == "adddata")
                        {
                            targetId++;
                            AISTarget at = new AISTarget()//添加AIS列表
                            {
                                targetId=targetId,
                                MMSI = AIS.MMSI,
                                IMO = (AIS.IMO).ToString(),
                                longitude = (AIS.dLong).ToString(),
                                latitude = (AIS.dLat).ToString(),
                                //distance = (AIS.dLat).ToString(),
                                speed = (AIS.fDirectSpeed).ToString(),
                                steeringAngle = (AIS.fDirectCourse).ToString(),
                                boatName = AIS.Name,
                                callSign = AIS.CallSign,
                                //cargoType = (AIS.ucShipType).ToString(),
                                sailingStatus = (AIS.SailStatus).ToString(),
                            };
                            AISList.Add(at);
                            AISDataGrid.ItemsSource=AISList;

                            AllTarget allt = new AllTarget()//添加全部目标列表
                            {
                                targetId=targetId,
                                dataType = "AIS",
                                //batchNumber = (RdD1.lTargetNo).ToString(),
                                MMSI = AIS.MMSI,
                                IMO = (AIS.IMO).ToString(),
                                longitude = (AIS.dLong).ToString(),
                                latitude = (AIS.dLat).ToString(),
                                //distance = (RdD1.dLati).ToString(),
                                speed = (AIS.fDirectSpeed).ToString(),
                                steeringAngle = (AIS.fDirectCourse).ToString(),
                                boatName = AIS.Name,
                                callSign = AIS.CallSign,
                                //cargoType = (fus.ucShipType).ToString(),
                                sailingStatus = (AIS.SailStatus).ToString(),
                            };
                            allList.Add(allt);
                            allDataGrid.ItemsSource=allList;

                            Target obj = new Target(targetId, AIS.fDirectCourse, AIS.fDirectSpeed);
                            yimaEncCtrl.AddAISTarget(obj, AIS.dLong, AIS.dLat);//添加海图目标
                        };

                        if (dateType == "updata")//更新AIS数据
                        {
                            int id = 0;
                            for (int i = 0; i < AISDataGrid.Items.Count; i++)
                            {
                                if (AISList[i].MMSI == (AIS.MMSI).ToString())//更新AIS列表
                                {
                                    id = AISList[i].targetId;
                                    //AISList[j].batchNumber = (RdD1.lTargetNo).ToString(),
                                    AISList[i].MMSI = AIS.MMSI;
                                    AISList[i].IMO = (AIS.IMO).ToString();
                                    AISList[i].longitude = (AIS.dLong).ToString();
                                    AISList[i].latitude = (AIS.dLat).ToString();
                                    //AISList[i].distance = (RdD1.dLati).ToString();
                                    AISList[i].speed = (AIS.fDirectSpeed).ToString();
                                    AISList[i].steeringAngle = (AIS.fDirectCourse).ToString();
                                    AISList[i].boatName = AIS.Name;
                                    AISList[i].callSign = AIS.CallSign;
                                    //AISList[i].cargoType = (fus.ucShipType).ToString();
                                    AISList[i].sailingStatus = (AIS.SailStatus).ToString();
                                };
                            };

                            for (int i = 0; i < allDataGrid.Items.Count; i++)//更新所有目标列表
                            {
                                if (allList[i].MMSI == (AIS.MMSI).ToString())
                                {
                                    //allList[i].batchNumber = (RdD1.lTargetNo).ToString(),
                                    allList[i].MMSI = AIS.MMSI;
                                    allList[i].IMO = (AIS.IMO).ToString();
                                    allList[i].longitude = (AIS.dLong).ToString();
                                    allList[i].latitude = (AIS.dLat).ToString();
                                    //allList[i].distance = (RdD1.dLati).ToString();
                                    allList[i].speed = (AIS.fDirectSpeed).ToString();
                                    allList[i].steeringAngle = (AIS.fDirectCourse).ToString();
                                    allList[i].boatName = AIS.Name;
                                    allList[i].callSign = AIS.CallSign;
                                    //allList[i].cargoType = (fus.ucShipType).ToString();
                                    allList[i].sailingStatus = (AIS.SailStatus).ToString();
                                };
                            };
                            AISDataGrid.Items.Refresh();
                            allDataGrid.Items.Refresh();

                            Target obj = new Target(id, AIS.fDirectCourse, AIS.fDirectSpeed);
                            yimaEncCtrl.UpdateAISTarget(obj, AIS.dLong, AIS.dLat);//更新海图AIS对象
                        };

                    }));           
　　                break;
           case 3:
                 //statements RdDetectMsg_S(雷达1),接收雷达数据处理
                 FUS_ICD.RdDetectMsg_S RdD1 = (FUS_ICD.RdDetectMsg_S)data;
                 this.Dispatcher.Invoke(new Action(() =>
                 {
                     String dateType = "adddata";

                     for (int i = 0; i < radarDataGrid.Items.Count; i++)//判断添加数据还是更新数据
                     {
                         if (radarList[i].batchNumber == (RdD1.lTargetNo).ToString())
                         {
                             dateType = "updata";
                         }
                     };

                     if (dateType == "adddata")//添加雷达数据
                     {
                         targetId++;
                         radarId++;
                         RadarTarget rt = new RadarTarget()//添加雷达数据
                         {
                             targetId = targetId,
                             radarId = radarId,
                             batchNumber = (RdD1.lTargetNo).ToString(),
                             longitude = (RdD1.dLongti).ToString(),
                             latitude = (RdD1.dLati).ToString(),
                             distance = (RdD1.ulTargetDis).ToString(),
                             speed = (RdD1.ulTargetSpeed).ToString(),
                             steeringAngle = (RdD1.ulTargetCourse).ToString(),
                         };
                         radarList.Add(rt);
                         radarDataGrid.ItemsSource=radarList;

                         AllTarget at = new AllTarget()//添加所有数据
                         {
                             targetId=targetId,
                             dataType = "雷达",
                             batchNumber = (RdD1.lTargetNo).ToString(),
                             //MMSI = (ais.ulRecoCode).ToString(),
                             //IMO = (fus.ulAISBatchID).ToString(),
                             longitude = (RdD1.dLongti).ToString(),
                             latitude = (RdD1.dLati).ToString(),
                             distance = (RdD1.ulTargetDis).ToString(),
                             speed = (RdD1.ulTargetSpeed).ToString(),
                             steeringAngle = (RdD1.ulTargetCourse).ToString(),
                             //boatName = new string(fus.cName),
                             //callSign = new string(fus.cCall_ID),
                             //cargoType = (fus.ucShipType).ToString(),
                             //sailingStatus = (ais.ucSailStatus).ToString(),
                         };
                         allList.Add(at);
                         allDataGrid.ItemsSource=allList;

                         Target radar = new Target(targetId, RdD1.ulTargetCourse, RdD1.ulTargetSpeed);
                         radar.RadarID = radarId;
                         yimaEncCtrl.AddRadarTarget(radar, RdD1.dLongti, RdD1.dLati);//添加海图雷达目标
                     };

                     if (dateType == "updata")//更新数据
                     {
                         int id1 = 0;
                         int id2 = 0;
                         for (int i = 0; i < radarDataGrid.Items.Count; i++)//更新雷达列表
                         {
                             if (radarList[i].batchNumber == (RdD1.lTargetNo).ToString())
                             {                
                                 id1 = radarList[i].targetId;
                                 id2 = radarList[i].radarId;
                                 radarList[i].batchNumber = (RdD1.lTargetNo).ToString();
                                 radarList[i].longitude = (RdD1.dLongti).ToString();
                                 radarList[i].latitude = (RdD1.dLati).ToString();
                                 radarList[i].distance = (RdD1.ulTargetDis).ToString();
                                 radarList[i].speed = (RdD1.ulTargetSpeed).ToString();
                                 radarList[i].steeringAngle = (RdD1.ulTargetCourse).ToString();
                             };
                         };

                         for (int i = 0; i < allDataGrid.Items.Count; i++)//更新所有目标列表
                         {
                             if (allList[i].batchNumber == (RdD1.lTargetNo).ToString())
                             {
                                 allList[i].batchNumber = (RdD1.lTargetNo).ToString();
                                 allList[i].longitude = (RdD1.dLongti).ToString();
                                 allList[i].latitude = (RdD1.dLati).ToString();
                                 allList[i].distance = (RdD1.ulTargetDis).ToString();
                                 allList[i].speed = (RdD1.ulTargetSpeed).ToString();
                                 allList[i].steeringAngle = (RdD1.ulTargetCourse).ToString();
                             };
                         };
                         radarDataGrid.Items.Refresh();
                         allDataGrid.Items.Refresh();

                         Target radar = new Target(id1, RdD1.ulTargetCourse, RdD1.ulTargetSpeed);
                         radar.RadarID = id2;
                         yimaEncCtrl.UpdateRadarTarget(radar, RdD1.dLongti, RdD1.dLati);//更新海图雷达目标
                     }

                 }));
                 break;
           case 4:
                 //statements RdDetectMsg_S（雷达2）
                 FUS_ICD.RdDetectMsg_S RdD2 = (FUS_ICD.RdDetectMsg_S)data;
                 break;
　         default :
　　             //other
                 //System.Windows.MessageBox.Show("融合类型数据有误！");
　　             break;
           }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)//列表控制
        {
                      startPlay();//开始播放视频
/*
                       //1全部目标的数据表（把三种数据放在一张表中形成的）
                      int itemcount = 105;//模拟的静态数据的条数
                      for (int j = 1; j < itemcount; j++)
                      {
                          if (dataTypeInformation[j % 3] == "AIS")
                          {
                              AllTarget att = new AllTarget()
                              {
                                  dataType = dataTypeInformation[j % 3],
                                  MMSI = MMSIInformation[j % 6],
                                  IMO = IMOInformation[j % 10],
                                  longitude = longitudeInformation[j % 4],
                                  latitude = latitudeInformation[j % 4],
                                  distance = distanceInformation[j % 9],
                                  speed = speedInformation[(j * j * j) % 6],
                                  steeringAngle = steeringAngleInformation[j % 7],
                                  boatName = boatNameInformation[j % 4],
                                  callSign = (402412301 + j).ToString(),
                                  cargoType = cargoTypeInformation[j % 8],
                                  sailingStatus = sailingStatusInformation[j % 4],
                              };
                              allList.Add(att);
                              allInformation.Add(att);
                              allTargetView.Source = allInformation;
                              allListView.DataContext = allTargetView;
                          }
 */                         
                          /*if (dataTypeInformation[j % 3] == "雷达")
                          {
                              allInformation.Add(new AllTarget()
                              {
                                  dataType = dataTypeInformation[j % 3],
                                  batchNumber = (452316854 + j).ToString(),
                                  longitude = longitudeInformation[j % 4],
                                  latitude = latitudeInformation[j % 4],
                                  distance = distanceInformation[j % 9],
                                  speed = speedInformation[(j * j * j) % 6],
                                  steeringAngle = steeringAngleInformation[j % 7],
                              });
                          }
                          if (dataTypeInformation[j % 3] == "融合")
                          {
                              allInformation.Add(new AllTarget()
                              {
                                  dataType = dataTypeInformation[j % 3],
                                  batchNumber = (452316854 + j).ToString(),
                                  MMSI = MMSIInformation[j % 6],
                                  IMO = IMOInformation[j % 10],
                                  longitude = longitudeInformation[j % 4],
                                  latitude = latitudeInformation[j % 4],
                                  distance = distanceInformation[j % 9],
                                  speed = speedInformation[(j * j * j) % 6],
                                  steeringAngle = steeringAngleInformation[j % 7],
                                  boatName = boatNameInformation[j % 4],
                                  callSign = (402412301 + j).ToString(),
                                  cargoType = cargoTypeInformation[j % 8],
                                  sailingStatus = sailingStatusInformation[j % 4],
                              });
                          }
                      }*/

                      for (int P = 1; P < 10; P++)//AIS测试数据
                      {
                          AISTarget at = new AISTarget()
                          {
                              targetId=P,
                              MMSI="a"+P.ToString(),
                              IMO="b"+P.ToString(),
                              longitude="c"+P.ToString(),
                              latitude="d"+P.ToString(),
                              distance=(P*10).ToString(),
                              speed=P.ToString(),
                              steeringAngle="e"+P.ToString(),
                              boatName="f"+P.ToString(),
                              callSign="g"+P.ToString(),
                              cargoType="h"+P.ToString(),
                              sailingStatus="i"+P.ToString(),
                              alarmState=false,
                          };
                          AISList.Add(at);
                      }
                      AISDataGrid.ItemsSource=AISList;

                      for (int P = 1; P < 10; P++)//雷达测试数据
                      {
                          RadarTarget rt = new RadarTarget()
                          {
                              targetId = P,
                              radarId = P,
                              batchNumber = "ab" + P.ToString(),
                              longitude = "c" + P.ToString(),
                              latitude = "d" + P.ToString(),
                              distance = (P * 10).ToString(),
                              speed = P.ToString(),
                              steeringAngle = "e" + P.ToString(),
                          };
                          radarList.Add(rt);
                      }
                      radarDataGrid.ItemsSource=radarList;

                      for (int P = 1; P < 10; P++)//融合测试数据
                      {
                          MixTarget mt = new MixTarget()
                          {
                              targetId = P,
                              mixBatchNumber = "o" + P.ToString(),
                              MMSI = "a" + P.ToString(),
                              IMO = "b" + P.ToString(),
                              longitude = "c" + P.ToString(),
                              latitude = "d" + P.ToString(),
                              distance = (P * 10).ToString(),
                              speed = P.ToString(),
                              steeringAngle = "e" + P.ToString(),
                              boatName = "f" + P.ToString(),
                              callSign = "g" + P.ToString(),
                              cargoType = "h" + P.ToString(),
                              sailingStatus = "i" + P.ToString(),
                          };
                          mixList.Add(mt);
                      }
                      mixDataGrid.ItemsSource=mixList;

                      for (int P = 1; P < 10; P++)//所有目标测试数据
                      {
                          AllTarget at = new AllTarget()
                          {
                              targetId = P,
                              dataType = "type" + P.ToString(),
                              batchNumber = "o" + P.ToString(),
                              MMSI = "a" + P.ToString(),
                              IMO = "b" + P.ToString(),
                              longitude = "c" + P.ToString(),
                              latitude = "d" + P.ToString(),
                              distance = (P * 10).ToString(),
                              speed = P.ToString(),
                              steeringAngle = "e" + P.ToString(),
                              boatName = "f" + P.ToString(),
                              callSign = "g" + P.ToString(),
                              cargoType = "h" + P.ToString(),
                              sailingStatus = "i" + P.ToString(),
                              alarmState = false,
                          };
                          allList.Add(at);
                      }
                      allDataGrid.ItemsSource=allList;

                      for (int P = 1; P < 5; P++)//告警测试数据
                      {
                          WarnTarget wt = new WarnTarget()
                          {
                              mixBatchNumber=P.ToString(),
                              alarmTime = "2016-0" + ((P * P % 8) + 1).ToString() + "-" + (P * P % 30).ToString("00"),
                              MMSI = "a" + P.ToString(),
                              alarmType = "圈层区域告警",
                              alarmContent = "船舶[000]-" + "圈层区域告警",
                              isCheck = false,
                              isConfirmed = false,
                          };
                          warnList.Add(wt);
                      }
                      warnDataGrid.ItemsSource = warnList;
        }
        public static DateTime GetTime(string timeStamp)//时间戳转化
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        private void allCheck_Click(object sender, RoutedEventArgs e)//报警全选按钮
        {
            for (int i = warnDataGrid.Items.Count - 1; i >= 0; i--)
            {
                warnList[i].isCheck = true;
            }
            warnDataGrid.Items.Refresh();
        }

        private void oppCheck_Click(object sender, RoutedEventArgs e)//报警反选按钮
        {
            for (int i = warnDataGrid.Items.Count - 1; i >= 0; i--)
            {
                warnList[i].isCheck = !warnList[i].isCheck;
            }
            warnDataGrid.Items.Refresh();
        }

        private void delWarn_Click(object sender, RoutedEventArgs e)//报警删除按钮
        {
            for (int i = warnDataGrid.Items.Count - 1; i >= 0; i--)
            {
                if (string.Compare(warnList[i].isCheck.ToString(), "true") == 1)
                {
                    warnList.RemoveAt(i);
                }
            }
            warnDataGrid.Items.Refresh();
        }

        private void isConfirmed_Click(object sender, RoutedEventArgs e)//报警确认按钮
        {
            System.Windows.Controls.Button b = sender as System.Windows.Controls.Button;
            string mbn = Convert.ToString(b.CommandParameter);
            for (int i = warnDataGrid.Items.Count - 1; i >= 0; i--)
            {
                if (warnList[i].mixBatchNumber==mbn&& warnList[i].isConfirmed == false)
                {
                    warnList[i].isConfirmed = true;
                }
            }
            warnDataGrid.Items.Refresh();
        }

        private void autoDelWarn()//报警自动删除
        {
            
        }

        /*列表数据显示模块（end）***********************************************************************************/
        private void targetInformationBox(object sender, System.Windows.Input.MouseEventArgs e)//点击海图目标时的小弹窗
        {
            if (targetBoxInformation.Visibility == Visibility.Collapsed)
            {
                targetBoxInformation.Visibility = Visibility.Visible;
                moreInformationButton.Visibility = Visibility.Visible;
                targetBoxInformation.Items.Clear();
                string str;
                str = "船名：fish-boat";
                targetBoxInformation.Items.Add(str);
                str = "呼号：42395435";
                targetBoxInformation.Items.Add(str);
                str = "MMSI：59.35.65";
                targetBoxInformation.Items.Add(str);
                str = "IMO：93.56.23";
                targetBoxInformation.Items.Add(str);
                str = "航速：35.6KM/s";
                targetBoxInformation.Items.Add(str);
                str = "方向：正东";

                targetBoxInformation.Items.Add(str);
            }
            else
            {
                targetBoxInformation.Visibility = Visibility.Collapsed;
                moreInformationButton.Visibility = Visibility.Collapsed;
                targetBoxInformation.Items.Clear();
            }
        }
        private void getMoreInformationClick(object sender, RoutedEventArgs e)//海图小弹窗按钮点击事件，点击后出现大弹窗，显示详细信息。
        {
            targetBoxInformation.Visibility = Visibility.Collapsed;
            moreInformationButton.Visibility = Visibility.Collapsed;
        }
        private void allTargetClick(object sender, RoutedEventArgs e)
        {
            allDataGrid.Visibility = Visibility.Visible;
            AISDataGrid.Visibility = Visibility.Collapsed;
            radarDataGrid.Visibility = Visibility.Collapsed;
            mixDataGrid.Visibility = Visibility.Collapsed;      
        }
        private void AISTargetClick(object sender, RoutedEventArgs e)
        {
            allDataGrid.Visibility = Visibility.Collapsed;
            AISDataGrid.Visibility = Visibility.Visible;
            radarDataGrid.Visibility = Visibility.Collapsed;
            mixDataGrid.Visibility = Visibility.Collapsed;
        }
        private void radarTargetClick(object sender, RoutedEventArgs e)
        {
            allDataGrid.Visibility = Visibility.Collapsed;
            AISDataGrid.Visibility = Visibility.Collapsed;
            radarDataGrid.Visibility = Visibility.Visible;
            mixDataGrid.Visibility = Visibility.Collapsed;
        }
        private void mixTargetClick(object sender, RoutedEventArgs e)
        {
            allDataGrid.Visibility = Visibility.Collapsed;
            AISDataGrid.Visibility = Visibility.Collapsed;
            radarDataGrid.Visibility = Visibility.Collapsed;
            mixDataGrid.Visibility = Visibility.Visible;
        }
        private void DataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        /*控制操作海图面板（star）-------------------------------------------------------------------------*/
        public void mapMoveDown() 
        {
            yimaEncCtrl.MoveMap(MovingDirection.Down);
        }

        /*控制操作海图面板（end）--------------------------------------------------------------------------*/


        /*控制面板-----------------------------------------------------------------------------------------*/
        private void telephotoClick(object sender, RoutedEventArgs e)
        {
            changjiao.Visibility = Visibility.Visible;
            hongwai.Visibility = Visibility.Collapsed;
            sifu.Visibility = Visibility.Collapsed;
            xianwei.Visibility = Visibility.Collapsed;
            saomiao.Visibility = Visibility.Collapsed;
        }
        private void infraredRayClick(object sender, RoutedEventArgs e)
        {
            changjiao.Visibility = Visibility.Collapsed;
            hongwai.Visibility = Visibility.Visible;
            sifu.Visibility = Visibility.Collapsed;
            xianwei.Visibility = Visibility.Collapsed;
            saomiao.Visibility = Visibility.Collapsed;
        }
        private void SiFuClick(object sender, RoutedEventArgs e)
        {
            changjiao.Visibility = Visibility.Collapsed;
            hongwai.Visibility = Visibility.Collapsed;
            sifu.Visibility = Visibility.Visible;
            xianwei.Visibility = Visibility.Collapsed;
            saomiao.Visibility = Visibility.Collapsed;
        }
        private void limitSpaceClick(object sender, RoutedEventArgs e)
        {
            changjiao.Visibility = Visibility.Collapsed;
            hongwai.Visibility = Visibility.Collapsed;
            sifu.Visibility = Visibility.Collapsed;
            xianwei.Visibility = Visibility.Visible;
            saomiao.Visibility = Visibility.Collapsed;
        }
        private void scanClick(object sender, RoutedEventArgs e)
        {
            changjiao.Visibility = Visibility.Collapsed;
            hongwai.Visibility = Visibility.Collapsed;
            sifu.Visibility = Visibility.Collapsed;
            xianwei.Visibility = Visibility.Collapsed;
            saomiao.Visibility = Visibility.Visible;
        }
        public static int GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }
        static void ShowState(Photoelectricity.DRS d)//光电面板回调函数
        {
            //focalLength.Text = d.CCDFocalLengthValue.ToString();
            MonitoringObj.CCDFocalLengthValue.Text = d.CCDFocalLengthValue.ToString();//长焦焦距
            //视图回调，没有数据，算法未知
            MonitoringObj.InfraredFocalLength.Text = d.InfraredFocalLengthValue.ToString();//红外焦距
            //视图回调，没有数据，算法未知
        }
        /*控制面板-----------------------------------------------------------------------------------------*/
        /*长焦-----------------------------------------------------------------------------------------*/
        private void focusDownClick(object sender, RoutedEventArgs e)
        {
            if (focusDownClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensFocusingReduceStart(a);
                focusDownClickbool = true;
				focusButtonDecControl.Content = "停止减";
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensFocusingReduceEnd(a);
                focusDownClickbool = false;
				focusButtonDecControl.Content = "聚焦 -";
            }
        }
        private void focusUpClick(object sender, RoutedEventArgs e)
        {
            if (focusUpClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensFocusingIncreaseStart(a);
                focusUpClickbool = true;
                focusButtonAddControl.Content="停止加";
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensFocusingIncreaseEnd(a);
                focusUpClickbool = false;
                focusButtonAddControl.Content = "聚焦 +";
            }
        }
        private void focusDownMoreClick(object sender, RoutedEventArgs e)
        {
            if (focusDownMoreClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensRoomReduceStart(a);
                focusDownMoreClickbool = true;
                //focusDownMoreControl.Content="停止减";
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensRoomReduceEnd(a);
                focusDownMoreClickbool = false;
				//focusButtonAddControl.Content="变焦 -";
            }
        }
        private void focusUpMoreClick(object sender, RoutedEventArgs e)
        {
            if (focusUpMoreClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensRoomIncreaseStart(a);
                focusUpMoreClickbool = true;
				//focusDownMoreControl.Content="停止加";
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.ITelephotoCameraLensRoomIncreaseEnd(a);
                focusUpMoreClickbool = false;
				//focusDownMoreControl.Content="变焦 +";
            }
        }
        private void directionUpClick(object sender, RoutedEventArgs e)
        {
            directionVlu.Text = (++directionValue).ToString();
            int a = GetTimeStamp();
            Photoelectricity.ISetAzimuthDriveDriftCompensate(a,directionValue);
        }
        private void directionDownClick(object sender, RoutedEventArgs e)
        {
            directionVlu.Text = (--directionValue).ToString();
            int a = GetTimeStamp();
            Photoelectricity.ISetAzimuthDriveDriftCompensate(a, directionValue);
        }
        private void pitchUpClick(object sender, RoutedEventArgs e)
        {
            pitchVlu.Text = (++pitchValue).ToString();
            int a = GetTimeStamp();
            Photoelectricity.ISetPitchDriveDriftCompensate(a, pitchValue);
        }
        private void pitchDownClick(object sender, RoutedEventArgs e)
        {
            pitchVlu.Text = (--pitchValue).ToString();
            int a = GetTimeStamp();
            Photoelectricity.ISetPitchDriveDriftCompensate(a, pitchValue);
        }
        /*长焦-----------------------------------------------------------------------------------------*/
        /*红外-----------------------------------------------------------------------------------------*/
        private void optimalClick1_open(object sender, RoutedEventArgs e)
        {
            if (RadioB2_close.IsChecked == true)
            {
                RadioB1_open.IsChecked = true;
                RadioB2_close.IsChecked = false;
                infraredSwitch = 1;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredSwitch(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);

            }
        }
        private void optimalClick2_close(object sender, RoutedEventArgs e)
        {
            if (RadioB1_open.IsChecked == true)
            {
                RadioB2_close.IsChecked = true;
                RadioB1_open.IsChecked = false;
                infraredSwitch = 0;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredSwitch(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);
            }
        }
        private void optimalClick1(object sender, RoutedEventArgs e)
        {
            if (RadioB2.IsChecked == true)
            {
                RadioB1.IsChecked = true;
                RadioB2.IsChecked = false;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredCameraImagePolarity(a,1);
            }
        }
        private void optimalClick2(object sender, RoutedEventArgs e)
        {
            if (RadioB1.IsChecked == true)
            {
                RadioB2.IsChecked = true;
                RadioB1.IsChecked = false;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredCameraImagePolarity(a, 2);
            }
        }
        private void optimalClick3(object sender, RoutedEventArgs e)
        {
            if (RadioB4.IsChecked == true)
            {
                RadioB3.IsChecked = true;
                RadioB4.IsChecked = false;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredCameraImageCorrection(a,2);
            }
        }
        private void optimalClick4(object sender, RoutedEventArgs e)
        {
            if (RadioB3.IsChecked == true)
            {
                RadioB4.IsChecked = true;
                RadioB3.IsChecked = false;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredCameraImageCorrection(a, 1);
            }
        }
        private void optimalClick5(object sender, RoutedEventArgs e)
        {
            if (RadioB6.IsChecked == true)
            {
                RadioB5.IsChecked = true;
                RadioB6.IsChecked = false;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredCameraBadElementMaintenance(a, 1);
            }
        }
        private void optimalClick6(object sender, RoutedEventArgs e)
        {
            if (RadioB5.IsChecked == true)
            {
                RadioB6.IsChecked = true;
                RadioB5.IsChecked = false;
                int a = GetTimeStamp();
                Photoelectricity.ISetInfraredCameraBadElementMaintenance(a, 2);
            }
        }
        private void hfocusDownClick(object sender, RoutedEventArgs e)
        {
            if (hfocusDownClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensFocusingReduceStart(a);
                hfocusDownClickbool = true;
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensFocusingReduceEnd(a);
                hfocusDownClickbool = false;
            }
        }
        private void hfocusUpClick(object sender, RoutedEventArgs e)
        {
            if (hfocusUpClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensFocusingIncreaseStart(a);
                hfocusUpClickbool = true;
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensFocusingIncreaseEnd(a);
                hfocusUpClickbool = false;
            }
        }
        private void hfocusDownMoreClick(object sender, RoutedEventArgs e)
        {
            if (hfocusDownMoreClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensRoomReduceStart(a);
                hfocusDownMoreClickbool = true;
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensRoomReduceEnd(a);
                hfocusDownMoreClickbool = false;
            }
        }
        private void hfocusUpMoreClick(object sender, RoutedEventArgs e)
        {
            if (hfocusUpMoreClickbool == false)
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensRoomIncreaseStart(a);
                hfocusUpMoreClickbool = true;
            }
            else
            {
                int a = GetTimeStamp();
                Photoelectricity.IInfraredThermalImagerLensRoomIncreaseEnd(a);
                hfocusUpMoreClickbool = false;
            }
        }
        /*红外-----------------------------------------------------------------------------------------*/

        /*伺服-----------------------------------------------------------------------------------------*/
        private void sfoptimalClick1_open(object sender, RoutedEventArgs e)
        {
            if (RadioBu2_close.IsChecked == true)
            {
                RadioBu1_open.IsChecked = true;
                RadioBu2_close.IsChecked = false;
                driveSwitch = 1;
                int a = GetTimeStamp();
                Photoelectricity.ISetDriveSwitch(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);

            }
        }
        private void sfoptimalClick2_close(object sender, RoutedEventArgs e)
        {
            if (RadioBu1_open.IsChecked == true)
            {
                RadioBu2_close.IsChecked = true;
                RadioBu1_open.IsChecked = false;
                driveSwitch = 0;

                int a = GetTimeStamp();
                Photoelectricity.ISetDriveSwitch(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);
            }
        }
        private void sfoptimalClick1(object sender, RoutedEventArgs e)
        {
            if (RadioBu2.IsChecked == true)
            {
                RadioBu1.IsChecked = true;
                RadioBu2.IsChecked = false;
                trackingAlgorithm = 0;

                int a = GetTimeStamp();
                Photoelectricity.ISetTrackingAlgorithm(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);
            }
        }
        private void sfoptimalClick2(object sender, RoutedEventArgs e)
        {
            if (RadioBu1.IsChecked == true)
            {
                RadioBu2.IsChecked = true;
                RadioBu1.IsChecked = false;
                trackingAlgorithm = 1;
                int a = GetTimeStamp();
                Photoelectricity.ISetTrackingAlgorithm(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);
            }
        }
        private void sfoptimalClick3(object sender, RoutedEventArgs e)
        {
            if (RadioBu4.IsChecked == true)
            {
                RadioBu3.IsChecked = true;
                RadioBu4.IsChecked = false;
                RadioBu4_1.IsChecked = false;
                trackImage = 0;
                int a = GetTimeStamp();
                Photoelectricity.ISetTrackingImage(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);

            }
        }
        private void sfoptimalClick4(object sender, RoutedEventArgs e)
        {
            if (RadioBu3.IsChecked == true)
            {
                RadioBu4.IsChecked = true;
                RadioBu3.IsChecked = false;
                RadioBu4_1.IsChecked = false;
                trackImage = 1;
                int a = GetTimeStamp();
                Photoelectricity.ISetTrackingImage(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);
            }
        }
        private void sfoptimalClick4_1(object sender, RoutedEventArgs e)
        {
            if (RadioBu3.IsChecked == true)
            {
                RadioBu4_1.IsChecked = true;
                RadioBu3.IsChecked = false;
                RadioBu4.IsChecked = false;
                trackImage = 2;
                int a = GetTimeStamp();
                Photoelectricity.ISetTrackingImage(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);
            }
        }
        /*伺服-----------------------------------------------------------------------------------------*/
        /*限位-----------------------------------------------------------------------------------------*/
        private void horizontalLeftUpClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            ++horizontalLeft;
            Photoelectricity.ISetSoftwareOrientationLeftLimit(a, horizontalLeft);
            horizontalLeftText.Text = horizontalLeft.ToString();
        }
        private void horizontalLeftDownClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            --horizontalLeft;
            Photoelectricity.ISetSoftwareOrientationLeftLimit(a, horizontalLeft);
            horizontalLeftText.Text = horizontalLeft.ToString();
        }
        private void horizontalRightUpClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            ++horizontalRight;
            Photoelectricity.ISetSoftwareOrientationRightLimit(a, horizontalRight);
            horizontalRightText.Text = horizontalRight.ToString();
        }
        private void horizontalRightDownClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            --horizontalRight;
            Photoelectricity.ISetSoftwareOrientationRightLimit(a, horizontalRight);
            horizontalRightText.Text = horizontalRight.ToString();
        }
        private void pitchingUpUpClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            ++pitchingUp;
            Photoelectricity.ISetSoftwarePitchUpLimit(a, pitchingUp);
            pitchUpText.Text = pitchingUp.ToString();
        }
        private void pitchingUpDownClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            --pitchingUp;
            Photoelectricity.ISetSoftwarePitchUpLimit(a, pitchingUp);
            pitchUpText.Text = pitchingUp.ToString();
        }
        private void pitchingDownUpClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            ++pitchingDown;
            Photoelectricity.ISetSoftwarePitchDownLimit(a, pitchingDown);
            pitchDownText.Text = pitchingDown.ToString();
        }
        private void pitchingDownDownClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            --pitchingDown;
            Photoelectricity.ISetSoftwarePitchDownLimit(a, pitchingDown);
            pitchDownText.Text = pitchingDown.ToString();
        }
        /*限位-----------------------------------------------------------------------------------------*/
        /*扫描-----------------------------------------------------------------------------------------*/
        private void leftUpClick(object sender, RoutedEventArgs e)
        {
            leftLimitAngle++;
            leftLimitAngleText.Text = leftLimitAngle.ToString();

        }
        private void leftDownClick(object sender, RoutedEventArgs e)
        {
            leftLimitAngle--;
            leftLimitAngleText.Text = leftLimitAngle.ToString();
        }
        private void rightUpClick(object sender, RoutedEventArgs e)
        {
            rightLimitAngle++;
            rightLimitAngleText.Text = rightLimitAngle.ToString();
        }
        private void rightDownClick(object sender, RoutedEventArgs e)
        {
            rightLimitAngle--;
            rightLimitAngleText.Text = rightLimitAngle.ToString();
        }
        private void speedUpClick(object sender, RoutedEventArgs e)
        {
            sweepSpeed++;
            sweepSpeedText.Text = sweepSpeed.ToString();
        }
        private void speedDownClick(object sender, RoutedEventArgs e)
        {
            sweepSpeed--;
            sweepSpeedText.Text = sweepSpeed.ToString();
        }
        private void startClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            int leftLimitAngleTemp=(int)double.Parse(leftLimitAngleText.Text) / 90 * (1<<14);
            int rightLimitAngleTemp = (int)double.Parse(rightLimitAngleText.Text) / 90 * (1 << 14);
            int sweepSpeedTemp = (int)double.Parse(sweepSpeedText.Text) * 100;
            Photoelectricity.IFanSweepStart(a,leftLimitAngleTemp,rightLimitAngleTemp,sweepSpeedTemp,driveSwitch,infraredSwitch,trackingAlgorithm,trackImage);
        }
        private void cancelClick(object sender, RoutedEventArgs e)
        {
            int a = GetTimeStamp();
            Photoelectricity.IFanSweepEnd(a, driveSwitch, infraredSwitch, trackingAlgorithm, trackImage);
        }
        /*扫描-----------------------------------------------------------------------------------------*/
    }
}


/*本来这个就暂时没用

        private void ceshi2(object sender, RoutedEventArgs e)
        {
            if (AISbaojingxinhao == 1)
            {
                baojingAIS.Source = new BitmapImage(new Uri(@"image/AIShong1.png", UriKind.Relative));
                baojingAIS.ToolTip = "AIS连接异常";
            }
            if (leidabaojingxinhao1 == 1)
            {
                baojingleida1.Source = new BitmapImage(new Uri(@"image/leidahong1.png", UriKind.Relative));
                baojingleida1.ToolTip = "雷达1连接异常";
            }
            if (leidabaojingxinhao2 == 1)
            {
                baojingleida2.Source = new BitmapImage(new Uri(@"image/leidahong1.png", UriKind.Relative));
                baojingleida2.ToolTip = "雷达2连接异常";
            }
            if (ronghebaojingxinhao == 1)
            {
                baojingronghe.Source = new BitmapImage(new Uri(@"image/ronghehong.png", UriKind.Relative));
                baojingronghe.ToolTip = "融合连接正常";
            }
            if (AISbaojingxinhao == 0)
            {
                baojingAIS.Source = new BitmapImage(new Uri(@"image/AISlv1.png", UriKind.Relative));
                baojingAIS.ToolTip = "AIS连接正常";
            }
            if (leidabaojingxinhao1 == 0)
            {
                baojingleida1.Source = new BitmapImage(new Uri(@"image/leidalv1.png", UriKind.Relative));
                baojingleida1.ToolTip = "雷达1连接正常";
            }
            if (leidabaojingxinhao2 == 0)
            {
                baojingleida2.Source = new BitmapImage(new Uri(@"image/leidalv1.png", UriKind.Relative));
                baojingleida2.ToolTip = "雷达2连接正常";
            }
            if (ronghebaojingxinhao == 0)
            {
                baojingronghe.Source = new BitmapImage(new Uri(@"image/ronghelv.png", UriKind.Relative));
                baojingronghe.ToolTip = "融合连接正常";
            }
        }
 */
