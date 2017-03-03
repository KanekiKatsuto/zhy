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
using System.Collections.ObjectModel;

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// DataQuery.xaml 的交互逻辑
    /// </summary>
    public partial class DataQuery : Page
    {
        CollectionViewSource workLogView = new CollectionViewSource();
        ObservableCollection<Log> workLogCollection = new ObservableCollection<Log>();
        CollectionViewSource operationLogView = new CollectionViewSource();
        ObservableCollection<OperateLog> operationLogCollection = new ObservableCollection<OperateLog>();
        CollectionViewSource userLoginView = new CollectionViewSource();
        ObservableCollection<LoginRecord> userLoginCollection = new ObservableCollection<LoginRecord>();

        int currentPageIndex1 = 0;
        int itemPerPage1 = 30;
        int totalPage1 = 0;
        int currentPageIndex2 = 0;
        int itemPerPage2 = 30;
        int totalPage2 = 0;
        int currentPageIndex3 = 0;
        int itemPerPage3 = 30;
        int totalPage3 = 0;

        private string[] ongitudes = { "东经117°38'", "西经17°38'", "东经101°38'", "西经92°18'" };
        private string[] latitudes = { "北纬75°8'", "南纬35°8'", "北纬79°8'", "南纬45°8'" };
        private string[] MMSI = { "CA96363TS", "DB97963TS ", "BA95563TS", "CG1263TS" };
        private string[] navigation = { "动力航行中", "停止航行", "紧急制动", "动力航行中" };
        private string[] toRateDegree = { "+0度", "+9度", "+13度", "+5度" };
        private string[] speeds = { "0.00节", "3.80节", "2.00节", "0.30节" };
        private string[] operations = { "用户登录。", "用户设置防护圈参数。", "用户查看海图。", "用户导出日志信息。", "用户追踪抓取目标图片。", "用户回顾2016-06-20到2016-07-06期间AIS态势数据。", "用户查看用户管理-角色权限管理菜单。" };
        private string[] userLogins = { "用户A登录。", "用户B登录。", "用户A离线。", "用户C登录。", "用户C登录。", "用户C离线。" };
        public DataQuery()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount1 = 200;
            workLogList.Visibility = Visibility.Visible;


            for (int j = 1; j < itemcount1; j++)
            {
                workLogCollection.Add(new Log()
                {
                    time = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                    longitude = ongitudes[j % 4],
                    latitude = latitudes[j % 4],
                    MMSI = MMSI[j % 4],
                    navigationalStatus = navigation[j % 4],
                    toRate = toRateDegree[j % 4],
                    speed = speeds[j % 4]
                });
            }

            // Calculate the total pages
            totalPage1 = itemcount1 / itemPerPage1;
            if (itemcount1 % itemPerPage1 != 0)
            {
                totalPage1 += 1;
            }

            workLogView.Source = workLogCollection;

            workLogView.Filter += new FilterEventHandler(workLogViewFilter);

            workLogList.DataContext = workLogView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage1.ToString();


            for (int j = 1; j < itemcount1; j++)
            {
                operationLogCollection.Add(new OperateLog()
                {
                    time = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                    operation = operations[j % 7],
                });
            }

            // Calculate the total pages
            totalPage2 = itemcount1 / itemPerPage2;
            if (itemcount1 % itemPerPage2 != 0)
            {
                totalPage2 += 1;
            }

            operationLogView.Source = operationLogCollection;

            operationLogView.Filter += new FilterEventHandler(operationLogViewFilter);

            this.operationLogList.DataContext = operationLogView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage2.ToString();



            for (int j = 1; j < itemcount1; j++)
            {
                userLoginCollection.Add(new LoginRecord()
                {
                    time = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                    userLogin = userLogins[j % 6],
                });
            }

            // Calculate the total pages
            totalPage3 = itemcount1 / itemPerPage3;
            if (itemcount1 % itemPerPage3 != 0)
            {
                totalPage3 += 1;
            }

            userLoginView.Source = userLoginCollection;

            userLoginView.Filter += new FilterEventHandler(userLoginViewFilter);

            this.userLoginList.DataContext = userLoginView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage3.ToString();

        }
        private void workLogClick(object sender, RoutedEventArgs e)
        {
            operationLogList.Visibility = Visibility.Collapsed;
            userLoginList.Visibility = Visibility.Collapsed;
            workLogList.Visibility = Visibility.Visible;
            this.workLogList.DataContext = workLogView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage1.ToString();
        }
        private void operationLogClick(object sender, RoutedEventArgs e)
        {

            operationLogList.Visibility = Visibility.Visible;
            userLoginList.Visibility = Visibility.Collapsed;
            workLogList.Visibility = Visibility.Collapsed;
            this.operationLogList.DataContext = operationLogView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage2.ToString();
        }
        private void userLoginClick(object sender, RoutedEventArgs e)
        {
            operationLogList.Visibility = Visibility.Collapsed;
            userLoginList.Visibility = Visibility.Visible;
            workLogList.Visibility = Visibility.Collapsed;

            this.userLoginList.DataContext = userLoginView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage3.ToString();
        }

        private void ShowCurrentPageIndex()
        {
            if (workLogList.Visibility == Visibility.Visible)
            {
                currentPage.Text = (currentPageIndex1 + 1).ToString();
            }
            if (operationLogList.Visibility == Visibility.Visible)
            {
                currentPage.Text = (currentPageIndex2 + 1).ToString();
            }
            if (userLoginList.Visibility == Visibility.Visible)
            {
                currentPage.Text = (currentPageIndex3 + 1).ToString();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int itemcount1 = 200;
            workLogList.Visibility = Visibility.Visible;


            for (int j = 1; j < itemcount1; j++)
            {
                workLogCollection.Add(new Log()
                {
                    time = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                    longitude = ongitudes[j % 4],
                    latitude = latitudes[j % 4],
                    MMSI = MMSI[j % 4],
                    navigationalStatus = navigation[j % 4],
                    toRate = toRateDegree[j % 4],
                    speed = speeds[j % 4]
                });
            }

            // Calculate the total pages
            totalPage1 = itemcount1 / itemPerPage1;
            if (itemcount1 % itemPerPage1 != 0)
            {
                totalPage1 += 1;
            }

            workLogView.Source = workLogCollection;

            workLogView.Filter += new FilterEventHandler(workLogViewFilter);

            this.workLogList.DataContext = workLogView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage1.ToString();


            for (int j = 1; j < itemcount1; j++)
            {
                operationLogCollection.Add(new OperateLog()
                {
                    time = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                    operation = operations[j % 7],
                });
            }
            // Calculate the total pages
            totalPage2 = itemcount1 / itemPerPage2;
            if (itemcount1 % itemPerPage2 != 0)
            {
                totalPage2 += 1;
            }
            operationLogView.Source = operationLogCollection;
            operationLogView.Filter += new FilterEventHandler(operationLogViewFilter);
            this.operationLogList.DataContext = operationLogView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage2.ToString();
            for (int j = 1; j < itemcount1; j++)
            {
                userLoginCollection.Add(new LoginRecord()
                {
                    time = System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"),
                    userLogin = userLogins[j % 6],
                });
            }
            // Calculate the total pages
            totalPage3 = itemcount1 / itemPerPage3;
            if (itemcount1 % itemPerPage3 != 0)
            {
                totalPage3 += 1;
            }

            userLoginView.Source = userLoginCollection;

            userLoginView.Filter += new FilterEventHandler(userLoginViewFilter);

            this.userLoginList.DataContext = userLoginView;
            ShowCurrentPageIndex();
            totalPages.Text = totalPage3.ToString();
        }
        void workLogViewFilter(object sender, FilterEventArgs e)
        {
            int index = workLogCollection.IndexOf((Log)e.Item);

            if (index >= itemPerPage1 * currentPageIndex1 && index < itemPerPage1 * (currentPageIndex1 + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        void operationLogViewFilter(object sender, FilterEventArgs e)
        {
            int index = operationLogCollection.IndexOf((OperateLog)e.Item);

            if (index >= itemPerPage2 * currentPageIndex2 && index < itemPerPage2 * (currentPageIndex2 + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        void userLoginViewFilter(object sender, FilterEventArgs e)
        {
            int index = userLoginCollection.IndexOf((LoginRecord)e.Item);

            if (index >= itemPerPage3 * currentPageIndex3 && index < itemPerPage3 * (currentPageIndex3 + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        private void btnPrevClick(object sender, RoutedEventArgs e)
        {
            // Display previous page
            if (workLogList.Visibility == Visibility.Visible)
            {
                if (currentPageIndex1 > 0)
                {
                    currentPageIndex1--;
                    workLogView.View.Refresh();
                }
            }
            if (operationLogList.Visibility == Visibility.Visible)
            {
                if (currentPageIndex2 > 0)
                {
                    currentPageIndex2--;
                    operationLogView.View.Refresh();
                }
            }
            if (userLoginList.Visibility == Visibility.Visible)
            {
                if (currentPageIndex3 > 0)
                {
                    currentPageIndex3--;
                    userLoginView.View.Refresh();
                }
            }
            ShowCurrentPageIndex();
        }
        private void btnNextClick(object sender, RoutedEventArgs e)
        {
            // Display next page
            if (workLogList.Visibility == Visibility.Visible)
            {
                if (currentPageIndex1 < totalPage1 - 1)
                {
                    currentPageIndex1++;
                    workLogView.View.Refresh();
                }
            }
            if (operationLogList.Visibility == Visibility.Visible)
            {
                if (currentPageIndex2 < totalPage2 - 1)
                {
                    currentPageIndex2++;
                    operationLogView.View.Refresh();
                }
            }
            if (userLoginList.Visibility == Visibility.Visible)
            {
                if (currentPageIndex3 < totalPage3 - 1)
                {
                    currentPageIndex3++;
                    userLoginView.View.Refresh();
                }
            }
            ShowCurrentPageIndex();
        }
        private void listView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
