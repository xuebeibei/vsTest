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
    [Export("ClinicRemedy", typeof(ClinicRemedy))]
    public partial class ClinicRemedy : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public ClinicRemedy()
        {
            InitializeComponent();

            myTableEdit = new MyTableEdit(MyTableEditEnum.zhiliao);
            RemedyPanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllTherapyList();
            newTherapy();
        }

        private void getAllTherapyList()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.TherapyList.ItemsSource = vm?.getAllTherapy();
        }

        private void newTherapy()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            string str = vm?.newTherapy();

            this.myTableEdit.ClearAllDetails();

            this.TherapyList.SelectedItems.Clear();
            this.myTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = myTableEdit.GetAllDetails();
            List<CommContracts.TherapyDetail> list = new List<CommContracts.TherapyDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.TherapyDetail recipeDetail = new CommContracts.TherapyDetail();
                recipeDetail.TherapyItemID = tem.ID;
                recipeDetail.Num = tem.SingleDose;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            var vm = this.DataContext as HISGUIDoctorVM;
            bool? saveResult = vm?.SaveTherapy(list);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newTherapy();
                getAllTherapyList();
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

        private void ShowDetails(CommContracts.Therapy therapy)
        {
            if (therapy == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in therapy.TherapyDetails)
            {
                MyDetail recipeDetail = new MyDetail();
                recipeDetail.ID = tem.TherapyID;
                recipeDetail.Name = tem.TherapyItem.Name;
                recipeDetail.SingleDose = tem.Num;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            this.TherapyMsg.Text = therapy.ToTipString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemedyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.Therapy therapy = TherapyList.SelectedItem as CommContracts.Therapy;
            ShowDetails(therapy);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newTherapy();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
