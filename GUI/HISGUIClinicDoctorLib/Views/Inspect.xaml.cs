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
    [Export("Inspect", typeof(Inspect))]
    public partial class Inspect : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public Inspect()
        {
            InitializeComponent();

            myTableEdit = new MyTableEdit(MyTableEditEnum.jiancha);
            InspectPanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
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
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.InspectList.ItemsSource = vm?.getAllInspect();
        }

        private void newInspect()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
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
            List<CommContracts.InspectDetail> list = new List<CommContracts.InspectDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.InspectDetail recipeDetail = new CommContracts.InspectDetail();
                recipeDetail.InspectItemID = tem.ID;
                recipeDetail.Num = tem.SingleDose;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            var vm = this.DataContext as HISGUIClinicDoctorVM;
            bool? saveResult = vm?.SaveInspect(list);

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

        private void ShowDetails(CommContracts.Inspect inspect)
        {
            if (inspect == null)
                return;
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in inspect.InspectDetails)
            {
                MyDetail recipeDetail = new MyDetail();
                recipeDetail.ID = tem.InspectID;
                recipeDetail.Name = tem.InspectItem.Name;
                recipeDetail.SingleDose = tem.Num;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            this.InspectMsg.Text = inspect.ToTipString();
            this.myTableEdit.SetAllDetails(list);
            this.myTableEdit.IsEnabled = false;
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InspectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.Inspect inspect = InspectList.SelectedItem as CommContracts.Inspect;
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
