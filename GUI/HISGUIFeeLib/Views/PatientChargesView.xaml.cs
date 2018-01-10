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
using HISGUIFeeLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("PatientChargesView", typeof(PatientChargesView))]
    public partial class PatientChargesView : HISGUIViewBase
    {
        private MyTableEdit MyTableEdit;
        public PatientChargesView()
        {
            InitializeComponent();
            MyTableEdit = new MyTableEdit(MyTableEditEnum.chargeDetails);
            ChargeDetailsPanel.Children.Add(MyTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllXiCheng();
            GetAllZhong();
            GetAllZhiLiao();
            GetAllJianYan();
            GetAllJianCha();
            GetAllCaiLiao();
            GetAllQiTa();
        }

        private void GetAllXiCheng()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            List<CommContracts.Recipe> list = vm?.GetAllXiCheng();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    AllXiChengList.ItemsSource = vm?.GetAllXiCheng();
                    AllXiChengList.Visibility = Visibility.Visible;
                }
                else
                {
                    AllXiChengList.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void GetAllZhong()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            List<CommContracts.Recipe> list = vm?.GetAllZhong();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    AllZhongList.ItemsSource = vm?.GetAllZhong();
                    AllZhongList.Visibility = Visibility.Visible;
                }
                else
                {
                    AllZhongList.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void GetAllZhiLiao()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            List<CommContracts.Therapy> list = vm?.GetAllZhiLiao();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    AllZhiLiaoList.ItemsSource = vm?.GetAllZhiLiao();
                    AllZhiLiaoList.Visibility = Visibility.Visible;
                }
                else
                {
                    AllZhiLiaoList.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void GetAllJianYan()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            List<CommContracts.Assay> list = vm?.GetAllJianYan();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    AllJianYanList.ItemsSource = vm?.GetAllXiCheng();
                    AllJianYanList.Visibility = Visibility.Visible;
                }
                else
                {
                    AllJianYanList.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void GetAllJianCha()
        {   
            var vm = this.DataContext as HISGUIFeeVM;
            List<CommContracts.Inspect> list = vm?.GetAllJianCha();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    AllJianChaList.ItemsSource = vm?.GetAllJianCha();
                    AllJianChaList.Visibility = Visibility.Visible;
                }
                else
                {
                    AllJianChaList.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void GetAllCaiLiao()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            List<CommContracts.MaterialBill> list = vm?.GetAllCaiLiao();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    AllCaiLiaoList.ItemsSource = vm?.GetAllCaiLiao();
                    AllCaiLiaoList.Visibility = Visibility.Visible;
                }
                else
                {
                    AllCaiLiaoList.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void GetAllQiTa()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            List<CommContracts.OtherService> list = vm?.GetAllQiTa();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    AllQiTaList.ItemsSource = vm?.GetAllQiTa();
                    AllQiTaList.Visibility = Visibility.Visible;
                }
                else
                {
                    AllQiTaList.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            vm?.FeeWorkManage();
        }

        private void AllYiZhuList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
