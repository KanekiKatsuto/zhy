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
using Visifire.Charts;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DateStatistics.xaml 的交互逻辑
    /// </summary>
    public partial class DateStatistics : Page
    {
        public DateStatistics()
        {
            InitializeComponent();
            ButColumn1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, ButColumn1));
        }

        private void statisticsClick(object sender, RoutedEventArgs e)
        {
            if (chartType.Text == "柱状图")
            {
                ButColumn1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, ButColumn1));
            }
            if (chartType.Text == "饼状图")
            {
                ButPie1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, ButPie1));
            }
            if (chartType.Text == "折线图")
            {
                ButSpline1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, ButSpline1));
            }
        }

        private List<string> strListx1 = new List<string>() { "一月预警", "一月警戒", "一月驱逐", " ", "二月预警", "二月警戒", "二月驱逐", " ", "三月预警", "三月警戒", "三月驱逐", " ", "四月预警", "四月警戒", "四月驱逐", " ", "五月预警", "五月警戒", "五月驱逐", " ", "六月预警", "六月警戒", "六月驱逐", };
        private List<string> strListy1 = new List<string>() { "18", "12", "13", "0", "8", "7", "9", "0", "16", "15", "18", "0", "18", "12", "13", "0", "8", "7", "9", "0", "16", "15", "18" };

        private List<DateTime> LsTime1 = new List<DateTime>()
            { 
               new DateTime(2012,1,1),
               new DateTime(2012,2,1),
               new DateTime(2012,3,1),
               new DateTime(2012,4,1),
               new DateTime(2012,5,1),
               new DateTime(2012,6,1),
               new DateTime(2012,7,1),
               new DateTime(2012,8,1),
               new DateTime(2012,9,1),
               new DateTime(2012,10,1),
               new DateTime(2012,11,1),
               new DateTime(2012,12,1),
            };
        private List<string> cherry1 = new List<string>() { "18", "13", "13", "11", "8", "7", "9", "10", "16", "15", "18", "15" };
        private List<string> pineapple1 = new List<string>() { "11", "12", "12", "8", "6", "6", "7", "8", "9", "8", "13", "13" };
        private List<string> pineapple2 = new List<string>() { "8", "2", "3", "0", "4", "3", "5", "5", "6", "7", "4", "6" };
        private void ButColumn_Click1(object sender, RoutedEventArgs e)
        {
            Simon1.Children.Clear();
            CreateChartColumn1("报警区域统计", strListx1, strListy1);
        }

        private void ButPie_Click1(object sender, RoutedEventArgs e)
        {
            Simon1.Children.Clear();
            CreateChartPie1("报警区域统计", strListx1, strListy1);
        }
        private void ButSpline_Click1(object sender, RoutedEventArgs e)
        {
            Simon1.Children.Clear();
            CreateChartSpline1("报警区域统计", LsTime1, cherry1, pineapple1, pineapple2);
        }
        #region 柱状图
        public void CreateChartColumn1(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            //            chart.Width = 530;
            //            chart.Height = 300;
            chart.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = "次";
            chart.AxesY.Add(yAxis);

            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            // 设置数据线的格式
            dataSeries.RenderAs = RenderAs.StackedColumn;//柱状Stacked


            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.AxisXLabel = valuex[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(valuey[i]);
                //添加一个点击事件        
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon1.Children.Add(gr);
        }
        #endregion

        #region 饼状图
        public void CreateChartPie1(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            //            chart.Width = 530;
            //            chart.Height = 300;
            chart.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            //Axis yAxis = new Axis();
            ////设置图标中Y轴的最小值永远为0           
            //yAxis.AxisMinimum = 0;
            ////设置图表中Y轴的后缀          
            //yAxis.Suffix = "斤";
            //chart.AxesY.Add(yAxis);

            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            // 设置数据线的格式
            dataSeries.RenderAs = RenderAs.Pie;//柱状Stacked


            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.AxisXLabel = valuex[i];

                dataPoint.LegendText = "##" + valuex[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(valuey[i]);
                //添加一个点击事件        
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon1.Children.Add(gr);
        }
        #endregion

        #region 折线图
        public void CreateChartSpline1(string name, List<DateTime> lsTime, List<string> cherry, List<string> pineapple, List<string> tianjia)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            //            chart.Width = 530;
            //            chart.Height = 300;
            chart.Margin = new Thickness(10, 5, 10, 5);
            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            //初始化一个新的Axis
            Axis xaxis = new Axis();
            //设置Axis的属性
            //图表的X轴坐标按什么来分类，如时分秒
            xaxis.IntervalType = IntervalTypes.Months;
            //图表的X轴坐标间隔如2,3,20等，单位为xAxis.IntervalType设置的时分秒。
            xaxis.Interval = 1;
            //设置X轴的时间显示格式为7-10 11：20           
            xaxis.ValueFormatString = "MM月";
            //给图标添加Axis            
            chart.AxesX.Add(xaxis);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = "次";
            chart.AxesY.Add(yAxis);








            // 创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();
            // 设置数据线的格式。               
            dataSeries.LegendText = "预警区";

            dataSeries.RenderAs = RenderAs.Spline;//折线图

            dataSeries.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(cherry[i]);
                dataPoint.MarkerSize = 8;
                //dataPoint.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);









            // 创建一个新的数据线。               
            DataSeries dataSeriesPineapple = new DataSeries();
            // 设置数据线的格式。         

            dataSeriesPineapple.LegendText = "警戒区";

            dataSeriesPineapple.RenderAs = RenderAs.Spline;//折线图

            dataSeriesPineapple.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              
            DataPoint dataPoint2;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint2 = new DataPoint();
                // 设置X轴点                    
                dataPoint2.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint2.YValue = double.Parse(pineapple[i]);
                dataPoint2.MarkerSize = 8;
                //dataPoint2.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                dataPoint2.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeriesPineapple.DataPoints.Add(dataPoint2);
            }
            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeriesPineapple);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           







            // 创建一个新的数据线。               
            DataSeries dataSeriesPineapple1 = new DataSeries();
            // 设置数据线的格式。         

            dataSeriesPineapple1.LegendText = "驱逐区";

            dataSeriesPineapple1.RenderAs = RenderAs.Spline;//折线图

            dataSeriesPineapple1.XValueType = ChartValueTypes.DateTime;
            // 设置数据点              
            DataPoint dataPoint3;
            for (int i = 0; i < lsTime.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint3 = new DataPoint();
                // 设置X轴点                    
                dataPoint3.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint3.YValue = double.Parse(tianjia[i]);
                dataPoint3.MarkerSize = 8;
                //dataPoint2.Tag = tableName.Split('(')[0];
                //设置数据点颜色                  
                // dataPoint.Color = new SolidColorBrush(Colors.LightGray);                   
                dataPoint3.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown1);
                //添加数据点                   
                dataSeriesPineapple1.DataPoints.Add(dataPoint3);
            }
            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeriesPineapple1);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           



            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon1.Children.Add(gr);
        }
        #endregion

        #region 点击事件
        //点击事件
        void dataPoint_MouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            //DataPoint dp = sender as DataPoint;
            //MessageBox.Show(dp.YValue.ToString());
        }
        #endregion


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
