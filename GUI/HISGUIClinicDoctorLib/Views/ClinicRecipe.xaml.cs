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
    [Export("ClinicRecipe", typeof(ClinicRecipe))]
    public partial class ClinicRecipe : HISGUIViewBase
    {
        private MyTableEdit myXiChengTableEdit;
        private MyTableEdit myZhongTableEdit;

        public ClinicRecipe()
        {
            InitializeComponent();
            myXiChengTableEdit = new MyTableEdit(MyTableEditEnum.xichengyao);
            xiyaoPanel.Children.Add(myXiChengTableEdit);
            myZhongTableEdit = new MyTableEdit(MyTableEditEnum.zhongyao);
            zhongyaoPanel.Children.Add(myZhongTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIClinicDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllRecipeList();
            newAllRecipe();
        }

        private void SelectDrugBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CopyRecipeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = new List<MyDetail>();
            CommContracts.RecipeContentEnum recipeContentEnum = CommContracts.RecipeContentEnum.XiChengYao;
            if (this.tabControl.SelectedIndex == 0)
            {
                listDetail = myXiChengTableEdit.GetAllDetails();
                recipeContentEnum = CommContracts.RecipeContentEnum.XiChengYao;
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                listDetail = myZhongTableEdit.GetAllDetails();
                recipeContentEnum = CommContracts.RecipeContentEnum.ZhongYao;
            }

            List<CommContracts.RecipeDetail> list = new List<CommContracts.RecipeDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.RecipeDetail recipeDetail = new CommContracts.RecipeDetail();
                recipeDetail.GroupNum = tem.GroupNum;
                recipeDetail.MedicineID = tem.ID;
                recipeDetail.SingleDose = tem.SingleDose;
                recipeDetail.Usage = tem.Usage;
                recipeDetail.DDDS = tem.DDDS;
                recipeDetail.DaysNum = tem.DaysNum;
                recipeDetail.IntegralDose = tem.IntegralDose;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            var vm = this.DataContext as HISGUIClinicDoctorVM;
            bool? saveResult = vm?.SaveRecipe(recipeContentEnum, list);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newRecipe();
                getRecipeList();
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

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newRecipe();
        }

        private void newRecipe()
        {
            if (this.tabControl.SelectedIndex == 0)
            {
                newXiChengYao();
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                newZhongYao();
            }
        }

        private void newAllRecipe()
        {
            newXiChengYao();
            newZhongYao();
        }

        private void newXiChengYao()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.XiChengRecipeMsg.Text = vm?.newRecipe();
            this.myXiChengTableEdit.ClearAllDetails();
        }

        private void newZhongYao()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.ZhongRecipeMsg.Text = vm?.newRecipe();
            this.myZhongTableEdit.ClearAllDetails();
        }

        private void getAllRecipeList()
        {
            getAllXiCheng();
            getAllZhong();
        }

        private void getRecipeList()
        {
            if (this.tabControl.SelectedIndex == 0)
            {
                getAllXiCheng();
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                getAllZhong();
            }
        }

        private void getAllXiCheng()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.AllXiChengList.ItemsSource = vm?.getAllXiCheng();

        }
        private void getAllZhong()
        {
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            this.AllZhongList.ItemsSource = vm?.getAllZhong();
        }

        private void AllXiChengList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AllZhongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
