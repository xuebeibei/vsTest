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
using HISGUIMedicineLib.ViewModels;
using System.Data;
using System.Windows.Threading;

namespace HISGUIMedicineLib.Views
{
    [Export]
    [Export("MedicineWorkView", typeof(MedicineWorkView))]
    public partial class MedicineWorkView : HISGUIViewBase
    {
        private DispatcherTimer ShowTimer;
        public MedicineWorkView()
        {
            InitializeComponent();

            // 在此点下面插入创建对象所需的代码。
            //show timer by_songgp
            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();


            CommClient.StoreRoom myd = new CommClient.StoreRoom();
            List<CommContracts.StoreRoom> storeRoomList = myd.GetAllStoreRoom();
            
            if(!(storeRoomList == null || storeRoomList.Count<=0))
            {
                this.StoreCombo.ItemsSource = storeRoomList;
                this.StoreCombo.SelectedItem = storeRoomList.ElementAt(0);
            }

            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
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

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if(this.MedicineRadio.IsChecked.Value)
                vm.IsMedicineOrMaterial = true;
            else if(this.MaterialRadio.IsChecked.Value)
                vm.IsMedicineOrMaterial = false;

            vm.CurrentStoreRoom = (CommContracts.StoreRoom)this.StoreCombo.SelectedItem;

            this.UserName.Content = vm.CurrentUser.Username;
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
        }

        private void MedicineRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm.IsMedicineOrMaterial = true;
            UpdateAllBills();
        }

        private void MaterialRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm.IsMedicineOrMaterial = false;
            UpdateAllBills();
        }

        private void UpdateAllBills()
        {
            if (this.tabControl.SelectedIndex == 0)
            {
                this.InStockView.UpdateInStores();
            }
            else if(this.tabControl.SelectedIndex == 1)
            {
                this.OutStockView.UpdateOutStores();
            }
            else if(this.tabControl.SelectedIndex == 2)
            {
                this.ItemsNumView.UpdateNumsStores();
            }
            else if(this.tabControl.SelectedIndex == 3)
            {
                this.CheckView.UpdateCheckStores();
            }
        }
    }
}
