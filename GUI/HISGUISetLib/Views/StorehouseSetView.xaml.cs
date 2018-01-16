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
using Microsoft.Win32;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("StorehouseSetView", typeof(StorehouseSetView))]
    public partial class StorehouseSetView : HISGUIViewBase
    {
        public StorehouseSetView()
        {
            InitializeComponent();
            this.Loaded += StorehouseSetView_Loaded;
        }

        private void StorehouseSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增库房
            var window = new Window();

            EditStorehouseView eidtStorehouse = new EditStorehouseView();
            window.Content = eidtStorehouse;
            window.Width = 400;
            window.Height = 500;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("库房新建完成！");
                UpdateAllDate();
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentDapertment = this.AllStorehouseList.SelectedItem as CommContracts.StoreRoom;
            if (currentDapertment == null)
                return;

            if (MessageBox.Show("确认删除该库房？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteStoreRoom(currentDapertment.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("库房删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllStorehouseList.SelectedItem as CommContracts.StoreRoom;
            if (temp == null)
                return;

            // 新增库房
            var window = new Window();

            EditStorehouseView eidtStorehouse = new EditStorehouseView(temp);
            window.Content = eidtStorehouse;
            window.Width = 400;
            window.Height = 500;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("库房修改完成！");
                UpdateAllDate();
            }
        }

        private void ExportItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateAllDate(string strName = "")
        {
            var vm = this.DataContext as HISGUISetVM;
            this.AllStorehouseList.ItemsSource = vm?.GetAllStoreRoom(strName);
        }
    }
}
