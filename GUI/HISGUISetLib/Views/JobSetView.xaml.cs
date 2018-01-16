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
    [Export("JobSetView", typeof(JobSetView))]
    public partial class JobSetView : HISGUIViewBase
    {
        public JobSetView()
        {
            InitializeComponent();
            this.Loaded += JobSetView_Loaded;
        }

        private void JobSetView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllDate();
        }

        [Import]
        private HISGUISetVM ImportVM
        {
            set { this.VM = value; }
        }

        private void AllJobList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FindItemBtn_Click(object sender, RoutedEventArgs e)
        {
            string strName = this.FindItemNameBox.Text.Trim();
            UpdateAllDate(strName);
        }

        private void NewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            // 新增职位
            var window = new Window();

            EditJobView eidtJob = new EditJobView();
            window.Content = eidtJob;
            window.Width = 400;
            window.Height = 300;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("职位新建完成！");
                UpdateAllDate();
            }
        }

        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentJob = this.AllJobList.SelectedItem as CommContracts.Job;
            if (currentJob == null)
                return;

            if (MessageBox.Show("确认删除该职位？", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var vm = this.DataContext as HISGUISetVM;
                bool? bIsOK = vm?.DeleteJob(currentJob.ID);
                if (bIsOK.HasValue)
                {
                    if (bIsOK.Value)
                    {
                        MessageBox.Show("职位删除完成！");
                        UpdateAllDate();
                    }
                }
            }
        }

        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.AllJobList.SelectedItem as CommContracts.Job;
            if (temp == null)
                return;

            // 新增职位
            var window = new Window();

            EditJobView eidtJob = new EditJobView(temp);
            window.Content = eidtJob;
            window.Width = 400;
            window.Height = 300;
            bool? bResult = window.ShowDialog();

            if (bResult.Value)
            {
                MessageBox.Show("职位修改完成！");
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
            this.AllJobList.ItemsSource = vm?.GetAllJob(strName);
        }

    }
}
