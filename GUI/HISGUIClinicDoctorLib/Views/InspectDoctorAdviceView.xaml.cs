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
    [Export("InspectDoctorAdviceView", typeof(InspectDoctorAdviceView))]
    public partial class InspectDoctorAdviceView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public InspectDoctorAdviceView()
        {
            InitializeComponent();

            myTableEdit = new MyTableEdit(MyTableEditEnum.jiancha);
            InspectPanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllInspectList();
            newInspect();
        }

        private void getAllInspectList()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.InspectList.ItemsSource = vm?.getAllInspect();
        }

        private void newInspect()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            string str = vm?.newInspect();

            this.myTableEdit.ClearAllDetails();

            this.InspectList.SelectedItems.Clear();
            this.myTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = myTableEdit.GetAllDetails();
            List<CommContracts.InspectDoctorAdviceDetail> list = new List<CommContracts.InspectDoctorAdviceDetail>();
            decimal sum = 0.0m;
            foreach (var tem in listDetail)
            {
                CommContracts.InspectDoctorAdviceDetail recipeDetail = new CommContracts.InspectDoctorAdviceDetail();
                recipeDetail.InspectID = tem.ID;
                recipeDetail.AllNum = tem.SingleDose;
                recipeDetail.Remarks = tem.Illustration;
                list.Add(recipeDetail);
                sum += tem.SingleDose * tem.SellPrice;
            }

            CommContracts.InspectDoctorAdvice inspectDoctorAdvice = new CommContracts.InspectDoctorAdvice();


            var vm = this.DataContext as HISGUIDoctorVM;

            inspectDoctorAdvice.NO = "";
            //inspectDoctorAdvice.PatientID = vm.CurrentRegistration.PatientID;
            //inspectDoctorAdvice.RegistrationID = vm.CurrentRegistration.ID;
            if (vm.IsClinicOrInHospital)
            {
                if (vm.CurrentRegistration != null)
                {
                    inspectDoctorAdvice.RegistrationID = vm.CurrentRegistration.ID;
                    inspectDoctorAdvice.PatientID = vm.CurrentRegistration.PatientID;
                }
            }
            else
            {
                if (vm.CurrentInHospital != null)
                {
                    inspectDoctorAdvice.InpatientID = vm.CurrentInHospital.ID;
                    inspectDoctorAdvice.PatientID = vm.CurrentInHospital.PatientID;
                }
            }
            inspectDoctorAdvice.SumOfMoney = sum;
            inspectDoctorAdvice.WriteTime = DateTime.Now;
            if (vm.CurrentUser != null)
                inspectDoctorAdvice.WriteDoctorUserID = vm.CurrentUser.ID;
            inspectDoctorAdvice.InspectDoctorAdviceDetails = list;

            bool? saveResult = vm?.SaveInspectDoctorAdvice(inspectDoctorAdvice);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newInspect();
                getAllInspectList();
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

        private void ShowDetails(CommContracts.InspectDoctorAdvice inspect)
        {
            if (inspect == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in inspect.InspectDoctorAdviceDetails)
            {
                MyDetail recipeDetail = new MyDetail();
                recipeDetail.ID = tem.InspectID;
                recipeDetail.Name = tem.Inspect.Name;
                recipeDetail.SingleDose = tem.AllNum;
                recipeDetail.Illustration = tem.Remarks;
                list.Add(recipeDetail);
            }

            this.InspectMsg.Text = inspect.ToString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InspectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.InspectDoctorAdvice inspect = InspectList.SelectedItem as CommContracts.InspectDoctorAdvice;
            ShowDetails(inspect);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newInspect();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
