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
using HISGUISetLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUISetLib.ViewModels
{
    [Export]
    [Export("HISGUISetVM", typeof(HISGUIVMBase))]
    class HISGUISetVM : HISGUIVMBase
    {
        // 显示费用管理界面
        public void SetWorkManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "SetWorkView");
        }


        // 得到所有的部门
        public List<CommContracts.Department> GetFindAllDepartment(string strName = "")
        {
            CommClient.Department myd = new CommClient.Department();

            List<CommContracts.Department> list = new List<CommContracts.Department>();
            list = myd.getALLDepartment(strName);
            return list;
        }

        // 删除科室
        public bool DeleteDepartment(int departmentID)
        {
            CommClient.Department myd = new CommClient.Department();
            if (myd.DeleteDepartment(departmentID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的职位
        public List<CommContracts.Job> GetAllJob(string strName = "")
        {
            CommClient.Job myd = new CommClient.Job();

            List<CommContracts.Job> list = new List<CommContracts.Job>();
            list = myd.GetAllJob(strName);
            return list;
        }

        // 删除职位
        public bool DeleteJob(int jobID)
        {
            CommClient.Job myd = new CommClient.Job();
            if (myd.DeleteJob(jobID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的库房
        public List<CommContracts.StoreRoom> GetAllStoreRoom(string strName = "")
        {
            CommClient.StoreRoom myd = new CommClient.StoreRoom();

            List<CommContracts.StoreRoom> list = new List<CommContracts.StoreRoom>();
            list = myd.GetAllStoreRoom(strName);
            return list;
        }

        // 删除库房
        public bool DeleteStoreRoom(int storeRoomID)
        {
            CommClient.StoreRoom myd = new CommClient.StoreRoom();
            if (myd.DeleteStoreRoom(storeRoomID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的供应商
        public List<CommContracts.Supplier> GetAllSupplier(string strName = "")
        {
            CommClient.Supplier myd = new CommClient.Supplier();

            List<CommContracts.Supplier> list = new List<CommContracts.Supplier>();
            list = myd.GetAllSuppliers(strName);
            return list;
        }

        // 删除供应商
        public bool DeleteSupplier(int supplierID)
        {
            CommClient.Supplier myd = new CommClient.Supplier();
            if (myd.DeleteSupplier(supplierID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的病床
        public List<CommContracts.SickRoom> GetAllSickRoom(string strName = "")
        {
            CommClient.SickRoom myd = new CommClient.SickRoom();

            List<CommContracts.SickRoom> list = new List<CommContracts.SickRoom>();
            list = myd.GetAllSickRoom(strName);
            return list;
        }

        // 删除供病床
        public bool DeleteSickRoom(int sickRoomID)
        {
            CommClient.SickRoom myd = new CommClient.SickRoom();
            if (myd.DeleteSickRoom(sickRoomID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的病床
        public List<CommContracts.SickBed> GetAllSickBed(string strName = "")
        {
            CommClient.SickBed myd = new CommClient.SickBed();

            List<CommContracts.SickBed> list = new List<CommContracts.SickBed>();
            list = myd.GetAllSickBed(strName);
            return list;
        }

        // 删除供病床
        public bool DeleteSickBed(int sickRoomID)
        {
            CommClient.SickBed myd = new CommClient.SickBed();
            if (myd.DeleteSickBed(sickRoomID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的人员
        public List<CommContracts.Employee> GetAllEmployee(string strName = "")
        {
            CommClient.Employee myd = new CommClient.Employee();

            List<CommContracts.Employee> list = new List<CommContracts.Employee>();
            list = myd.GetAllEmployee(strName);
            return list;
        }

        // 删除供人员
        public bool DeleteEmployee(int employeeID)
        {
            CommClient.Employee myd = new CommClient.Employee();
            if (myd.DeleteEmployee(employeeID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的值班时段
        public List<CommContracts.Shift> GetAllShift(string strName = "")
        {
            CommClient.Shift myd = new CommClient.Shift();

            List<CommContracts.Shift> list = new List<CommContracts.Shift>();
            list = myd.GetAllShift(strName);
            return list;
        }

        // 删除供值班时段
        public bool DeleteShift(int ShiftID)
        {
            CommClient.Shift myd = new CommClient.Shift();
            if (myd.DeleteShift(ShiftID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的值班类别
        public List<CommContracts.WorkType> GetAllWorkType(string strName = "")
        {
            CommClient.WorkType myd = new CommClient.WorkType();

            List<CommContracts.WorkType> list = new List<CommContracts.WorkType>();
            list = myd.GetAllWorkType(strName);
            return list;
        }

        // 删除供值班类别
        public bool DeleteWorkType(int WorkTypeID)
        {
            CommClient.WorkType myd = new CommClient.WorkType();
            if (myd.DeleteWorkType(WorkTypeID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的药品
        public List<CommContracts.Medicine> GetAllMedicine(string strName = "")
        {
            CommClient.Medicine myd = new CommClient.Medicine();

            List<CommContracts.Medicine> list = new List<CommContracts.Medicine>();
            list = myd.GetAllMedicine(strName);
            return list;
        }

        // 删除供药品
        public bool DeleteMedicine(int medicineID)
        {
            CommClient.Medicine myd = new CommClient.Medicine();
            if (myd.DeleteMedicine(medicineID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的物资
        public List<CommContracts.MaterialItem> GetAllMaterial(string strName = "")
        {
            CommClient.MaterialItem myd = new CommClient.MaterialItem();

            List<CommContracts.MaterialItem> list = new List<CommContracts.MaterialItem>();
            list = myd.GetAllMaterialItem(strName);
            return list;
        }

        // 删除供物资
        public bool DeleteMaterial(int materialID)
        {
            CommClient.MaterialItem myd = new CommClient.MaterialItem();
            if (myd.DeleteMaterial(materialID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的检查项目
        public List<CommContracts.InspectItem> GetAllInspect(string strName = "")
        {
            CommClient.InspectItem myd = new CommClient.InspectItem();

            List<CommContracts.InspectItem> list = new List<CommContracts.InspectItem>();
            list = myd.GetAllInspectItem(strName);
            return list;
        }

        // 删除供检查项目
        public bool DeleteInspect(int inspectID)
        {
            CommClient.InspectItem myd = new CommClient.InspectItem();
            if (myd.DeleteInspectItem(inspectID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的治疗项目
        public List<CommContracts.TherapyItem> GetAllTherapyItem(string strName = "")
        {
            CommClient.TherapyItem myd = new CommClient.TherapyItem();

            List<CommContracts.TherapyItem> list = new List<CommContracts.TherapyItem>();
            list = myd.GetAllTherapyItem(strName);
            return list;
        }

        // 删除供治疗项目
        public bool DeleteTherapyItem(int therapyItemID)
        {
            CommClient.TherapyItem myd = new CommClient.TherapyItem();
            if (myd.DeleteTherapyItem(therapyItemID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的化验项目
        public List<CommContracts.AssayItem> GetAllAssayItem(string strName = "")
        {
            CommClient.AssayItem myd = new CommClient.AssayItem();

            List<CommContracts.AssayItem> list = new List<CommContracts.AssayItem>();
            list = myd.GetAllAssayItem(strName);
            return list;
        }

        // 删除供化验项目
        public bool DeleteAssayItem(int AssayItemID)
        {
            CommClient.AssayItem myd = new CommClient.AssayItem();
            if (myd.DeleteAssayItem(AssayItemID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的其他服务项目
        public List<CommContracts.OtherServiceItem> GetAllOtherServiceItem(string strName = "")
        {
            CommClient.OtherServiceItem myd = new CommClient.OtherServiceItem();

            List<CommContracts.OtherServiceItem> list = new List<CommContracts.OtherServiceItem>();
            list = myd.GetAllOtherServiceItem(strName);
            return list;
        }

        // 删除供其他服务项目
        public bool DeleteOtherServiceItem(int OtherServiceItemID)
        {
            CommClient.OtherServiceItem myd = new CommClient.OtherServiceItem();
            if (myd.DeleteOtherServiceItem(OtherServiceItemID))
            {
                return true;
            }

            return false;
        }

        //// 得到所有的号源种类
        //public List<CommContracts.SignalType> GetAllSignalItem(string strName = "")
        //{
        //    CommClient.SignalItem myd = new CommClient.SignalItem();

        //    List<CommContracts.SignalType> list = new List<CommContracts.SignalType>();
        //    list = myd.GetAllSignalItem(strName);
        //    return list;
        //}

        //// 删除供号源种类
        //public bool DeleteSignalItem(int SignalItemID)
        //{
        //    CommClient.SignalItem myd = new CommClient.SignalItem();
        //    if (myd.DeleteSignalItem(SignalItemID))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        // 得到所有的患者
        public List<CommContracts.Patient> GetAllPatient(string strName = "")
        {
            CommClient.Patient myd = new CommClient.Patient();

            List<CommContracts.Patient> list = new List<CommContracts.Patient>();
            list = myd.GetAllPatient(strName);
            return list;
        }

        // 删除供患者
        public bool DeletePatient(int PatientID)
        {
            CommClient.Patient myd = new CommClient.Patient();
            if (myd.DeletePatient(PatientID))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 当前操作的就诊时间段
        /// </summary>
        #region CurrentClinicVistTime
        public static readonly DependencyProperty CurrentClinicVistTimeProperty = DependencyProperty.Register(
            "CurrentClinicVistTime", typeof(CommContracts.SignalTime), typeof(HISGUISetVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.SignalTime CurrentClinicVistTime
        {
            get { return (CommContracts.SignalTime)GetValue(CurrentClinicVistTimeProperty); }
            set { SetValue(CurrentClinicVistTimeProperty, value); }
        }
        #endregion

        ///// <summary>
        ///// 当前操作的号别
        ///// </summary>
        //#region CurrentSignalItem
        //public static readonly DependencyProperty CurrentSignalItemProperty = DependencyProperty.Register(
        //    "CurrentSignalItem", typeof(CommContracts.SignalType), typeof(HISGUISetVM), new PropertyMetadata((sender, e) => { }));

        //public CommContracts.SignalType CurrentSignalItem
        //{
        //    get { return (CommContracts.SignalType)GetValue(CurrentSignalItemProperty); }
        //    set { SetValue(CurrentSignalItemProperty, value); }
        //}
        //#endregion

        /// <summary>
        /// 当前操作的放号渠道
        /// </summary>
        #region CurrentRegistrationDitch
        public static readonly DependencyProperty CurrentRegistrationDitchProperty = DependencyProperty.Register(
            "CurrentRegistrationDitch", typeof(CommContracts.RegistrationDitch), typeof(HISGUISetVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.RegistrationDitch CurrentRegistrationDitch
        {
            get { return (CommContracts.RegistrationDitch)GetValue(CurrentRegistrationDitchProperty); }
            set { SetValue(CurrentRegistrationDitchProperty, value); }
        }
        #endregion
    }
}
