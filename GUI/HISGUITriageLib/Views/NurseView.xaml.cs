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
            vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
        }
    }
}
