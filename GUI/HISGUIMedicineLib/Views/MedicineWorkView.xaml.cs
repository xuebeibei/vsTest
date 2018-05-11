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
using HISGUICore.MyContorls;

namespace HISGUIMedicineLib.Views
{
    [Export]
    [Export("MedicineWorkView", typeof(MedicineWorkView))]
    public partial class MedicineWorkView : HISGUIViewBase
    {
        protected DispatcherTimer ShowTimer;
        private InStockView m_instoreView;
        private OutStockView m_outStockView;
        private ItemsNumView m_itemsNumView;
        private CheckView m_checkView;
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

            if (!(storeRoomList == null || storeRoomList.Count <= 0))
            {
                this.StoreCombo.ItemsSource = storeRoomList;
                this.StoreCombo.SelectedItem = storeRoomList.ElementAt(0);
            }

            m_instoreView = new InStockView();
            m_outStockView = new OutStockView();
            m_itemsNumView = new ItemsNumView();
            m_checkView = new CheckView();
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
            if (this.MedicineRadio.IsChecked.Value)
                vm.IsMedicineOrMaterial = true;
            else if (this.MaterialRadio.IsChecked.Value)
                vm.IsMedicineOrMaterial = false;

            vm.CurrentStoreRoom = (CommContracts.StoreRoom)this.StoreCombo.SelectedItem;

            this.UserName.Content = vm.CurrentUser.LoginName;
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            bool? bRe = vm.Logout(vm.CurrentUser);
            if (bRe.HasValue && bRe.Value)
            {
                vm?.RegionManager.RequestNavigate("DownRegion", "HISGUILoginView");
            }
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
            if (this.MyTabControl.SelectedIndex == 0)
            {
                m_instoreView.UpdateInStores();
            }
            else if (this.MyTabControl.SelectedIndex == 1)
            {
                m_outStockView.UpdateOutStores();
            }
            else if (this.MyTabControl.SelectedIndex == 2)
            {
                m_itemsNumView.UpdateNumsStores();
            }
            else if (this.MyTabControl.SelectedIndex == 3)
            {
                m_checkView.UpdateCheckStores();
            }
        }

        private void InStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "入库管理";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = m_instoreView;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void OutStoreBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "出库管理";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = m_outStockView;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void StoreNumBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "当前库存";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }
            

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = m_itemsNumView;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void CheckStoreNumBtn_Click(object sender, RoutedEventArgs e)
        {
            string header = "库存盘点";

            foreach (TabItem item in MyTabControl.Items)
            {
                CloseableTabItemHeader itemHeader = item.Header as CloseableTabItemHeader;

                if (itemHeader.Title == header)
                {
                    MyTabControl.SelectedItem = item;
                    return;
                }
            }

            CloseableTabItem myTabItem = new CloseableTabItem(header);

            myTabItem.Content = m_checkView;
            MyTabControl.Items.Add(myTabItem);
            MyTabControl.SelectedItem = myTabItem;
        }

        private void StoreCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.StoreRoom currentStoreRoom = this.StoreCombo.SelectedItem as CommContracts.StoreRoom;

            if (currentStoreRoom == null)
                return;

            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm == null)
                return;
            vm.CurrentStoreRoom = currentStoreRoom;
            UpdateAllBills();
        }
    }
}
