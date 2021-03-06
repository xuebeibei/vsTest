﻿using System;
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
using HISGUIFeeLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;
using System.Windows.Threading;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("FeeWorkView", typeof(FeeWorkView))]
    public partial class FeeWorkView : HISGUIViewBase
    {
        protected DispatcherTimer ShowTimer;
        public FeeWorkView()
        {
            InitializeComponent();

            

            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }
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
        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            UserName.Content = vm.CurrentUser.LoginName;
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            bool? bRe = vm.Logout(vm.CurrentUser);
            if (bRe.HasValue && bRe.Value)
            {
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "挂号";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            RegistrationView eidtInspect = new RegistrationView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void ChargeBtn_Click(object sender, RoutedEventArgs e)
        {

            string header = "收费";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            ChargeView eidtInspect = new ChargeView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void InAndLeaveHospitalBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "出入院";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            InAndLeaveHospitalView eidtInspect = new InAndLeaveHospitalView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void PrePaidBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "缴退费";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            PrePaidView eidtInspect = new PrePaidView();

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }
    }
}
