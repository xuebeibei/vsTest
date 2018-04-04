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
    [Export("SignalItemSetView", typeof(SignalItemSetView))]
    public partial class SignalItemSetView : HISGUIViewBase
    {
        public SignalItemSetView()
        {
            InitializeComponent();
            this.Loaded += SignalItemSetView_Loaded;
        }

        private void SignalItemSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增号源种类
            var window = new Window();

            EditSignalItemView eidtSignalItem = new EditSignalItemView();
            window.Content = eidtSignalItem;
            window.Width = 400;
            window.Height = 500;
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("号源种类新建完成！");
                UpdateAllDate();
            }
        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = "";
            UpdateAllDate(strName);
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentDapertment = this.AllSignalItemList.SelectedItem as CommContracts.SignalItem;
            if (currentDapertment == null)
                return;

            if (MessageBox.Show("确认删除该号源种类？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteSignalItem(currentDapertment.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("号源种类删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllSignalItemList.SelectedItem as CommContracts.SignalItem;
            if (temp == null)
                return;

            // 新增号源种类
            var window = new Window();

            EditSignalItemView eidtSignalItem = new EditSignalItemView(temp);
            window.Content = eidtSignalItem;
            window.Width = 400;
            window.Height = 500;
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("号源种类修改完成！");
                UpdateAllDate();
            }
        }

        private void ExportItemBtn_Click(object sender, RoutedEventArgs e)
        {
            //ExportToExecl();
        }

        private void ImportItemBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllSignalItemList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpdateAllDate(string strName = "")
        {
            var vm = this.DataContext as HISGUISetVM;
            this.AllSignalItemList.ItemsSource = vm?.GetAllSignalItem(strName);
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AllSignalItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
