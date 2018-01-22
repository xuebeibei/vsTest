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
    [Export("MedicineDoctorAdviceView", typeof(MedicineDoctorAdviceView))]
    public partial class MedicineDoctorAdviceView : HISGUIViewBase
    {
        private MyTableEdit myXiChengTableEdit;
        private MyTableEdit myZhongTableEdit;

        public MedicineDoctorAdviceView()
        {
            InitializeComponent();
            myXiChengTableEdit = new MyTableEdit(MyTableEditEnum.xichengyao);
            xiyaoPanel.Children.Add(myXiChengTableEdit);
            myZhongTableEdit = new MyTableEdit(MyTableEditEnum.zhongyao);
            zhongyaoPanel.Children.Add(myZhongTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
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
            CommContracts.DoctorAdviceContentEnum recipeContentEnum = CommContracts.DoctorAdviceContentEnum.XiChengYao;
            if (this.tabControl.SelectedIndex == 0)
            {
                listDetail = myXiChengTableEdit.GetAllDetails();
                recipeContentEnum = CommContracts.DoctorAdviceContentEnum.XiChengYao;
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                listDetail = myZhongTableEdit.GetAllDetails();
                recipeContentEnum = CommContracts.DoctorAdviceContentEnum.ZhongYao;
            }

            List<CommContracts.MedicineDoctorAdviceDetail> list = new List<CommContracts.MedicineDoctorAdviceDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.MedicineDoctorAdviceDetail recipeDetail = new CommContracts.MedicineDoctorAdviceDetail();
                //recipeDetail.GroupNum = tem.GroupNum;
                recipeDetail.MedicineID = tem.ID;
                recipeDetail.AllNum = tem.SingleDose;
                //recipeDetail.Usage = tem.Usage;
                //recipeDetail.DDDS = tem.DDDS;
                //recipeDetail.DaysNum = tem.DaysNum;
                //recipeDetail.IntegralDose = tem.IntegralDose;
                recipeDetail.Remarks = tem.Illustration;
                list.Add(recipeDetail);
            }

            var vm = this.DataContext as HISGUIDoctorVM;
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
            var vm = this.DataContext as HISGUIDoctorVM;
            this.XiChengRecipeMsg.Text = vm?.newRecipe();
            this.myXiChengTableEdit.ClearAllDetails();
            
            this.AllXiChengList.SelectedItems.Clear();
            this.myXiChengTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void newZhongYao()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.ZhongRecipeMsg.Text = vm?.newRecipe();
            this.myZhongTableEdit.ClearAllDetails();
            this.myZhongTableEdit.IsEnabled = true;
            this.AllZhongList.SelectedItems.Clear();

            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
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
            var vm = this.DataContext as HISGUIDoctorVM;
            this.AllXiChengList.ItemsSource = vm?.getAllXiCheng();

        }
        private void getAllZhong()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.AllZhongList.ItemsSource = vm?.getAllZhong();
        }

        private void AllXiChengList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.Recipe recipe = AllXiChengList.SelectedItem as CommContracts.Recipe;
            ShowDetails(recipe, CommContracts.DoctorAdviceContentEnum.XiChengYao);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }

        private void AllZhongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.Recipe recipe = AllZhongList.SelectedItem as CommContracts.Recipe;
            ShowDetails(recipe, CommContracts.DoctorAdviceContentEnum.ZhongYao);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }

        private void ShowDetails(CommContracts.Recipe recipe , CommContracts.DoctorAdviceContentEnum recipeContentEnum)
        {
            if (recipe == null)
                return;

            CommClient.Medicine myd = new CommClient.Medicine();
            CommContracts.Medicine medicine = new CommContracts.Medicine();
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in recipe.RecipeDetails)
            {
                MyDetail recipeDetail = new MyDetail();

                recipeDetail.GroupNum = tem.GroupNum;
                recipeDetail.ID = tem.MedicineID;
                medicine = myd.GetMedicine(tem.MedicineID);
                recipeDetail.Name = medicine.Name;
                recipeDetail.Specifications = medicine.Specifications;
                recipeDetail.SingleDose = tem.SingleDose;
                recipeDetail.Usage = tem.Usage;
                recipeDetail.DDDS = tem.DDDS;
                recipeDetail.DaysNum = tem.DaysNum;
                recipeDetail.IntegralDose = tem.IntegralDose;
                recipeDetail.Illustration = tem.Illustration;
                list.Add(recipeDetail);
            }

            if (recipeContentEnum == CommContracts.DoctorAdviceContentEnum.XiChengYao)
            {
                this.XiChengRecipeMsg.Text = recipe.ToTipString();
                myXiChengTableEdit.SetAllDetails(list);
                myXiChengTableEdit.IsEnabled = false;
            }
            else if(recipeContentEnum == CommContracts.DoctorAdviceContentEnum.ZhongYao)
            {
                this.ZhongRecipeMsg.Text = recipe.ToTipString();
                myZhongTableEdit.SetAllDetails(list);
                myZhongTableEdit.IsEnabled = false;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
