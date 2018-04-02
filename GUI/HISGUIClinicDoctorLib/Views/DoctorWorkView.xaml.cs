using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
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
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using HISGUICore;
using HISGUICore.MyContorls;
using HISGUIDoctorLib.ViewModels;
using System.Data;
using System.Windows.Threading;

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("DoctorWorkView", typeof(DoctorWorkView))]
    public partial class DoctorWorkView : HISGUIViewBase
    {
        protected DispatcherTimer ShowTimer;
        public DoctorWorkView()
        {
            InitializeComponent();
            // 在此点下面插入创建对象所需的代码。
            //show timer by_songgp
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();

            this.Loaded += DoctorWork_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        //show timer by_songgp
        private void ShowCurTimer(object sender, EventArgs e)
        {
            //"星期"+DateTime.Now.DayOfWeek.ToString(("d"))

            //获得星期几
            this.Tt.Text = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
            this.Tt.Text += " ";
            //获得年月日
            this.Tt.Text += DateTime.Now.ToString("yyyy年MM月dd日");   //yyyy年MM月dd日
            this.Tt.Text += " ";
            //获得时分秒
            this.Tt.Text += DateTime.Now.ToString("HH:mm:ss");
            //System.Diagnostics.Debug.Print("this.ShowCurrentTime {0}", this.ShowCurrentTime);
        }

        private void DoctorWork_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.UserName.Content = vm.CurrentUser.Username;
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            bool? bRe = vm.Logout(vm.CurrentUser);
            if (bRe.HasValue && bRe.Value)
            {
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
            }
        }

        private void ClinicBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "门诊接诊";

            foreach (TabItem item in MyTabControl.Items)
            {
                if (item.Header.ToString() == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            ClinicRecivingView eidtInspect = new ClinicRecivingView();

            MyTabItemWithClose myTabItem = new MyTabItemWithClose();
            myTabItem.Header = header;
            myTabItem.ToolTip = header;
            myTabItem.Margin = new Thickness(0, 0, 1, 0);
            myTabItem.Height = 28;


            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void InHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "住院治疗";

            foreach (TabItem item in MyTabControl.Items)
            {
                if (item.Header.ToString() == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            InHospitalRecivingView eidtInspect = new InHospitalRecivingView();

            MyTabItemWithClose myTabItem = new MyTabItemWithClose();
            myTabItem.Header = header;
            myTabItem.ToolTip = header;
            myTabItem.Margin = new Thickness(0, 0, 1, 0);
            myTabItem.Height = 28;


            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void WorkBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "排班管理";

            foreach (TabItem item in MyTabControl.Items)
            {
                if (item.Header.ToString() == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            ClinicManagementView eidtInspect = new ClinicManagementView();

            MyTabItemWithClose myTabItem = new MyTabItemWithClose();
            myTabItem.Header = header;
            myTabItem.ToolTip = header;
            myTabItem.Margin = new Thickness(0, 0, 1, 0);
            myTabItem.Height = 28;


            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }
    }
}
