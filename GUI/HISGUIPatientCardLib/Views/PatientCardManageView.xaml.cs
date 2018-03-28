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

namespace HISGUIPatientCardLib.Views
{
    [Export]
    [Export("PatientCardManageView", typeof(PatientCardManageView))]
    public partial class PatientCardManageView : HISGUIViewBase
    {
        public PatientCardManageView()
        {
            InitializeComponent();
        }

        [Import]
        private HISGUIPatientCardVM ImportVM
        {
            set { this.VM = value; }
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
            string header = "办理就诊卡";

            foreach (TabItem item in MyTabControl.Items)
            {
                if (item.Header.ToString() == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            PatientCardMsgView eidtInspect = new PatientCardMsgView();

            MyTabItemWithClose myTabItem = new MyTabItemWithClose();
            myTabItem.Header = header;
            myTabItem.ToolTip = header;
            myTabItem.Margin = new Thickness(0, 0, 1, 0);
            myTabItem.Height = 28;
            
            
            myTabItem.Content = eidtInspect;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void AddFeeBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIPatientCardVM;
            // 就诊卡充值
            var window = new Window();
            window.DataContext = this.DataContext;
            window.Width = 600;
            window.Height = 400;
            window.Title = "办理就诊卡";


            PatientCardAddFeeView eidtInspect = new PatientCardAddFeeView();
            window.Content = eidtInspect;

            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("办理就诊卡新建完成！");
            }
        }

        private void ReturnCardBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LostAndReDoCardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemStatistic_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
