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
using HISGUICore.MyContorls;
using HISGUIDoctorLib.ViewModels;
using System.Data;


namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("OtherService", typeof(OtherService))]
    public partial class OtherService : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public OtherService()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.qita);
            OtherServicePanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllOtherServiceList();
            newOtherService();
        }

        private void getAllOtherServiceList()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.OtherServiceList.ItemsSource = vm?.getAllOtherService();
        }

        private void newOtherService()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.OtherServiceMsg.Text = vm?.newOtherService();

            this.myTableEdit.ClearAllDetails();

            this.OtherServiceList.SelectedItems.Clear();
            this.myTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newOtherService();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = myTableEdit.GetAllDetails();
            List<CommContracts.OtherServiceDoctorAdviceDetail> list = new List<CommContracts.OtherServiceDoctorAdviceDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.OtherServiceDoctorAdviceDetail otherServiceDetail = new CommContracts.OtherServiceDoctorAdviceDetail();
                otherServiceDetail.OtherServiceID = tem.ID;
                otherServiceDetail.AllNum = tem.SingleDose;
                otherServiceDetail.Remarks = tem.Illustration;
                list.Add(otherServiceDetail);
            }

            var vm = this.DataContext as HISGUIDoctorVM;
            bool? saveResult = vm?.SaveOtherService(list);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newOtherService();
                getAllOtherServiceList();
            }
            else
            {
                MessageBox.Show("保存失败！");
                return;
            }
        }

        private void SaveTempletBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowDetails(CommContracts.OtherServiceDoctorAdvice otherService)
        {
            if (otherService == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in otherService.OtherServiceDoctorAdviceDetails)
            {
                MyDetail assayDetail = new MyDetail();
                assayDetail.ID = tem.OtherServiceID;
                assayDetail.Name = tem.OtherService.Name;
                assayDetail.SingleDose = tem.AllNum;
                assayDetail.Illustration = tem.Remarks;
                list.Add(assayDetail);
            }

            this.OtherServiceMsg.Text = otherService.ToString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OtherServiceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.OtherServiceDoctorAdvice otherService = OtherServiceList.SelectedItem as CommContracts.OtherServiceDoctorAdvice;
            ShowDetails(otherService);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;

        }
    }
}
