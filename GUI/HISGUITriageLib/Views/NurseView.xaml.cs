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
using HISGUINurseLib.ViewModels;
using System.Data;
using System.Windows.Threading;

namespace HISGUINurseLib.Views
{
    [Export]
    [Export("NurseWorkView", typeof(NurseWorkView))]
    public partial class NurseWorkView : HISGUIViewBase
    {
        protected DispatcherTimer ShowTimer;
        public NurseWorkView()
        {
            InitializeComponent();
            // 在此点下面插入创建对象所需的代码。
            //show timer by_songgp
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
            this.Loaded += NurseWorkView_Loaded;
        }

        private void NurseWorkView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUINurseVM;
            this.UserName.Content = vm.CurrentUser.Username;
        }

        [Import]
        private HISGUINurseVM ImportVM
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

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUINurseVM;
            bool? bRe = vm.Logout(vm.CurrentUser);
            if (bRe.HasValue && bRe.Value)
            {
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
            }
        }

        private void TriagePatientsBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "门诊分诊";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            TriagePatientsView eidtInspect = new TriagePatientsView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void InjectionBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "注射输液";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            InjectionView eidtInspect = new InjectionView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }
    }
}
