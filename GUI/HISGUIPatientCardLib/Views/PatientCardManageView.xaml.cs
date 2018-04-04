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
using HISGUIPatientCardLib.ViewModels;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;

namespace HISGUIPatientCardLib.Views
{
    [Export]
    [Export("PatientCardManageView", typeof(PatientCardManageView))]
    public partial class PatientCardManageView : HISGUIViewBase
    {
        protected DispatcherTimer ShowTimer;
        public PatientCardManageView()
        {
            InitializeComponent();

            //show timer by_songgp
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
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
            var vm = this.DataContext as HISGUIPatientCardVM;
            bool? bRe = vm.Logout(vm.CurrentUser);
            if (bRe.HasValue && bRe.Value)
            {
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
            }
        }

        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            string header = "就诊卡";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            PatientCardNewCardView eidtInspect = new PatientCardNewCardView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);
            
            
            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void AddFeeBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "预交金";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            PatientCardAddFeeView eidtInspect = new PatientCardAddFeeView();
            eidtInspect.DataContext = this.DataContext;

            CloseableTabItem myTabItem = new CloseableTabItem(header);
            myTabItem.DataContext = this.DataContext;


            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void ReturnCardBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LostAndReDoCardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemStatistic_Click(object sender, RoutedEventArgs e)
        {
            string header = "统计";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            StatisticsView eidtInspect = new StatisticsView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);
            myTabItem.Height = 28;


            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }
    }
}
