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
    [Export("AssayDoctorAdviceView", typeof(AssayDoctorAdviceView))]
    public partial class AssayDoctorAdviceView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public AssayDoctorAdviceView()
        {
            InitializeComponent();

            myTableEdit = new MyTableEdit(MyTableEditEnum.jianyan);
            AssayPanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
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
            var vm = this.DataContext as HISGUIDoctorVM;
            this.AssayList.ItemsSource = vm?.getAllAssayDoctorAdvice();
        }

        private void newAssay()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.AssayMsg.Text = vm?.newAssayDoctorAdvice();

            this.myTableEdit.ClearAllDetails();

            this.AssayList.SelectedItems.Clear();
            this.myTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = myTableEdit.GetAllDetails();
            List<CommContracts.AssayDoctorAdviceDetail> list = new List<CommContracts.AssayDoctorAdviceDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.AssayDoctorAdviceDetail recipeDetail = new CommContracts.AssayDoctorAdviceDetail();
                recipeDetail.ID = tem.ID;
                recipeDetail.AllNum = tem.SingleDose;
                recipeDetail.Remarks = tem.Illustration;
                list.Add(recipeDetail);
            }

            var vm = this.DataContext as HISGUIDoctorVM;
            bool? saveResult = vm?.SaveAssayDoctorAdvice(list);

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

        private void ShowDetails(CommContracts.AssayDoctorAdvice assay)
        {
            if (assay == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in assay.AssayDoctorAdviceDetails)
            {
                MyDetail assayDetail = new MyDetail(); 
                assayDetail.ID = tem.AssayID;
                assayDetail.Name = tem.Assay.Name;
                assayDetail.SingleDose = tem.AllNum;
                assayDetail.Illustration = tem.Remarks;
                list.Add(assayDetail);
            }

            this.AssayMsg.Text = assay.ToString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AssayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.AssayDoctorAdvice assayDoctorAdvice = AssayList.SelectedItem as CommContracts.AssayDoctorAdvice;
            ShowDetails(assayDoctorAdvice);

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
