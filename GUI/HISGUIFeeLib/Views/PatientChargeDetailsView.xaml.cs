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

                if (this.CurrentRecipe.ChargeStatusEnum == CommContracts.ChargeStatusEnum.全部收费)
                {
                    this.MyTableEdit.IsEnabled = false;
                    this.HospitalCardPay.IsEnabled = false;
                    this.Alipay.IsEnabled = false;
                    this.WeChatPay.IsEnabled = false;
                    this.CashPay.IsEnabled = false;
                    this.PayBtn.Visibility = Visibility.Collapsed;
                    this.ReturnBtn.Visibility = Visibility.Visible;

                    CommClient.RecipeChargeBill myd1 = new CommClient.RecipeChargeBill();
                    List<CommContracts.RecipeChargeBill> list = myd1.GetAllChargeFromRecipe(this.CurrentRecipe.ID);
                    this.AllChargeList.ItemsSource = list;
                }
                else if (this.CurrentRecipe.ChargeStatusEnum == CommContracts.ChargeStatusEnum.未收费)
                {
                    this.MyTableEdit.IsEnabled = true;
                    this.HospitalCardPay.IsEnabled = true;
                    this.Alipay.IsEnabled = true;
                    this.WeChatPay.IsEnabled = true;
                    this.CashPay.IsEnabled = true;

                    this.PayBtn.Visibility = Visibility.Visible;
                    this.ReturnBtn.Visibility = Visibility.Collapsed;


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
        }

        private bool Check()
        {
            List<MyDetail> list = MyTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return false;
            }

            foreach (var detail in list)
            {
                if (detail.SingleDose > detail.BeforeOutNum)
                {
                    MessageBox.Show(detail.Name + "库存不足！");
                    return false;
                }
                else if (detail.SingleDose < 1)
                {
                    MessageBox.Show(detail.Name + "数量不能少于1！");
                    return false;
                }
            }
            return true;
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Check())
                return;

            CommClient.RecipeChargeBill myd = new CommClient.RecipeChargeBill();

            CommContracts.RecipeChargeBill recipeCharge = new CommContracts.RecipeChargeBill();
            recipeCharge.NO = "001";
            recipeCharge.RecipeID = CurrentRecipe.ID;
            recipeCharge.SumOfMoney = this.MyTableEdit.GetSumMoney();
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
            if (myd.SaveRecipeChargeBill(recipeCharge))
            {
                CommClient.StoreRoomMedicineNum myd2 = new CommClient.StoreRoomMedicineNum();
                if (!myd2.SubdStoreNum(recipeCharge))
                {
                    return;
                }

                CommClient.MedicineDoctorAdvice myd1 = new CommClient.MedicineDoctorAdvice();
                if (!myd1.UpdateChargeStatus(CurrentRecipe.ID, CommContracts.ChargeStatusEnum.全部收费))
                {
                    return;
                }

                MessageBox.Show("收费成功！");

                (this.Parent as Window).DialogResult = true;
                (this.Parent as Window).Close();
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

        private void AllChargeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = this.AllChargeList.SelectedItem as CommContracts.RecipeChargeBill;
            if (temp == null)
                return;
            if (temp.RecipeChargeDetails == null)
                return;

            List<MyDetail> list = new List<MyDetail>();
            foreach (var detail in temp.RecipeChargeDetails)
            {
                if (detail == null)
                    continue;
                MyDetail myDetail = new MyDetail();

                myDetail.StoreRoomMedicineNumID = detail.StoreRoomMedicineNumID;
                myDetail.Name = detail.StoreRoomMedicineNum.Medicine.Name;
                if (detail.StoreRoomMedicineNum != null)
                {
                    if(detail.StoreRoomMedicineNum.Medicine != null)
                    {
                        myDetail.Specifications = detail.StoreRoomMedicineNum.Medicine.Specifications;
                        myDetail.SingleDoseUnit = detail.StoreRoomMedicineNum.Medicine.Unit;
                    }
                    myDetail.BatchID = detail.StoreRoomMedicineNum.Batch;
                    myDetail.BeforeOutNum = detail.StoreRoomMedicineNum.Num;
                }
                
                myDetail.SingleDose = detail.Num;
                myDetail.SellPrice = detail.SellPrice;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = detail.Rebate;
                myDetail.Illustration = "";
                list.Add(myDetail);
            }
            this.MyTableEdit.SetAllDetails(list);
        }
    }
}
