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
            if (vm.CurrentUser != null)
            {
                this.UserName.Content = vm.CurrentUser.LoginName;
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
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            InitVisable();
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUISetVM;

            bool? bRe = vm.Logout(vm.CurrentUser);
            if (bRe.HasValue && bRe.Value)
            {
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
            }
        }

        private void AllSetTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem viewItem = this.AllSetTreeView.SelectedItem as TreeViewItem;
            if (viewItem == null)
                return;

            this.CenterPanel.Children.Clear();

            var vm = this.DataContext as HISGUISetVM;

            if (viewItem.Header.ToString() == "医院信息")
            {
                HospitalInfoSetView centerView = new HospitalInfoSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "科室")
            {
                DepartmentSetView centerView = new DepartmentSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "职位")
            {
                JobSetView centerView = new JobSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "库房")
            {
                StorehouseSetView centerView = new StorehouseSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "供应商")
            {
                SupplierSetView centerView = new SupplierSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "病房")
            {
                SickRoomSetView centerView = new SickRoomSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "病床")
            {
                SickBedSetView centerView = new SickBedSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "人员")
            {
                EmployeeSetView centerView = new EmployeeSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "值班时段")
            {
                ShiftSetView centerView = new ShiftSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "值班类别")
            {
                WorkTypeSetView centerView = new WorkTypeSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "药品")
            {
                MedicineSetView centerView = new MedicineSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "物资")
            {
                MaterialSetView centerView = new MaterialSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "治疗项目")
            {
                TherapyItemSetView centerView = new TherapyItemSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "检查项目")
            {
                InspectSetView centerView = new InspectSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "化验项目")
            {
                AssayItemSetView centerView = new AssayItemSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "其他服务")
            {
                OtherServiceItemSetView centerView = new OtherServiceItemSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "号源种类")
            {
                SignalTypeSetView centerView = new SignalTypeSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "出诊时段")
            {
                ClinicVistTimeView centerView = new ClinicVistTimeView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "放号渠道")
            {
                RegistrationDitchView centerView = new RegistrationDitchView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
            else if (viewItem.Header.ToString() == "患者")
            {
                PatientSetView centerView = new PatientSetView();
                centerView.DataContext = this.DataContext;

                this.CenterPanel.Children.Add(centerView);
            }
        }
    }
}
