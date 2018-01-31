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
    [Export("ChargeView", typeof(ChargeView))]
    public partial class ChargeView : HISGUIViewBase
    {
        private int myCurrentPatientID;
        private MyTableEdit MyMedicineTableEdit;
        private MyTableEdit MyJianYanTableEdit;
        public ChargeView()
        {
            InitializeComponent();
            myCurrentPatientID = 0;
            MyMedicineTableEdit = new MyTableEdit(MyTableEditEnum.medicineChargeDetail);
            DetailsPanel.Children.Add(MyMedicineTableEdit);
            MyJianYanTableEdit = new MyTableEdit(MyTableEditEnum.otherChargeDetail);
            DetailsPanel.Children.Add(MyJianYanTableEdit);

            this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
            this.MyJianYanTableEdit.Visibility = Visibility.Collapsed;

            this.Loaded += ChargeView_Loaded;
        }

        private void ChargeView_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAllPatient();

            var vm = this.DataContext as HISGUIFeeVM;
            if (this.ClinicRadio.IsChecked.Value)
                vm.IsClinicOrInHospital = true;
            else if (this.HospitalRadio.IsChecked.Value)
                vm.IsClinicOrInHospital = false;
        }

        [Import]
        private HISGUIFeeVM ImportVM
        {
            set { this.VM = value; }
        }

        private void NoPayCheck_Click(object sender, RoutedEventArgs e)
        {
            this.AllWillPayList.Visibility = Visibility.Visible;
            this.AllPayList.Visibility = Visibility.Collapsed;
            this.PayBtn.Visibility = Visibility.Visible;
            this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
            this.MyJianYanTableEdit.Visibility = Visibility.Collapsed;
            UpdateAllChage();
        }

        private void HavePayCheck_Click(object sender, RoutedEventArgs e)
        {
            this.AllWillPayList.Visibility = Visibility.Collapsed;
            this.AllPayList.Visibility = Visibility.Visible;
            this.PayBtn.Visibility = Visibility.Collapsed;
            this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
            this.MyJianYanTableEdit.Visibility = Visibility.Collapsed;
            UpdateAllChage();
        }

        private void SaveMedicineCharge(CommContracts.DoctorAdviceBase tempAdvice)
        {
            if (!Check())
                return;

            var vm = this.DataContext as HISGUIFeeVM;


            CommContracts.MedicineCharge recipeCharge = new CommContracts.MedicineCharge();
            recipeCharge.NO = "";
            recipeCharge.MedicineDoctorAdviceID = tempAdvice.ID;
            recipeCharge.SumOfMoney = this.MyMedicineTableEdit.GetSumMoney();
            recipeCharge.ChargeTime = DateTime.Now;
            if (vm.CurrentUser != null)
                recipeCharge.ChargeUserID = vm.CurrentUser.ID;

            List<MyDetail> list = MyMedicineTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return;
            }

            List<CommContracts.MedicineChargeDetail> detailList = new List<CommContracts.MedicineChargeDetail>();
            foreach (var detail in list)
            {
                CommContracts.MedicineChargeDetail MedicineChargeDetail = new CommContracts.MedicineChargeDetail();
                MedicineChargeDetail.StoreRoomMedicineNumID = detail.StoreRoomNumID;
                MedicineChargeDetail.AllNum = detail.SingleDose;
                MedicineChargeDetail.SellPrice = detail.SellPrice;
                MedicineChargeDetail.Rebate = detail.Rebate;

                detailList.Add(MedicineChargeDetail);
            }
            recipeCharge.MedicineChargeDetails = detailList;

            CommClient.MedicineCharge myd = new CommClient.MedicineCharge();
            if (myd.SaveMedicineCharge(recipeCharge))
            {
                CommClient.StoreRoomMedicineNum myd2 = new CommClient.StoreRoomMedicineNum();
                if (!myd2.SubdMedicineStoreNum(recipeCharge))
                {
                    return;
                }

                CommClient.MedicineDoctorAdvice myd1 = new CommClient.MedicineDoctorAdvice();
                if (!myd1.UpdateChargeStatus(tempAdvice.ID, CommContracts.ChargeStatusEnum.全部收费))
                {
                    return;
                }

                MessageBox.Show("收费成功！");
                return;
            }
            else
            {
                MessageBox.Show("收费失败！");
                return;
            }
        }

        private void SaveMaterialCharge(CommContracts.DoctorAdviceBase tempAdvice)
        {
            if (!Check())
                return;

            var vm = this.DataContext as HISGUIFeeVM;


            CommContracts.MaterialCharge recipeCharge = new CommContracts.MaterialCharge();
            recipeCharge.NO = "";
            recipeCharge.MaterialDoctorAdviceID = tempAdvice.ID;
            recipeCharge.SumOfMoney = this.MyMedicineTableEdit.GetSumMoney();
            recipeCharge.ChargeTime = DateTime.Now;
            if (vm.CurrentUser != null)
                recipeCharge.ChargeUserID = vm.CurrentUser.ID;

            List<MyDetail> list = MyMedicineTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return;
            }

            List<CommContracts.MaterialChargeDetail> detailList = new List<CommContracts.MaterialChargeDetail>();
            foreach (var detail in list)
            {
                CommContracts.MaterialChargeDetail MaterialChargeDetail = new CommContracts.MaterialChargeDetail();
                MaterialChargeDetail.StoreRoomMaterialNumID = detail.StoreRoomNumID;
                MaterialChargeDetail.AllNum = detail.SingleDose;
                MaterialChargeDetail.SellPrice = detail.SellPrice;
                MaterialChargeDetail.Rebate = detail.Rebate;

                detailList.Add(MaterialChargeDetail);
            }
            recipeCharge.MaterialChargeDetails = detailList;

            CommClient.MaterialCharge myd = new CommClient.MaterialCharge();
            if (myd.SaveMaterialCharge(recipeCharge))
            {
                CommClient.StoreRoomMaterialNum myd2 = new CommClient.StoreRoomMaterialNum();
                if (!myd2.SubdMaterialStoreNum(recipeCharge))
                {
                    return;
                }

                CommClient.MaterialDoctorAdvice myd1 = new CommClient.MaterialDoctorAdvice();
                if (!myd1.UpdateChargeStatus(tempAdvice.ID, CommContracts.ChargeStatusEnum.全部收费))
                {
                    return;
                }

                MessageBox.Show("收费成功！");
                return;
            }
            else
            {
                MessageBox.Show("收费失败！");
                return;
            }
        }

        private void SaveTherapyCharge(CommContracts.DoctorAdviceBase tempAdvice)
        {
            if (!Check())
                return;

            var vm = this.DataContext as HISGUIFeeVM;


            CommContracts.TherapyCharge recipeCharge = new CommContracts.TherapyCharge();
            recipeCharge.NO = "";
            recipeCharge.TherapyDoctorAdviceID = tempAdvice.ID;
            recipeCharge.SumOfMoney = this.MyMedicineTableEdit.GetSumMoney();
            recipeCharge.ChargeTime = DateTime.Now;
            if (vm.CurrentUser != null)
                recipeCharge.ChargeUserID = vm.CurrentUser.ID;

            List<MyDetail> list = MyJianYanTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return;
            }

            List<CommContracts.TherapyChargeDetail> detailList = new List<CommContracts.TherapyChargeDetail>();
            foreach (var detail in list)
            {
                CommContracts.TherapyChargeDetail TherapyChargeDetail = new CommContracts.TherapyChargeDetail();
                TherapyChargeDetail.TherapyID = detail.ID;
                TherapyChargeDetail.AllNum = detail.SingleDose;
                TherapyChargeDetail.SellPrice = detail.SellPrice;
                TherapyChargeDetail.Rebate = detail.Rebate;

                detailList.Add(TherapyChargeDetail);
            }
            recipeCharge.TherapyChargeDetails = detailList;

            CommClient.TherapyCharge myd = new CommClient.TherapyCharge();
            if (myd.SaveTherapyCharge(recipeCharge))
            {

                CommClient.TherapyDoctorAdvice myd1 = new CommClient.TherapyDoctorAdvice();
                if (!myd1.UpdateChargeStatus(tempAdvice.ID, CommContracts.ChargeStatusEnum.全部收费))
                {
                    return;
                }

                MessageBox.Show("收费成功！");
                return;
            }
            else
            {
                MessageBox.Show("收费失败！");
                return;
            }
        }

        private void SaveAssayCharge(CommContracts.DoctorAdviceBase tempAdvice)
        {
            if (!Check())
                return;

            var vm = this.DataContext as HISGUIFeeVM;


            CommContracts.AssayCharge recipeCharge = new CommContracts.AssayCharge();
            recipeCharge.NO = "";
            recipeCharge.AssayDoctorAdviceID = tempAdvice.ID;
            recipeCharge.SumOfMoney = this.MyMedicineTableEdit.GetSumMoney();
            recipeCharge.ChargeTime = DateTime.Now;
            if (vm.CurrentUser != null)
                recipeCharge.ChargeUserID = vm.CurrentUser.ID;

            List<MyDetail> list = MyJianYanTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return;
            }

            List<CommContracts.AssayChargeDetail> detailList = new List<CommContracts.AssayChargeDetail>();
            foreach (var detail in list)
            {
                CommContracts.AssayChargeDetail AssayChargeDetail = new CommContracts.AssayChargeDetail();
                AssayChargeDetail.AssayID = detail.ID;
                AssayChargeDetail.AllNum = detail.SingleDose;
                AssayChargeDetail.SellPrice = detail.SellPrice;
                AssayChargeDetail.Rebate = detail.Rebate;

                detailList.Add(AssayChargeDetail);
            }
            recipeCharge.AssayChargeDetails = detailList;

            CommClient.AssayCharge myd = new CommClient.AssayCharge();
            if (myd.SaveAssayCharge(recipeCharge))
            {

                CommClient.AssayDoctorAdvice myd1 = new CommClient.AssayDoctorAdvice();
                if (!myd1.UpdateChargeStatus(tempAdvice.ID, CommContracts.ChargeStatusEnum.全部收费))
                {
                    return;
                }

                MessageBox.Show("收费成功！");
                return;
            }
            else
            {
                MessageBox.Show("收费失败！");
                return;
            }
        }

        private void SaveInspectCharge(CommContracts.DoctorAdviceBase tempAdvice)
        {
            if (!Check())
                return;

            var vm = this.DataContext as HISGUIFeeVM;


            CommContracts.InspectCharge recipeCharge = new CommContracts.InspectCharge();
            recipeCharge.NO = "";
            recipeCharge.InspectDoctorAdviceID = tempAdvice.ID;
            recipeCharge.SumOfMoney = this.MyMedicineTableEdit.GetSumMoney();
            recipeCharge.ChargeTime = DateTime.Now;
            if (vm.CurrentUser != null)
                recipeCharge.ChargeUserID = vm.CurrentUser.ID;

            List<MyDetail> list = MyJianYanTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return;
            }

            List<CommContracts.InspectChargeDetail> detailList = new List<CommContracts.InspectChargeDetail>();
            foreach (var detail in list)
            {
                CommContracts.InspectChargeDetail InspectChargeDetail = new CommContracts.InspectChargeDetail();
                InspectChargeDetail.InspectID = detail.ID;
                InspectChargeDetail.AllNum = detail.SingleDose;
                InspectChargeDetail.SellPrice = detail.SellPrice;
                InspectChargeDetail.Rebate = detail.Rebate;

                detailList.Add(InspectChargeDetail);
            }
            recipeCharge.InspectChargeDetails = detailList;

            CommClient.InspectCharge myd = new CommClient.InspectCharge();
            if (myd.SaveInspectCharge(recipeCharge))
            {

                CommClient.InspectDoctorAdvice myd1 = new CommClient.InspectDoctorAdvice();
                if (!myd1.UpdateChargeStatus(tempAdvice.ID, CommContracts.ChargeStatusEnum.全部收费))
                {
                    return;
                }

                MessageBox.Show("收费成功！");
                return;
            }
            else
            {
                MessageBox.Show("收费失败！");
                return;
            }
        }

        private void SaveOtherServiceCharge(CommContracts.DoctorAdviceBase tempAdvice)
        {
            if (!Check())
                return;

            var vm = this.DataContext as HISGUIFeeVM;


            CommContracts.OtherServiceCharge recipeCharge = new CommContracts.OtherServiceCharge();
            recipeCharge.NO = "";
            recipeCharge.OtherServiceDoctorAdviceID = tempAdvice.ID;
            recipeCharge.SumOfMoney = this.MyMedicineTableEdit.GetSumMoney();
            recipeCharge.ChargeTime = DateTime.Now;
            if (vm.CurrentUser != null)
                recipeCharge.ChargeUserID = vm.CurrentUser.ID;

            List<MyDetail> list = MyJianYanTableEdit.GetAllDetails();
            if (list == null)
            {
                MessageBox.Show("无明细，收费失败！");
                return;
            }

            List<CommContracts.OtherServiceChargeDetail> detailList = new List<CommContracts.OtherServiceChargeDetail>();
            foreach (var detail in list)
            {
                CommContracts.OtherServiceChargeDetail OtherServiceChargeDetail = new CommContracts.OtherServiceChargeDetail();
                OtherServiceChargeDetail.OtherServiceID = detail.ID;
                OtherServiceChargeDetail.AllNum = detail.SingleDose;
                OtherServiceChargeDetail.SellPrice = detail.SellPrice;
                OtherServiceChargeDetail.Rebate = detail.Rebate;

                detailList.Add(OtherServiceChargeDetail);
            }
            recipeCharge.OtherServiceChargeDetails = detailList;

            CommClient.OtherServiceCharge myd = new CommClient.OtherServiceCharge();
            if (myd.SaveOtherServiceCharge(recipeCharge))
            {

                CommClient.OtherServiceDoctorAdvice myd1 = new CommClient.OtherServiceDoctorAdvice();
                if (!myd1.UpdateChargeStatus(tempAdvice.ID, CommContracts.ChargeStatusEnum.全部收费))
                {
                    return;
                }

                MessageBox.Show("收费成功！");
                return;
            }
            else
            {
                MessageBox.Show("收费失败！");
                return;
            }
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            var tempAdvice = this.AllWillPayList.SelectedItem as CommContracts.DoctorAdviceBase;
            if (tempAdvice == null)
                return;

            switch (tempAdvice.DoctorAdviceEnum)
            {
                case CommContracts.DoctorAdviceBaseEnum.处方:
                    {
                        SaveMedicineCharge(tempAdvice);
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.材料:
                    {
                        SaveMaterialCharge(tempAdvice);
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.治疗:
                    {
                        SaveTherapyCharge(tempAdvice);
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.化验:
                    {
                        SaveAssayCharge(tempAdvice);
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.检查:
                    {
                        SaveInspectCharge(tempAdvice);
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.其他:
                    {
                        SaveOtherServiceCharge(tempAdvice);
                        break;
                    }
                default:
                    break;
            }
        }

        private void ReadCard_Click(object sender, RoutedEventArgs e)
        {
            myCurrentPatientID = 1; // 默认值
            ShowPatientMsg();
            UpdateAllChage();
        }

        private void ShowPatientMsg()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            CommContracts.Patient tempPatient = vm?.ReadCurrentPatient(myCurrentPatientID);
            decimal? dBalance = vm?.GetCurrentPatientBalance(myCurrentPatientID);

            PatientMsg.Inlines.Clear();
            string str =
                "姓名：" + tempPatient.Name + " " +
                "性别：" + tempPatient.Gender + " " +
                "生日：" + tempPatient.BirthDay + " " +
                "身份证号：" + tempPatient.IDCardNo + " " +
                "民族：" + tempPatient.Volk + " " +
                "籍贯：" + tempPatient.JiGuan + " " +
                "电话：" + tempPatient.Tel + " "
                ;
            PatientMsg.Inlines.Add(new Run(str));
            PatientMsg.Inlines.Add(new Run("账户余额：" + dBalance.Value) { Foreground = Brushes.Green, FontSize = 25 });
        }

        public void UpdateAllChage()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            if (this.HavePayCheck.IsChecked.Value)
            {
                // 得到所有已收费单据
                List<CommContracts.ChargeBase> listAllCharge = new List<CommContracts.ChargeBase>();
                listAllCharge.AddRange(vm?.GetAllMedicineCharge());
                listAllCharge.AddRange(vm?.GetAllMaterialCharge());
                listAllCharge.AddRange(vm?.GetAllTherapyCharge());
                listAllCharge.AddRange(vm?.GetAllAssayCharge());
                listAllCharge.AddRange(vm?.GetAllInspectCharge());
                listAllCharge.AddRange(vm?.GetAllOtherServiceCharge());

                this.AllPayList.ItemsSource = listAllCharge;
            }
            else if (this.NoPayCheck.IsChecked.Value)
            {
                List<CommContracts.DoctorAdviceBase> listAllAdvice = new List<CommContracts.DoctorAdviceBase>();

                listAllAdvice.AddRange(vm?.GetAllXiCheng());
                listAllAdvice.AddRange(vm?.GetAllZhong());
                listAllAdvice.AddRange(vm?.GetAllZhiLiao());
                listAllAdvice.AddRange(vm?.GetAllJianYan());
                listAllAdvice.AddRange(vm?.GetAllJianCha());
                listAllAdvice.AddRange(vm?.GetAllCaiLiao());
                listAllAdvice.AddRange(vm?.GetAllQiTa());

                var query = from u in listAllAdvice
                            where u.ChargeStatusEnum == CommContracts.ChargeStatusEnum.未收费
                            select u;

                this.AllWillPayList.ItemsSource = query;
            }
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowAllPatient()
        {
            var vm = this.DataContext as HISGUIFeeVM;
            if (this.ClinicRadio.IsChecked.Value)
            {
                this.AllPatientList.ItemsSource = vm?.GetAllClinicPatients(DateTime.Now, DateTime.Now);
            }
            else if (this.HospitalRadio.IsChecked.Value)
            {
                this.AllPatientList.ItemsSource = vm?.GetAllInHospitalChargePatient(DateTime.Now, DateTime.Now);
            }
        }

        private void ClinicRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            vm.IsClinicOrInHospital = true;
            ShowAllPatient();
        }

        private void HospitalRadio_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            ShowAllPatient();
        }

        private void AllPatientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = this.DataContext as HISGUIFeeVM;
            if (this.ClinicRadio.IsChecked.Value)
            {
                var re = this.AllPatientList.SelectedItem as CommContracts.Registration;
                if (re == null)
                    return;
                myCurrentPatientID = re.PatientID;
                vm.CurrentRegistration = re;
            }
            else if (this.HospitalRadio.IsChecked.Value)
            {
                var inp = this.AllPatientList.SelectedItem as CommContracts.Inpatient;
                if (inp == null)
                    return;
                myCurrentPatientID = inp.PatientID;
                vm.CurrentInpatient = inp;
            }

            ShowPatientMsg();
            UpdateAllChage();
        }

        private void AllWillPayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.MyMedicineTableEdit.ClearAllDetails();
            var doctorAdvice = this.AllWillPayList.SelectedItem as CommContracts.DoctorAdviceBase;
            if (doctorAdvice == null)
                return;

            switch (doctorAdvice.DoctorAdviceEnum)
            {
                case CommContracts.DoctorAdviceBaseEnum.处方:
                    {
                        ShowMedicineAdviceDetails((CommContracts.MedicineDoctorAdvice)doctorAdvice);
                        this.MyMedicineTableEdit.Visibility = Visibility.Visible;
                        this.MyJianYanTableEdit.Visibility = Visibility.Collapsed;
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.材料:
                    {
                        ShowMaterialAdviceDetails((CommContracts.MaterialDoctorAdvice)doctorAdvice);
                        this.MyMedicineTableEdit.Visibility = Visibility.Visible;
                        this.MyJianYanTableEdit.Visibility = Visibility.Collapsed;
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.化验:
                    {
                        ShowAssayAdviceDetails((CommContracts.AssayDoctorAdvice)doctorAdvice);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.检查:
                    {
                        ShowInspectAdviceDetails((CommContracts.InspectDoctorAdvice)doctorAdvice);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.治疗:
                    {
                        ShowTherapyAdviceDetails((CommContracts.TherapyDoctorAdvice)doctorAdvice);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                case CommContracts.DoctorAdviceBaseEnum.其他:
                    {
                        ShowOtherServiceAdviceDetails((CommContracts.OtherServiceDoctorAdvice)doctorAdvice);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                default:
                    break;
            }
        }

        private void ShowMedicineAdviceDetails(CommContracts.MedicineDoctorAdvice medicineDoctorAdvice)
        {
            if (medicineDoctorAdvice == null)
            {
                return;
            }

            if (medicineDoctorAdvice.MedicineDoctorAdviceDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in medicineDoctorAdvice.MedicineDoctorAdviceDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();

                CommClient.StoreRoomMedicineNum storeRoomMedicineNum = new CommClient.StoreRoomMedicineNum();
                List<CommContracts.StoreRoomMedicineNum> storeList = storeRoomMedicineNum.GetStoreFromMedicine(tem.MedicineID, tem.AllNum);

                if (storeList == null || storeList.Count <= 0)
                {
                    myDetail.StoreRoomNumID = 0;
                    myDetail.Name = tem.Medicine.Name;
                    myDetail.Specifications = tem.Medicine.Specifications;
                    myDetail.SingleDoseUnit = tem.Medicine.Unit;
                    myDetail.BatchID = "";
                    myDetail.BeforeOutNum = 0;
                    myDetail.SingleDose = tem.AllNum;
                    myDetail.SellPrice = tem.Medicine.SellPrice;
                    myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                    myDetail.Rebate = 100;
                    myDetail.Illustration = tem.Remarks;
                    list.Add(myDetail);
                }
                else
                {
                    if (storeList.Count > 0)
                    {
                        int nIndex = storeList.Count - 1;  // 取最后一个索引
                        int nLastNum = tem.AllNum;
                        foreach (var store in storeList)
                        {
                            myDetail.StoreRoomNumID = store.ID;
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
                            myDetail.Illustration = tem.Remarks;

                            list.Add(myDetail);

                            nIndex--;
                            nLastNum -= myDetail.SingleDose;
                        }
                    }
                }
            }
            this.MyMedicineTableEdit.SetAllDetails(list);
            this.MyMedicineTableEdit.IsEnabled = true;
        }

        private void ShowMaterialAdviceDetails(CommContracts.MaterialDoctorAdvice materialDoctorAdvice)
        {
            if (materialDoctorAdvice == null)
            {
                return;
            }

            if (materialDoctorAdvice.MaterialDoctorAdviceDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in materialDoctorAdvice.MaterialDoctorAdviceDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();

                CommClient.StoreRoomMaterialNum storeRoomMaterialNum = new CommClient.StoreRoomMaterialNum();
                List<CommContracts.StoreRoomMaterialNum> storeList = storeRoomMaterialNum.GetStoreFromMaterial(tem.MaterialID, tem.AllNum);

                if (storeList == null || storeList.Count <= 0)
                {
                    myDetail.StoreRoomNumID = 0;
                    myDetail.Name = tem.Material.Name;
                    myDetail.Specifications = tem.Material.Specifications;
                    myDetail.SingleDoseUnit = tem.Material.Unit;
                    myDetail.BatchID = "";
                    myDetail.BeforeOutNum = 0;
                    myDetail.SingleDose = tem.AllNum;
                    myDetail.SellPrice = tem.Material.SellPrice;
                    myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                    myDetail.Rebate = 100;
                    myDetail.Illustration = tem.Remarks;
                    list.Add(myDetail);
                }
                else
                {
                    if (storeList.Count > 0)
                    {
                        int nIndex = storeList.Count - 1;  // 取最后一个索引
                        int nLastNum = tem.AllNum;
                        foreach (var store in storeList)
                        {
                            myDetail.StoreRoomNumID = store.ID;
                            myDetail.Name = tem.Material.Name;
                            myDetail.Specifications = tem.Material.Specifications;
                            myDetail.SingleDoseUnit = tem.Material.Unit;
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

                            myDetail.SellPrice = tem.Material.SellPrice;
                            myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                            myDetail.Rebate = 100;
                            myDetail.Illustration = tem.Remarks;

                            list.Add(myDetail);

                            nIndex--;
                            nLastNum -= myDetail.SingleDose;
                        }
                    }
                }
            }
            this.MyMedicineTableEdit.SetAllDetails(list);
            this.MyMedicineTableEdit.IsEnabled = true;
        }

        private void ShowAssayAdviceDetails(CommContracts.AssayDoctorAdvice assayDoctorAdvice)
        {
            if (assayDoctorAdvice == null)
            {
                return;
            }

            if (assayDoctorAdvice.AssayDoctorAdviceDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in assayDoctorAdvice.AssayDoctorAdviceDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();

                myDetail.ID = tem.Assay.ID;
                myDetail.Name = tem.Assay.Name;
                myDetail.SingleDoseUnit = tem.Assay.Unit;
                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.Assay.Price;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = 100;
                myDetail.Illustration = tem.Remarks;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = true;
        }

        private void ShowInspectAdviceDetails(CommContracts.InspectDoctorAdvice inspectDoctorAdvice)
        {
            if (inspectDoctorAdvice == null)
            {
                return;
            }

            if (inspectDoctorAdvice.InspectDoctorAdviceDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in inspectDoctorAdvice.InspectDoctorAdviceDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();

                myDetail.ID = tem.Inspect.ID;
                myDetail.Name = tem.Inspect.Name;
                myDetail.SingleDoseUnit = tem.Inspect.Unit;
                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.Inspect.Price;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = 100;
                myDetail.Illustration = tem.Remarks;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = true;
        }


        private void ShowTherapyAdviceDetails(CommContracts.TherapyDoctorAdvice therapyDoctorAdvice)
        {
            if (therapyDoctorAdvice == null)
            {
                return;
            }

            if (therapyDoctorAdvice.TherapyDoctorAdviceDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in therapyDoctorAdvice.TherapyDoctorAdviceDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();

                myDetail.ID = tem.Therapy.ID;
                myDetail.Name = tem.Therapy.Name;
                myDetail.SingleDoseUnit = tem.Therapy.Unit;
                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.Therapy.Price;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = 100;
                myDetail.Illustration = tem.Remarks;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = true;
        }


        private void ShowOtherServiceAdviceDetails(CommContracts.OtherServiceDoctorAdvice otherServiceDoctorAdvice)
        {
            if (otherServiceDoctorAdvice == null)
            {
                return;
            }

            if (otherServiceDoctorAdvice.OtherServiceDoctorAdviceDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in otherServiceDoctorAdvice.OtherServiceDoctorAdviceDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();

                myDetail.ID = tem.OtherService.ID;
                myDetail.Name = tem.OtherService.Name;
                myDetail.SingleDoseUnit = tem.OtherService.Unit;
                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.OtherService.Price;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = 100;
                myDetail.Illustration = tem.Remarks;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = true;
        }

        private bool Check()
        {
            List<MyDetail> list = MyMedicineTableEdit.GetAllDetails();
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

        private void ShowMedicineChargeDetails(CommContracts.MedicineCharge medicineCharge)
        {
            if (medicineCharge == null)
            {
                return;
            }

            if (medicineCharge.MedicineChargeDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in medicineCharge.MedicineChargeDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();
                myDetail.StoreRoomNumID = tem.StoreRoomMedicineNumID;
                if (tem.StoreRoomMedicineNum != null)
                {
                    if (tem.StoreRoomMedicineNum.Medicine != null)
                    {
                        myDetail.Name = tem.StoreRoomMedicineNum.Medicine.Name;
                        myDetail.Specifications = tem.StoreRoomMedicineNum.Medicine.Specifications;
                        myDetail.SingleDoseUnit = tem.StoreRoomMedicineNum.Medicine.Unit;
                        myDetail.BatchID = tem.StoreRoomMedicineNum.Batch;
                        myDetail.BeforeOutNum = tem.StoreRoomMedicineNum.Num;
                    }
                }

                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.SellPrice;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = tem.Rebate;
                list.Add(myDetail);
            }
            this.MyMedicineTableEdit.SetAllDetails(list);
            this.MyMedicineTableEdit.IsEnabled = false;
        }
        private void ShowMaterialChargeDetails(CommContracts.MaterialCharge MaterialCharge)
        {
            if (MaterialCharge == null)
            {
                return;
            }

            if (MaterialCharge.MaterialChargeDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in MaterialCharge.MaterialChargeDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();
                myDetail.StoreRoomNumID = tem.StoreRoomMaterialNumID;
                if (tem.StoreRoomMaterialNum != null)
                {
                    if (tem.StoreRoomMaterialNum.MaterialItem != null)
                    {
                        myDetail.Name = tem.StoreRoomMaterialNum.MaterialItem.Name;
                        myDetail.Specifications = tem.StoreRoomMaterialNum.MaterialItem.Specifications;
                        myDetail.SingleDoseUnit = tem.StoreRoomMaterialNum.MaterialItem.Unit;
                        myDetail.BatchID = tem.StoreRoomMaterialNum.Batch;
                        myDetail.BeforeOutNum = tem.StoreRoomMaterialNum.Num;
                    }
                }

                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.SellPrice;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = tem.Rebate;
                list.Add(myDetail);
            }
            this.MyMedicineTableEdit.SetAllDetails(list);
            this.MyMedicineTableEdit.IsEnabled = false;
        }
        private void ShowTherapyChargeDetails(CommContracts.TherapyCharge therapyCharge)
        {
            if (therapyCharge == null)
            {
                return;
            }

            if (therapyCharge.TherapyChargeDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in therapyCharge.TherapyChargeDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();
                myDetail.ID = tem.TherapyID;
                if (tem.Therapy != null)
                {
                    myDetail.Name = tem.Therapy.Name;
                    myDetail.SingleDoseUnit = tem.Therapy.Unit;
                }

                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.SellPrice;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = tem.Rebate;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = false;
        }
        private void ShowAssayChargeDetails(CommContracts.AssayCharge assayCharge)
        {
            if (assayCharge == null)
            {
                return;
            }

            if (assayCharge.AssayChargeDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in assayCharge.AssayChargeDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();
                myDetail.ID = tem.AssayID;
                if (tem.Assay != null)
                {
                    myDetail.Name = tem.Assay.Name;
                    myDetail.SingleDoseUnit = tem.Assay.Unit;
                }

                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.SellPrice;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = tem.Rebate;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = false;
        }
        private void ShowInspectChargeDetails(CommContracts.InspectCharge inspectCharge)
        {
            if (inspectCharge == null)
            {
                return;
            }

            if (inspectCharge.InspectChargeDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in inspectCharge.InspectChargeDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();
                myDetail.ID = tem.InspectID;
                if (tem.Inspect != null)
                {
                    myDetail.Name = tem.Inspect.Name;
                    myDetail.SingleDoseUnit = tem.Inspect.Unit;
                }

                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.SellPrice;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = tem.Rebate;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = false;
        }

        private void ShowOtherServiceChargeDetails(CommContracts.OtherServiceCharge otherServiceCharge)
        {
            if (otherServiceCharge == null)
            {
                return;
            }

            if (otherServiceCharge.OtherServiceChargeDetails == null)
            {
                return;
            }

            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in otherServiceCharge.OtherServiceChargeDetails)
            {
                if (tem == null)
                    continue;
                MyDetail myDetail = new MyDetail();
                myDetail.ID = tem.OtherServiceID;
                if (tem.OtherService != null)
                {
                    myDetail.Name = tem.OtherService.Name;
                    myDetail.SingleDoseUnit = tem.OtherService.Unit;
                }

                myDetail.SingleDose = tem.AllNum;
                myDetail.SellPrice = tem.SellPrice;
                myDetail.Total = Math.Round(myDetail.SellPrice * myDetail.SingleDose, 2);
                myDetail.Rebate = tem.Rebate;
                list.Add(myDetail);
            }
            this.MyJianYanTableEdit.SetAllDetails(list);
            this.MyJianYanTableEdit.IsEnabled = false;
        }

        private void AllPayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.MyMedicineTableEdit.ClearAllDetails();
            var charge = this.AllPayList.SelectedItem as CommContracts.ChargeBase;
            if (charge == null)
                return;

            switch (charge.ChargeEnum)
            {
                case CommContracts.ChargeEnum.处方单:
                    {
                        ShowMedicineChargeDetails((CommContracts.MedicineCharge)charge);
                        this.MyMedicineTableEdit.Visibility = Visibility.Visible;
                        this.MyJianYanTableEdit.Visibility = Visibility.Collapsed;
                        break;
                    }
                case CommContracts.ChargeEnum.物资材料单:
                    {
                        ShowMaterialChargeDetails((CommContracts.MaterialCharge)charge);
                        this.MyMedicineTableEdit.Visibility = Visibility.Visible;
                        this.MyJianYanTableEdit.Visibility = Visibility.Collapsed;
                        break;
                    }
                case CommContracts.ChargeEnum.治疗单:
                    {
                        ShowTherapyChargeDetails((CommContracts.TherapyCharge)charge);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                case CommContracts.ChargeEnum.化验申请:
                    {
                        ShowAssayChargeDetails((CommContracts.AssayCharge)charge);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                case CommContracts.ChargeEnum.检查申请:
                    {
                        ShowInspectChargeDetails((CommContracts.InspectCharge)charge);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                case CommContracts.ChargeEnum.其他:
                    {
                        ShowOtherServiceChargeDetails((CommContracts.OtherServiceCharge)charge);
                        this.MyMedicineTableEdit.Visibility = Visibility.Collapsed;
                        this.MyJianYanTableEdit.Visibility = Visibility.Visible;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
