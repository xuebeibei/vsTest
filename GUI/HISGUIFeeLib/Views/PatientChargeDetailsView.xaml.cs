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
using HISGUIFeeLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;

namespace HISGUIFeeLib.Views
{
    [Export]
    [Export("PatientChargeDetailsView", typeof(PatientChargeDetailsView))]
    public partial class PatientChargeDetailsView : HISGUIViewBase
    {
        public CommContracts.Recipe CurrentRecipe { get; set; }
        private MyTableEdit MyTableEdit;
        private MyTableEditEnum sourceEditEnum;

        public PatientChargeDetailsView(MyTableEditEnum sourceEditEnum)
        {
            InitializeComponent();
            MyTableEdit = new MyTableEdit(MyTableEditEnum.chargeDetail);
            DetailsPanel.Children.Add(MyTableEdit);
            this.sourceEditEnum = sourceEditEnum;
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            ShowRecipe();
        }

        private void ShowRecipe()
        {
            if (this.sourceEditEnum == MyTableEditEnum.xichengyao ||
                this.sourceEditEnum == MyTableEditEnum.zhongyao)
            {
                this.MyTableEdit.ClearAllDetails();

                if (this.CurrentRecipe == null)
                {
                    return;
                }

                if (this.CurrentRecipe.RecipeDetails == null)
                {
                    return;
                }

                List<MyDetail> list = new List<MyDetail>();
                foreach (var tem in this.CurrentRecipe.RecipeDetails)
                {
                    if (tem == null)
                        continue;
                    MyDetail myDetail = new MyDetail();

                    CommClient.StoreRoomMedicineNum storeRoomMedicineNum = new CommClient.StoreRoomMedicineNum();
                    List<CommContracts.StoreRoomMedicineNum> storeList = storeRoomMedicineNum.GetStoreFromMedicine(tem.MedicineID, tem.SingleDose);

                    if (storeList == null || storeList.Count <= 0)
                    {
                        myDetail.StoreRoomMedicineNumID = 0;
                        myDetail.Name = tem.Medicine.Name;
                        myDetail.Specifications = tem.Medicine.Specifications;
                        myDetail.SingleDoseUnit = tem.Medicine.Unit;
                        myDetail.BatchID = "";
                        myDetail.BeforeOutNum = 0;
                        myDetail.SingleDose = tem.SingleDose;
                        myDetail.SellPrice = tem.Medicine.SellPrice;
                        myDetail.SingleDose = tem.SingleDose;
                        myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                        myDetail.Rebate = 100;
                        myDetail.Illustration = tem.Illustration;
                        list.Add(myDetail);
                    }
                    else
                    {
                        if (storeList.Count > 0)
                        {
                            int nIndex = storeList.Count - 1;  // 取最后一个索引
                            int nLastNum = tem.SingleDose;
                            foreach (var store in storeList)
                            {
                                myDetail.StoreRoomMedicineNumID = store.ID;
                                myDetail.Name = tem.Medicine.Name;
                                myDetail.Specifications = tem.Medicine.Specifications;
                                myDetail.SingleDoseUnit = tem.Medicine.Unit;
                                myDetail.BatchID = store.Batch;
                                myDetail.BeforeOutNum = store.Num;
                                if (nIndex > 0)
                                {
                                    myDetail.SingleDose = store.Num;
                                }
                                else if (nIndex == 0)
                                {
                                    myDetail.SingleDose = nLastNum;
                                }

                                myDetail.SellPrice = tem.Medicine.SellPrice;
                                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                                myDetail.Rebate = 100;
                                myDetail.Illustration = tem.Illustration;

                                list.Add(myDetail);

                                nIndex--;
                                nLastNum -= myDetail.SingleDose;
                            }
                        }
                    }
                }
                this.MyTableEdit.SetAllDetails(list);
            }
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            CommClient.RecipeChargeBill myd = new CommClient.RecipeChargeBill();

            CommContracts.RecipeChargeBill recipeCharge = new CommContracts.RecipeChargeBill();
            recipeCharge.NO = "001";
            recipeCharge.RecipeID = CurrentRecipe.ID;
            recipeCharge.SumOfMoney = 220;
            recipeCharge.ChargeTime = DateTime.Now;
            recipeCharge.Block = false;

            List<MyDetail> list = MyTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return;
            }

            List<CommContracts.RecipeChargeDetail> detailList = new List<CommContracts.RecipeChargeDetail>();
            foreach (var detail in list)
            {
                CommContracts.RecipeChargeDetail recipeChargeDetail = new CommContracts.RecipeChargeDetail();
                recipeChargeDetail.StoreRoomMedicineNumID = detail.StoreRoomMedicineNumID;
                recipeChargeDetail.Num = detail.SingleDose;
                recipeChargeDetail.SellPrice = detail.SellPrice;
                recipeChargeDetail.Rebate = detail.Rebate;

                detailList.Add(recipeChargeDetail);
            }
            recipeCharge.RecipeChargeDetails = detailList;
            if(myd.SaveRecipeChargeBill(recipeCharge))
            {
                MessageBox.Show("收费成功！");
                return;
            }
            else
            {
                MessageBox.Show("收费失败！");
                return;
            }
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
