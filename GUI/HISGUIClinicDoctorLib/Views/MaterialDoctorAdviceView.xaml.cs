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
    [Export("MaterialDoctorAdviceView", typeof(MaterialDoctorAdviceView))]
    public partial class MaterialDoctorAdviceView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public MaterialDoctorAdviceView()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.cailiao);
            MaterialDoctorAdvicePanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllMaterialDoctorAdviceList();
            newMaterialDoctorAdvice();
        }

        private void getAllMaterialDoctorAdviceList()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.MaterialDoctorAdviceList.ItemsSource = vm?.getAllMaterialDoctorAdvice();
        }

        private void newMaterialDoctorAdvice()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.MaterialDoctorAdviceMsg.Text = vm?.newMaterialDoctorAdvice();

            this.myTableEdit.ClearAllDetails();

            this.MaterialDoctorAdviceList.SelectedItems.Clear();
            this.myTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newMaterialDoctorAdvice();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = myTableEdit.GetAllDetails();
            List<CommContracts.MaterialDoctorAdviceDetail> list = new List<CommContracts.MaterialDoctorAdviceDetail>();
            decimal sum = 0.0m;
            foreach (var tem in listDetail)
            {
                CommContracts.MaterialDoctorAdviceDetail materialBillDetail = new CommContracts.MaterialDoctorAdviceDetail();
                materialBillDetail.MaterialID = tem.ID;
                materialBillDetail.AllNum = tem.SingleDose;
                materialBillDetail.Remarks = tem.Illustration;
                list.Add(materialBillDetail);
                sum += tem.SingleDose * tem.SellPrice;
            }
            CommContracts.MaterialDoctorAdvice materialDoctorAdvice = new CommContracts.MaterialDoctorAdvice();

            var vm = this.DataContext as HISGUIDoctorVM;

            materialDoctorAdvice.NO = "";// ?
            if (vm.IsClinicOrInHospital)
            {
                if (vm.CurrentRegistration != null)
                {
                    materialDoctorAdvice.RegistrationID = vm.CurrentRegistration.ID;
                    materialDoctorAdvice.PatientID = vm.CurrentRegistration.PatientID;
                }
            }
            else
            {
                if (vm.CurrentInHospital != null)
                {
                    materialDoctorAdvice.InpatientID = vm.CurrentInHospital.ID;
                    materialDoctorAdvice.PatientID = vm.CurrentInHospital.PatientID;
                }
            }
            materialDoctorAdvice.SumOfMoney = sum;
            materialDoctorAdvice.WriteTime = DateTime.Now;
            if (vm.CurrentUser != null)
                materialDoctorAdvice.WriteDoctorUserID = vm.CurrentUser.ID;

            materialDoctorAdvice.MaterialDoctorAdviceDetails = list;

            bool? saveResult = vm?.SaveMaterialDoctorAdvice(materialDoctorAdvice);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newMaterialDoctorAdvice();
                getAllMaterialDoctorAdviceList();
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

        private void ShowDetails(CommContracts.MaterialDoctorAdvice materialBill)
        {
            if (materialBill == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in materialBill.MaterialDoctorAdviceDetails)
            {
                MyDetail recipeDetail = new MyDetail();
                recipeDetail.ID = tem.MaterialDoctorAdviceID;
                recipeDetail.Name = tem.Material.Name;
                recipeDetail.SingleDose = tem.AllNum;
                recipeDetail.Illustration = tem.Remarks;
                list.Add(recipeDetail);
            }

            MaterialDoctorAdviceMsg.Text = materialBill.ToString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaterialDoctorAdviceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.MaterialDoctorAdvice materialBill = MaterialDoctorAdviceList.SelectedItem as CommContracts.MaterialDoctorAdvice;
            ShowDetails(materialBill);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }
    }
}
