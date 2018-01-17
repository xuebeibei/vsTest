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
    [Export("MaterialSetView", typeof(MaterialSetView))]
    public partial class MaterialSetView : HISGUIViewBase
    {
        public MaterialSetView()
        {
            InitializeComponent();
            this.Loaded += MaterialSetView_Loaded;
        }

        private void MaterialSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllMaterialList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增物资
            var window = new Window();

            EditMaterialView eidtMaterial = new EditMaterialView();
            window.Content = eidtMaterial;
            window.Width = 400;
            window.Height = 500;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("物资新建完成！");
                UpdateAllDate();
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentMaterial = this.AllMaterialList.SelectedItem as CommContracts.Material;
            if (currentMaterial == null)
                return;

            if (MessageBox.Show("确认删除该物资？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteMaterial(currentMaterial.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("物资删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllMaterialList.SelectedItem as CommContracts.Material;
            if (temp == null)
                return;

            // 新增物资
            var window = new Window();

            EditMaterialView eidtMaterial = new EditMaterialView(temp);
            window.Content = eidtMaterial;
            window.Width = 400;
            window.Height = 500;
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("物资修改完成！");
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
            this.AllMaterialList.ItemsSource = vm?.GetAllMaterial(strName);
        }
    }
}
