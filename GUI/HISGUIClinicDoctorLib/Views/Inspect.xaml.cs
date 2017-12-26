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
            var vm = this.DataContext as HISGUIClinicDoctorVM;
            string str = vm?.newInspect();
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
                //vm?.newRegistrationBill();
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
    }
}
