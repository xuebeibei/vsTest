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
    [Export("MedicineSetView", typeof(MedicineSetView))]
    public partial class MedicineSetView : HISGUIViewBase
    {
        public MedicineSetView()
        {
            InitializeComponent();
            this.Loaded += MedicineSetView_Loaded;
        }

        private void MedicineSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllMedicineList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增药品
            var window = new Window();

            EditMedicineView eidtMedicine = new EditMedicineView();
            window.Content = eidtMedicine;
            window.Width = 400;
            window.Height = 500;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("药品新建完成！");
                UpdateAllDate();
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentMedicine = this.AllMedicineList.SelectedItem as CommContracts.Medicine;
            if (currentMedicine == null)
                return;

            if (MessageBox.Show("确认删除该药品？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteMedicine(currentMedicine.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("药品删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllMedicineList.SelectedItem as CommContracts.Medicine;
            if (temp == null)
                return;

            // 新增药品
            var window = new Window();

            EditMedicineView eidtMedicine = new EditMedicineView(temp);
            window.Content = eidtMedicine;
            window.Width = 400;
            window.Height = 500;
            window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("药品修改完成！");
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
            this.AllMedicineList.ItemsSource = vm?.GetAllMedicine(strName);
        }
    }
}
