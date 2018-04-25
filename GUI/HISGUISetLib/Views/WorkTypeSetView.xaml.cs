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
    [Export("WorkTypeSetView", typeof(WorkTypeSetView))]
    public partial class WorkTypeSetView : HISGUIViewBase
    {
        public WorkTypeSetView()
        {
            InitializeComponent();
            this.Loaded += WorkTypeSetView_Loaded;
        }

        private void WorkTypeSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllWorkTypeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增值班类别
            var window = new Window();

            EditWorkTypeView eidtWorkType = new EditWorkTypeView();
            window.Content = eidtWorkType;
            window.Width = 300;
            window.Height = 200;
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("值班类别新建完成！");
                UpdateAllDate();
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentWorkType = this.AllWorkTypeList.SelectedItem as CommContracts.WorkType;
            if (currentWorkType == null)
                return;

            if (MessageBox.Show("确认删除该值班类别？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteWorkType(currentWorkType.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("值班类别删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllWorkTypeList.SelectedItem as CommContracts.WorkType;
            if (temp == null)
                return;

            // 新增值班类别
            var window = new Window();

            EditWorkTypeView eidtWorkType = new EditWorkTypeView(temp);
            window.Content = eidtWorkType;
            window.Width = 300;
            window.Height = 200;
            //window.ResizeMode = ResizeMode.NoResize;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("值班类别修改完成！");
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
            this.AllWorkTypeList.ItemsSource = vm?.GetAllWorkType(strName);
        }
    }
}
