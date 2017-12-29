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
using HISGUIClinicDoctorLib.ViewModels;
using System.Data;


namespace HISGUIClinicDoctorLib.Views
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
        private HISGUIClinicDoctorVM ImportVM
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
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.OtherServiceList.ItemsSource = vm?.getAllOtherService();
        }

        private void newOtherService()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
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
            List<CommContracts.OtherServiceDetail> list = new List<CommContracts.OtherServiceDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.OtherServiceDetail otherServiceDetail = new CommContracts.OtherServiceDetail();
                otherServiceDetail.OtherServiceItemID = tem.ID;
                otherServiceDetail.Num = tem.SingleDose;
                otherServiceDetail.Illustration = tem.Illustration;
                list.Add(otherServiceDetail);
            }

            var vm = this.DataContext as HISGUIClinicDoctorVM;
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

        private void ShowDetails(CommContracts.OtherService otherService)
        {
            if (otherService == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in otherService.OtherServiceDetails)
            {
                MyDetail assayDetail = new MyDetail();
                assayDetail.ID = tem.OtherServiceID;
                assayDetail.Name = tem.OtherServiceItem.Name;
                assayDetail.SingleDose = tem.Num;
                assayDetail.Illustration = tem.Illustration;
                list.Add(assayDetail);
            }

            this.OtherServiceMsg.Text = otherService.ToTipString();
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
            CommContracts.OtherService otherService = OtherServiceList.SelectedItem as CommContracts.OtherService;
            ShowDetails(otherService);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;

        }
    }
}
