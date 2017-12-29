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
    [Export("MaterialBill", typeof(MaterialBill))]
    public partial class MaterialBill : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public MaterialBill()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.cailiao);
            MaterialBillPanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllMaterialBillList();
            newMaterialBill();
        }

        private void getAllMaterialBillList()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.MaterialBillList.ItemsSource = vm?.getAllMaterialBill();
        }

        private void newMaterialBill()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.MaterialBillMsg.Text = vm?.newMaterialBill();

            this.myTableEdit.ClearAllDetails();

            this.MaterialBillList.SelectedItems.Clear();
            this.myTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newMaterialBill();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = myTableEdit.GetAllDetails();
            List<CommContracts.MaterialBillDetail> list = new List<CommContracts.MaterialBillDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.MaterialBillDetail materialBillDetail = new CommContracts.MaterialBillDetail();
                materialBillDetail.MaterialItemID = tem.ID;
                materialBillDetail.Num = tem.SingleDose;
                materialBillDetail.Illustration = tem.Illustration;
                list.Add(materialBillDetail);
            }

            var vm = this.DataContext as HISGUIDoctorVM;
            bool? saveResult = vm?.SaveMaterialBill(list);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newMaterialBill();
                getAllMaterialBillList();
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

        private void ShowDetails(CommContracts.MaterialBill materialBill)
        {
            if (materialBill == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in materialBill.MaterialBillDetails)
            {
                MyDetail recipeDetail = new MyDetail();
                recipeDetail.ID = tem.MaterialBillID;
                recipeDetail.Name = tem.MaterialItem.Name;
                recipeDetail.SingleDose = tem.Num;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            this.MaterialBillMsg.Text = materialBill.ToTipString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaterialBillList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.MaterialBill materialBill = MaterialBillList.SelectedItem as CommContracts.MaterialBill;
            ShowDetails(materialBill);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }
    }
}
