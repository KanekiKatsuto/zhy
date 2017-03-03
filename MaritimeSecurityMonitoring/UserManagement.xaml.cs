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

namespace MaritimeSecurityMonitoring
{
    /// <summary>
    /// UserManagement.xaml 的交互逻辑
    /// </summary>
    public partial class UserManagement : Page
    {
        List<userManagementInformation> items = new List<userManagementInformation>();
        public UserManagement()
        {
            InitializeComponent();

            items.Add(new userManagementInformation() { userNumber = "1", userName = "admin", organizationName = "开发生产部", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "893168726@qq.com", mobilePhongNumber = "13426016862", machineNumber = "1236896" });
            items.Add(new userManagementInformation() { userNumber = "2", userName = "段成功", organizationName = "伊拉克公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "986312475@qq.com", mobilePhongNumber = "12325695233", machineNumber = "2354963" });
            items.Add(new userManagementInformation() { userNumber = "3", userName = "张伟明", organizationName = "刚果公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "968313468@qq.com", mobilePhongNumber = "79923012548", machineNumber = "8523642" });
            items.Add(new userManagementInformation() { userNumber = "4", userName = "宫少波", organizationName = "西北大陆架公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "179853249@qq.com", mobilePhongNumber = "96312547852", machineNumber = "9853216" });
            items.Add(new userManagementInformation() { userNumber = "5", userName = "吕永峰", organizationName = "中东公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "968321567@qq.com", mobilePhongNumber = "23659852314", machineNumber = "7423652" });
            items.Add(new userManagementInformation() { userNumber = "6", userName = "陈润华", organizationName = "泛美能源公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "973512306@qq.com", mobilePhongNumber = "12369523651", machineNumber = "1024596" });
            items.Add(new userManagementInformation() { userNumber = "7", userName = "刘永杰", organizationName = "中外合作有限公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "950312659@qq.com", mobilePhongNumber = "4789536542", machineNumber = "2489637" });
            items.Add(new userManagementInformation() { userNumber = "8", userName = "张一键", organizationName = "中石化公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "98769868@qq.com", mobilePhongNumber = "20136952364", machineNumber = "4562357" });
            items.Add(new userManagementInformation() { userNumber = "9", userName = "王建国", organizationName = "能源启明公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "98769353@qq.com", mobilePhongNumber = "47895236542", machineNumber = "7563295" });
            items.Add(new userManagementInformation() { userNumber = "10", userName = "李刚", organizationName = "ABSFBSD公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "10236589@qq.com", mobilePhongNumber = "2365147826", machineNumber = "4136208" });
            items.Add(new userManagementInformation() { userNumber = "11", userName = "邱于彤", organizationName = "SVSFVS公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "963951753@qq.com", mobilePhongNumber = "2036514783", machineNumber = "7562014" });
            items.Add(new userManagementInformation() { userNumber = "12", userName = "李玉明", organizationName = "SDCSDSDC公司", jobTitle = "", emergencyDepartment = "", emergencyJobTitle = "", email = "963842663@qq.com", mobilePhongNumber = "12345795632", machineNumber = "3695248" });
            informationList.ItemsSource = items;
        }
        private void addingRoleClick(object sender, RoutedEventArgs e)
        {
            informationList.ItemsSource = "";
            items.Add(new userManagementInformation() { userNumber = userNumberText.Text, userName = userNameText.Text, organizationName = organizationNameText.Text, jobTitle = jobTitleText.Text, emergencyDepartment = emergencyDepartmentText.Text, emergencyJobTitle = emergencyJobTitleText.Text, email = emailText.Text, mobilePhongNumber = mobilePhongNumberText.Text, machineNumber = machineNumberText.Text });
            informationList.ItemsSource = items;
        }
        private void deleteRoleClick(object sender, RoutedEventArgs e)
        {
            //lvUsers.ItemsSource = items1;
        }
    }
    public class userManagementInformation
    {
        public string userNumber { get; set; }
        public string userName { get; set; }
        public string organizationName { get; set; }
        public string jobTitle { get; set; }
        public string emergencyDepartment { get; set; }
        public string emergencyJobTitle { get; set; }
        public string email { get; set; }
        public string mobilePhongNumber { get; set; }
        public string machineNumber { get; set; }
    }
}
