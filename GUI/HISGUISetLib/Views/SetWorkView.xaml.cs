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
using HISGUISetLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;
using System.Windows.Threading;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("SetWorkView", typeof(SetWorkView))]
    public partial class SetWorkView : HISGUIViewBase    
    {
        protected DispatcherTimer ShowTimer;
        public SetWorkView()
        {
            InitializeComponent();
            // 在此点下面插入创建对象所需的代码。
            //show timer by_songgp
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();

            this.Loaded += SetWorkView_Loaded;
        }

        private void SetWorkView_Loaded(object sender, RoutedEventArgs e)
        {
            //InitVisable();
            var vm = this.DataContext as HISGUISetVM;
            if(vm.CurrentUser != null)
            {
                this.UserName.Content = vm.CurrentUser.Username;
            }
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
        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void InitVisable()
        {
            HospitalSetView.Visibility = Visibility.Collapsed;
            DepartmentView.Visibility = Visibility.Collapsed;
            JobView.Visibility = Visibility.Collapsed;
            StorehourseView.Visibility = Visibility.Collapsed;
            SupplierView.Visibility = Visibility.Collapsed;
            SickRoomView.Visibility = Visibility.Collapsed;
            SickBedView.Visibility = Visibility.Collapsed;
            EmployeeView.Visibility = Visibility.Collapsed;
            UserView.Visibility = Visibility.Collapsed;
            MedicineView.Visibility = Visibility.Collapsed;
            MaterialView.Visibility = Visibility.Collapsed;
            InspectView.Visibility = Visibility.Collapsed;
            TherapyItemView.Visibility = Visibility.Collapsed;
            AssayItemView.Visibility = Visibility.Collapsed;
            OtherServiceItemView.Visibility = Visibility.Collapsed;
            SignalItemView.Visibility = Visibility.Collapsed;
            PatientView.Visibility = Visibility.Collapsed;
            TipLabel.Visibility = Visibility.Visible;
            MyClinicVistTimeView.Visibility = Visibility.Collapsed;
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void HospitalInfoSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            HospitalSetView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void DepartmentSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            DepartmentView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void JobSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            JobView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void StorehouseSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            StorehourseView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void SupplierSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            SupplierView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void SickRoomSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            SickRoomView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void EmployeeSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            EmployeeView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void UserSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            UserView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void OtherServiceSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            OtherServiceItemView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void AssayItemSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            AssayItemView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void InspectItemSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            InspectView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void MaterialItemSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            MaterialView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void MedicineItemSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            MedicineView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void SickBedSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            SickBedView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void TherapyItemSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            TherapyItemView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void SignalItemSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            SignalItemView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void PatientSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            PatientView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void ClinicVistTimeSet(object sender, RoutedEventArgs e)
        {
            InitVisable();
            MyClinicVistTimeView.Visibility = Visibility.Visible;
            TipLabel.Visibility = Visibility.Collapsed;
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;

            bool? bRe = vm.Logout(vm.CurrentUser);
            if(bRe.HasValue && bRe.Value)
            {
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
            }
        }

    }
}
