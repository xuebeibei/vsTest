using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using HISGUIFeeLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUIFeeLib.ViewModels
{
    [Export]
    [Export("HISGUIFeeVM", typeof(HISGUIVMBase))]
    class HISGUIFeeVM : HISGUIVMBase
    {
        // 显示费用管理界面
        public void FeeWorkManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "FeeWorkView");
        }

        // 显示患者的收费单
        public void ShowCharge()
        {
            this.RegionManager.RequestNavigate("DownRegion", "PatientChargesView");
        }

        // 得到所有需要收费的门诊患者
        public Dictionary<int, string> GetAllClinicPatients(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.GetAllClinicPatients(startDate, endDate, strFindName, HavePay);
        }

        // 得到所有需要收费的门诊患者
        public Dictionary<int, string> GetAllInHospitalChargePatient(DateTime startDate, DateTime endDate, string strFindName = "", bool HavePay = false)
        {
            CommClient.Inpatient myd = new CommClient.Inpatient();
            return myd.GetAllInHospitalChargePatient(startDate, endDate, strFindName, HavePay);
        }

        // 得到当前门诊患者的所有西成药处方
        public List<CommContracts.Recipe> GetAllXiCheng()
        {
            CommClient.Recipe recipe = new CommClient.Recipe();     // 处方
            List<CommContracts.Recipe> list = new List<CommContracts.Recipe>();
            if (IsClinicOrInHospital)
            {
                list = recipe.getAllXiCheng(this.CurrentRegistrationID);
            }
            else
            {
                list = recipe.getAllInHospitalXiCheng(this.CurrentInHospitalID);
            }
            return list;
        }

        // 得到当前门诊患者的所有中药处方
        public List<CommContracts.Recipe> GetAllZhong()
        {
            CommClient.Recipe recipe = new CommClient.Recipe();     // 处方
            List<CommContracts.Recipe> list = new List<CommContracts.Recipe>();
            if (IsClinicOrInHospital)
            {
                list = recipe.getAllZhong(this.CurrentRegistrationID);
            }
            else
            {
                list = recipe.getAllInHospitalZhong(this.CurrentInHospitalID);
            }
            return list;
        }

        // 得到当前门诊患者的所有治疗单
        public List<CommContracts.Therapy> GetAllZhiLiao()
        {
            CommClient.Therapy therapy = new CommClient.Therapy();  // 治疗

            List<CommContracts.Therapy> list = new List<CommContracts.Therapy>();
            if (IsClinicOrInHospital)
            {
                list = therapy.getAllTherapy(this.CurrentRegistrationID);
            }
            else
            {
                list = therapy.getAllInHospitalTherapy(this.CurrentInHospitalID);
            }
            return list;
        }

        // 得到当前门诊患者的所有检验申请单
        public List<CommContracts.Assay> GetAllJianYan()
        {
            CommClient.Assay assay = new CommClient.Assay();        // 化验申请

            List<CommContracts.Assay> list = new List<CommContracts.Assay>();
            if (IsClinicOrInHospital)
            {
                list = assay.getAllAssay(this.CurrentRegistrationID);
            }
            else
            {
                list = assay.getAllInHospitalAssay(this.CurrentInHospitalID);
            }
            return list;
        }

        // 得到当前门诊患者的所有检查申请单
        public List<CommContracts.Inspect> GetAllJianCha()
        {
            CommClient.Inspect inspect = new CommClient.Inspect();  // 检查申请
            
            List<CommContracts.Inspect> list = new List<CommContracts.Inspect>();
            if (IsClinicOrInHospital)
            {
                list = inspect.getAllInspect(this.CurrentRegistrationID);
            }
            else
            {
                list = inspect.getAllInHospitalInspect(this.CurrentInHospitalID);
            }
            return list;
        }

        // 得到当前门诊患者的所有材料单
        public List<CommContracts.MaterialBill> GetAllCaiLiao()
        {
            CommClient.MaterialBill materialBill = new CommClient.MaterialBill();   // 材料
            
            List<CommContracts.MaterialBill> list = new List<CommContracts.MaterialBill>();
            if (IsClinicOrInHospital)
            {
                list = materialBill.getAllMaterialBill(this.CurrentRegistrationID);
            }
            else
            {
                list = materialBill.getAllInHospitalMaterialBill(this.CurrentInHospitalID);
            }
            return list;
        }

        // 得到当前门诊患者的所其他服务单
        public List<CommContracts.OtherService> GetAllQiTa()
        {
            CommClient.OtherService otherService = new CommClient.OtherService();   // 其他

            List<CommContracts.OtherService> list = new List<CommContracts.OtherService>();
            if (IsClinicOrInHospital)
            {
                list = otherService.getAllOtherService(this.CurrentRegistrationID);
            }
            else
            {
                list = otherService.getAllInHospitalOtherService(this.CurrentInHospitalID);
            }
            return list;
        }

        // 得到当前药品的合理库存
        public List<CommContracts.StoreRoomMedicineNum> GetStoreFromMedicine(int nMedicineID, int nNum)
        {
            CommClient.StoreRoomMedicineNum storeRoomMedicineNum = new CommClient.StoreRoomMedicineNum();
            return storeRoomMedicineNum.GetStoreFromMedicine(nMedicineID, nNum);
        }

        // 当前住院患者的住院号ID
        #region CurrentInHospitalID
        public static readonly DependencyProperty CurrentInHospitalIDProperty = DependencyProperty.Register(
            "CurrentInHospitalID", typeof(int), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public int CurrentInHospitalID
        {
            get { return (int)GetValue(CurrentInHospitalIDProperty); }
            set { SetValue(CurrentInHospitalIDProperty, value); }
        }

        #endregion

        // 当前医生收费的挂号单ID
        #region CurrentRegistrationID
        public static readonly DependencyProperty CurrentRegistrationIDProperty = DependencyProperty.Register(
            "CurrentRegistrationID", typeof(int), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public int CurrentRegistrationID
        {
            get { return (int)GetValue(CurrentRegistrationIDProperty); }
            set { SetValue(CurrentRegistrationIDProperty, value); }
        }

        #endregion

        // 当前是门诊还是住院收费
        #region IsClinicOrInHospital
        public static readonly DependencyProperty IsClinicOrInHospitalProperty = DependencyProperty.Register(
            "IsClinicOrInHospital", typeof(bool), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public bool IsClinicOrInHospital
        {
            get { return (bool)GetValue(IsClinicOrInHospitalProperty); }
            set { SetValue(IsClinicOrInHospitalProperty, value); }
        }

        #endregion
    }
}
