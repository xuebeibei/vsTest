﻿using System;
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
            newRecipe();

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
            if (this.tabControl.SelectedIndex == 0)
            {
                listDetail = myXiChengTableEdit.GetAllDetails();
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                listDetail = myZhongTableEdit.GetAllDetails();
            }

            List<CommContracts.RecipeDetail> list = new List<CommContracts.RecipeDetail>();
            foreach(var tem in listDetail)
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
            bool? saveResult = vm?.SaveRecipe(list);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
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
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            
            if (this.tabControl.SelectedIndex == 0)
            {
                string str = vm?.newRecipe();
                this.XiChengRecipeMsg.Text = str;
            } 
            else if (this.tabControl.SelectedIndex == 1)
            {
                string str = vm?.newRecipe(CommContracts.RecipeContentEnum.ZhongYao);
                this.ZhongRecipeMsg.Text = str;
            }
        }

        private void getAllRecipeList()
        {
            if (this.tabControl.SelectedIndex == 0)
                getAllXiCheng();
            else if (this.tabControl.SelectedIndex == 1)
                getAllZhong();
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

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                getAllRecipeList();
                newRecipe();
            }
        }
    }
}
