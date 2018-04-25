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
    [Export("TherapyItemSetView", typeof(TherapyItemSetView))]
    public partial class TherapyItemSetView : HISGUIViewBase
    {
        public TherapyItemSetView()
        {
            InitializeComponent();
            this.Loaded += TherapyItemSetView_Loaded;
        }

        private void TherapyItemSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllTherapyItemList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增治疗项目
            var window = new Window();

            EditTherapyItemView eidtTherapyItem = new EditTherapyItemView();
            window.Content = eidtTherapyItem;
            window.Width = 400;
            window.Height = 500;
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("治疗项目新建完成！");
                UpdateAllDate();
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentTherapyItem = this.AllTherapyItemList.SelectedItem as CommContracts.TherapyItem;
            if (currentTherapyItem == null)
                return;

            if (MessageBox.Show("确认删除该治疗项目？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteTherapyItem(currentTherapyItem.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("治疗项目删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllTherapyItemList.SelectedItem as CommContracts.TherapyItem;
            if (temp == null)
                return;

            // 新增治疗项目
            var window = new Window();

            EditTherapyItemView eidtTherapyItem = new EditTherapyItemView(temp);
            window.Content = eidtTherapyItem;
            window.Width = 400;
            window.Height = 500;
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("治疗项目修改完成！");
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
            this.AllTherapyItemList.ItemsSource = vm?.GetAllTherapyItem(strName);
        }
    }
}
