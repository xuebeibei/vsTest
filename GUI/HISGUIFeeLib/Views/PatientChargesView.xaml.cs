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
        private MyTableEditEnum editEnum;
        public PatientChargesView()
        {
            InitializeComponent();
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

        private void AllXiChengList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.AllXiChengList.SelectedItem = null;
            this.AllZhongList.SelectedItem = null;
            this.AllZhiLiaoList.SelectedItem = null;
            this.AllJianChaList.SelectedItem = null;
            this.AllQiTaList.SelectedItem = null;
            this.AllJianYanList.SelectedItem = null;
            this.AllCaiLiaoList.SelectedItem = null;

            editEnum = MyTableEditEnum.xichengyao;
        }

        private void AllZhongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AllXiChengList.SelectedItem = null;
            //this.AllZhongList.SelectedItem = null;
            this.AllZhiLiaoList.SelectedItem = null;
            this.AllJianChaList.SelectedItem = null;
            this.AllQiTaList.SelectedItem = null;
            this.AllJianYanList.SelectedItem = null;
            this.AllCaiLiaoList.SelectedItem = null;

            editEnum = MyTableEditEnum.zhongyao;
        }

        private void AllZhiLiaoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AllXiChengList.SelectedItem = null;
            this.AllZhongList.SelectedItem = null;
            //this.AllZhiLiaoList.SelectedItem = null;
            this.AllJianChaList.SelectedItem = null;
            this.AllQiTaList.SelectedItem = null;
            this.AllJianYanList.SelectedItem = null;
            this.AllCaiLiaoList.SelectedItem = null;

            editEnum = MyTableEditEnum.zhiliao;
        }

        private void AllJianChaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AllXiChengList.SelectedItem = null;
            this.AllZhongList.SelectedItem = null;
            this.AllZhiLiaoList.SelectedItem = null;
            //this.AllJianChaList.SelectedItem = null;
            this.AllQiTaList.SelectedItem = null;
            this.AllJianYanList.SelectedItem = null;
            this.AllCaiLiaoList.SelectedItem = null;

            editEnum = MyTableEditEnum.jiancha;
        }

        private void AllQiTaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AllXiChengList.SelectedItem = null;
            this.AllZhongList.SelectedItem = null;
            this.AllZhiLiaoList.SelectedItem = null;
            this.AllJianChaList.SelectedItem = null;
            //this.AllQiTaList.SelectedItem = null;
            this.AllJianYanList.SelectedItem = null;
            this.AllCaiLiaoList.SelectedItem = null;

            editEnum = MyTableEditEnum.qita;
        }

        private void AllJianYanList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AllXiChengList.SelectedItem = null;
            this.AllZhongList.SelectedItem = null;
            this.AllZhiLiaoList.SelectedItem = null;
            this.AllJianChaList.SelectedItem = null;
            this.AllQiTaList.SelectedItem = null;
            //this.AllJianYanList.SelectedItem = null;
            this.AllCaiLiaoList.SelectedItem = null;

            editEnum = MyTableEditEnum.jianyan;
        }

        private void AllCaiLiaoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AllXiChengList.SelectedItem = null;
            this.AllZhongList.SelectedItem = null;
            this.AllZhiLiaoList.SelectedItem = null;
            this.AllJianChaList.SelectedItem = null;
            this.AllQiTaList.SelectedItem = null;
            this.AllJianYanList.SelectedItem = null;
            //this.AllCaiLiaoList.SelectedItem = null;

            editEnum = MyTableEditEnum.cailiao;
        }

        private void AllXiChengList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllXiChengList.SelectedItem as CommContracts.Recipe;

            var window = new Window();
            PatientChargeDetailsView list = new PatientChargeDetailsView(MyTableEditEnum.xichengyao);
            window.Content = list;
            window.Width = 860;
            list.CurrentRecipe = temp;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                GetAllXiCheng();
            }
        }

        private void AllZhongList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllZhongList.SelectedItem as CommContracts.Recipe;
        }

        private void AllZhiLiaoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllZhiLiaoList.SelectedItem as CommContracts.Therapy;
        }

        private void AllJianChaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllJianChaList.SelectedItem as CommContracts.Inspect;
        }

        private void AllJianYanList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllJianYanList.SelectedItem as CommContracts.Assay;
        }

        private void AllCaiLiaoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllCaiLiaoList.SelectedItem as CommContracts.MaterialBill;
        }

        private void AllQiTaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var temp = this.AllQiTaList.SelectedItem as CommContracts.OtherService;
        }
    }
}
