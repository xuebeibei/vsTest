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
    [Export("Assay", typeof(Assay))]
    public partial class Assay : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public Assay()
        {
            InitializeComponent();

            myTableEdit = new MyTableEdit(MyTableEditEnum.jianyan);
            AssayPanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllAssayList();
            newAssay();
        }

        private void getAllAssayList()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.AssayList.ItemsSource = vm?.getAllAssay();
        }

        private void newAssay()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.AssayMsg.Text = vm?.newAssay();

            this.myTableEdit.ClearAllDetails();

            this.AssayList.SelectedItems.Clear();
            this.myTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = myTableEdit.GetAllDetails();
            List<CommContracts.AssayDetail> list = new List<CommContracts.AssayDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.AssayDetail recipeDetail = new CommContracts.AssayDetail();
                recipeDetail.AssayItemID = tem.ID;
                recipeDetail.Num = tem.SingleDose;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            var vm = this.DataContext as HISGUIClinicDoctorVM;
            bool? saveResult = vm?.SaveAssay(list);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newAssay();
                getAllAssayList();
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

        private void ShowDetails(CommContracts.Assay assay)
        {
            if (assay == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in assay.AssayDetails)
            {
                MyDetail recipeDetail = new MyDetail(); 
                recipeDetail.ID = tem.AssayID;
                recipeDetail.Name = tem.AssayItem.Name;
                recipeDetail.SingleDose = tem.Num;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            this.AssayMsg.Text = assay.ToTipString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AssayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.Assay assay = AssayList.SelectedItem as CommContracts.Assay;
            ShowDetails(assay);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newAssay();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
