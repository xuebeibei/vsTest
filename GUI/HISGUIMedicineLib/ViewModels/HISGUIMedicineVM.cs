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
using HISGUIMedicineLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUIMedicineLib.ViewModels
{
    [Export]
    [Export("HISGUIMedicineVM", typeof(HISGUIVMBase))]
    class HISGUIMedicineVM : HISGUIVMBase
    {

        //显示药品管理主界面
        public void MedicineWorkManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "MedicineWorkView");
        }

        // 显示新建药品入库界面
        public void ShowMedicineInStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewMedicineInStockView");
        }

        // 显示新建药品出库界面
        public void ShowMedicineOutStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewMedicineOutStockView");
        }

        // 显示新建药品盘存单界面
        public void ShowMedicineCheckStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewMedicineCheckStockView");
        }

        // 显示新建物资入库界面
        public void ShowMaterialInStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewMaterialInStockView");
        }

        // 显示新建物资出库界面
        public void ShowMaterialOutStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewMaterialOutStockView");
        }

        // 显示新建物资盘存单界面
        public void ShowMaterialCheckStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewMaterialCheckStockView");
        }

        // 保存药品入库单
        public bool SaveMedicineInStock(CommContracts.MedicineInStore MedicineInStore, bool bIsAutoCheck = false)
        {
            CommClient.MedicineInStore myd = new CommClient.MedicineInStore();
            return myd.SaveMedicineInStock(MedicineInStore);
        }

        // 药品入库单的审核入库
        public bool ReCheckMedicineInStore()
        {
            CommClient.StoreRoomMedicineNum myd = new CommClient.StoreRoomMedicineNum();

            if (myd.ReCheckMedicineInStore(CurrentMedicineInStore))
            {
                CommClient.MedicineInStore mInStore = new CommClient.MedicineInStore();
                CurrentMedicineInStore.ReCheckUserID = CurrentUser.ID;
                CurrentMedicineInStore.ReCheckStatusEnum = CommContracts.ReCheckStatusEnum.已审核;

                if (mInStore.RecheckMedicineInStock(CurrentMedicineInStore))
                    return true;
            }

            return false;
        }

        // 保存物资入库单
        public bool SaveMaterialInStock(CommContracts.MaterialInStore materialInStore, bool bIsAutoCheck = false)
        {
            CommClient.MaterialInStore myd = new CommClient.MaterialInStore();
            return myd.SaveMaterialInStock(materialInStore);
        }

        // 物资入库单的审核入库
        public bool ReCheckMaterialInStore()
        {
            CommClient.StoreRoomMaterialNum myd = new CommClient.StoreRoomMaterialNum();

            if (myd.ReCheckMaterialInStore(CurrentMaterialInStore))
            {
                CommClient.MaterialInStore mInStore = new CommClient.MaterialInStore();
                CurrentMaterialInStore.ReCheckUserID = CurrentUser.ID;
                CurrentMaterialInStore.ReCheckStatusEnum = CommContracts.ReCheckStatusEnum.已审核;

                if (mInStore.RecheckMaterialInStock(CurrentMaterialInStore))
                    return true;
            }

            return false;
        }

        // 保存药品出库单
        public bool SaveMedicineOutStock(CommContracts.MedicineOutStore medicineOutStore, bool bIsAutoCheck = false)
        {
            CommClient.MedicineOutStore myd = new CommClient.MedicineOutStore();
            if (myd.SaveMedicineOutStock(medicineOutStore))
                return true;

            return false;
        }

        // 药品出库单的审核出库
        public bool ReCheckMedicineOutStore()
        {
            CommClient.StoreRoomMedicineNum myd = new CommClient.StoreRoomMedicineNum();

            if (myd.RecheckMedicineOutStore(CurrentMedicineOutStore))
            {
                CommClient.MedicineOutStore mInStore = new CommClient.MedicineOutStore();
                CurrentMedicineOutStore.ReCheckUserID = CurrentUser.ID;
                CurrentMedicineOutStore.ReCheckStatusEnum = CommContracts.ReCheckStatusEnum.已审核;

                if (mInStore.RecheckMedicineOutStock(CurrentMedicineOutStore))
                    return true;
            }
            return false;
        }

        // 保存物资出库单
        public bool SaveMaterialOutStock(CommContracts.MaterialOutStore materialOutStore, bool bIsAutoCheck = false)
        {
            CommClient.MaterialOutStore myd = new CommClient.MaterialOutStore();
            if (myd.SaveMaterialOutStock(materialOutStore))
                return true;

            return false;
        }

        // 物资出库单的审核出库
        public bool ReCheckMaterialOutStore()
        {
            CommClient.StoreRoomMaterialNum myd = new CommClient.StoreRoomMaterialNum();

            if (myd.RecheckMaterialOutStore(CurrentMaterialOutStore))
            {
                CommClient.MaterialOutStore mInStore = new CommClient.MaterialOutStore();
                CurrentMaterialOutStore.ReCheckUserID = CurrentUser.ID;
                CurrentMaterialOutStore.ReCheckStatusEnum = CommContracts.ReCheckStatusEnum.已审核;

                if (mInStore.RecheckMaterialOutStock(CurrentMaterialOutStore))
                    return true;
            }
            return false;
        }


        // 保存药品盘存单
        public bool SaveMedicineCheckStock(CommContracts.MedicineCheckStore medicineCheckStore, bool bIsAutoCheck = false)
        {
            CommClient.MedicineCheckStore myd = new CommClient.MedicineCheckStore();
            if (myd.SaveMedicineCheckStock(medicineCheckStore))
                return true;

            return false;
        }

        // 保存药品盘存单的审核

        public bool ReCheckMedicineCheckStore()
        {
            CommClient.StoreRoomMedicineNum myd = new CommClient.StoreRoomMedicineNum();

            if (myd.ReCheckMedicineCheckStore(CurrentMedicineCheckStore))
            {
                CommClient.MedicineCheckStore mInStore = new CommClient.MedicineCheckStore();
                CurrentMedicineCheckStore.ReCheckUserID = CurrentUser.ID;
                CurrentMedicineCheckStore.ReCheckStatusEnum = CommContracts.ReCheckStatusEnum.已审核;

                if (mInStore.RecheckMedicineCheckStock(CurrentMedicineCheckStore))
                    return true;
            }
            return false;
        }

        // 保存物资盘存单
        public bool SaveMaterialCheckStock(CommContracts.MaterialCheckStore materialCheckStore, bool bIsAutoCheck = false)
        {
            CommClient.MaterialCheckStore myd = new CommClient.MaterialCheckStore();
            if (myd.SaveMaterialCheckStock(materialCheckStore))
                return true;

            return false;
        }

        // 保存物资盘存单的审核

        public bool ReCheckMaterialCheckStore()
        {
            CommClient.StoreRoomMaterialNum myd = new CommClient.StoreRoomMaterialNum();

            if (myd.ReCheckMaterialCheckStore(CurrentMaterialCheckStore))
            {
                CommClient.MaterialCheckStore mInStore = new CommClient.MaterialCheckStore();
                CurrentMaterialCheckStore.ReCheckUserID = CurrentUser.ID;
                CurrentMaterialCheckStore.ReCheckStatusEnum = CommContracts.ReCheckStatusEnum.已审核;

                if (mInStore.RecheckMaterialCheckStock(CurrentMaterialCheckStore))
                    return true;
            }
            return false;
        }

        // 得到所有的药品入库单
        public List<CommContracts.MedicineInStore> getAllMedicineInStore( CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.MedicineInStore myd = new CommClient.MedicineInStore();
            return myd.getAllMedicineInStore(CurrentStoreRoom.ID, inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        // 得到所有的药品出库单
        public List<CommContracts.MedicineOutStore> getAllMedicineOutStore(CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.MedicineOutStore myd = new CommClient.MedicineOutStore();
            return myd.getAllMedicineOutStore(CurrentStoreRoom.ID, outStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        // 得到所有药品盘存单
        public List<CommContracts.MedicineCheckStore> getAllMedicineCheckStore(
        DateTime StartInStoreTime,
        DateTime EndInStoreTime)
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.MedicineCheckStore myd = new CommClient.MedicineCheckStore();
            return myd.getAllMedicineCheckStore(CurrentStoreRoom.ID, StartInStoreTime, EndInStoreTime);
        }

        // 得到所有的物资入库单
        public List<CommContracts.MaterialInStore> getAllMaterialInStore(CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.MaterialInStore myd = new CommClient.MaterialInStore();
            return myd.getAllMaterialInStore(CurrentStoreRoom.ID, inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        // 得到所有的物资出库单
        public List<CommContracts.MaterialOutStore> getAllMaterialOutStore(CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.MaterialOutStore myd = new CommClient.MaterialOutStore();
            return myd.getAllMaterialOutStore(CurrentStoreRoom.ID, outStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        // 得到所有物资盘存单
        public List<CommContracts.MaterialCheckStore> getAllMaterialCheckStore(
        DateTime StartInStoreTime,
        DateTime EndInStoreTime)
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.MaterialCheckStore myd = new CommClient.MaterialCheckStore();
            return myd.getAllMaterialCheckStore(CurrentStoreRoom.ID, StartInStoreTime, EndInStoreTime);
        }

        // 得到所有供货商
        public List<CommContracts.Supplier> getAllSupplier()
        {
            CommClient.Supplier myd = new CommClient.Supplier();
            return myd.GetAllSuppliers("");
        }

        // 得到所有药品库存
        public List<CommContracts.StoreRoomMedicineNum> getAllMedicineItemNum(
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.StoreRoomMedicineNum myd = new CommClient.StoreRoomMedicineNum();
            return myd.getAllMedicineItemNum(CurrentStoreRoom.ID, ItemName, SupplierID, ItemType, IsStatusOk, IsHasNum, IsOverDate, IsNoEnough);
        }

        // 得到所有物资库存
        public List<CommContracts.StoreRoomMaterialNum> getAllMaterialItemNum(
            string ItemName,
            int SupplierID,
            int ItemType,
            bool IsStatusOk,
            bool IsHasNum,
            bool IsOverDate,
            bool IsNoEnough)
        {
            if (CurrentStoreRoom == null)
                return null;
            CommClient.StoreRoomMaterialNum myd = new CommClient.StoreRoomMaterialNum();
            return myd.getAllMaterialItemNum(CurrentStoreRoom.ID, ItemName, SupplierID, ItemType, IsStatusOk, IsHasNum, IsOverDate, IsNoEnough);
        }

        // 当前药品入库单
        #region CurrentMedicineInStore
        public static readonly DependencyProperty CurrentMedicineInStoreProperty = DependencyProperty.Register(
            "CurrentMedicineInStore", typeof(CommContracts.MedicineInStore), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MedicineInStore CurrentMedicineInStore
        {
            get { return (CommContracts.MedicineInStore)GetValue(CurrentMedicineInStoreProperty); }
            set { SetValue(CurrentMedicineInStoreProperty, value); }
        }

        #endregion

        // 当前药品出库单
        #region CurrentMedicineOutStore
        public static readonly DependencyProperty CurrentMedicineOutStoreProperty = DependencyProperty.Register(
            "CurrentMedicineOutStore", typeof(CommContracts.MedicineOutStore), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MedicineOutStore CurrentMedicineOutStore
        {
            get { return (CommContracts.MedicineOutStore)GetValue(CurrentMedicineOutStoreProperty); }
            set { SetValue(CurrentMedicineOutStoreProperty, value); }
        }

        #endregion


        // 当前药品盘存单
        #region CurrentMedicineCheckStore
        public static readonly DependencyProperty CurrentMedicineCheckStoreProperty = DependencyProperty.Register(
            "CurrentMedicineCheckStore", typeof(CommContracts.MedicineCheckStore), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MedicineCheckStore CurrentMedicineCheckStore
        {
            get { return (CommContracts.MedicineCheckStore)GetValue(CurrentMedicineCheckStoreProperty); }
            set { SetValue(CurrentMedicineCheckStoreProperty, value); }
        }

        #endregion

        // 当前物资入库单
        #region CurrentMaterialInStore
        public static readonly DependencyProperty CurrentMaterialInStoreProperty = DependencyProperty.Register(
            "CurrentMaterialInStore", typeof(CommContracts.MaterialInStore), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MaterialInStore CurrentMaterialInStore
        {
            get { return (CommContracts.MaterialInStore)GetValue(CurrentMaterialInStoreProperty); }
            set { SetValue(CurrentMaterialInStoreProperty, value); }
        }

        #endregion

        // 当前物资出库单
        #region CurrentMaterialOutStore
        public static readonly DependencyProperty CurrentMaterialOutStoreProperty = DependencyProperty.Register(
            "CurrentMaterialOutStore", typeof(CommContracts.MaterialOutStore), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MaterialOutStore CurrentMaterialOutStore
        {
            get { return (CommContracts.MaterialOutStore)GetValue(CurrentMaterialOutStoreProperty); }
            set { SetValue(CurrentMaterialOutStoreProperty, value); }
        }

        #endregion


        // 当前物资盘存单
        #region CurrentMaterialCheckStore
        public static readonly DependencyProperty CurrentMaterialCheckStoreProperty = DependencyProperty.Register(
            "CurrentMaterialCheckStore", typeof(CommContracts.MaterialCheckStore), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.MaterialCheckStore CurrentMaterialCheckStore
        {
            get { return (CommContracts.MaterialCheckStore)GetValue(CurrentMaterialCheckStoreProperty); }
            set { SetValue(CurrentMaterialCheckStoreProperty, value); }
        }

        #endregion

        // 当前界面编辑状态
        #region IsInitViewEdit
        public static readonly DependencyProperty IsInitViewEditProperty = DependencyProperty.Register(
            "IsInitViewEdit", typeof(bool), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public bool IsInitViewEdit
        {
            get { return (bool)GetValue(IsInitViewEditProperty); }
            set { SetValue(IsInitViewEditProperty, value); }
        }

        #endregion


        // 当前管理的是药品还是物资，true药品,false物资
        #region IsMedicineOrMaterial

        public static readonly DependencyProperty IsMedicineOrMaterialProperty = DependencyProperty.Register(
            "IsMedicineOrMaterial", typeof(bool), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public bool IsMedicineOrMaterial

        {
            get { return (bool)GetValue(IsMedicineOrMaterialProperty); }
            set { SetValue(IsMedicineOrMaterialProperty, value); }
        }

        #endregion

        // 当前库房
        #region CurrentStoreRoom

        public static readonly DependencyProperty CurrentStoreRoomProperty = DependencyProperty.Register(
            "CurrentStoreRoom", typeof(CommContracts.StoreRoom), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.StoreRoom CurrentStoreRoom

        {
            get { return (CommContracts.StoreRoom)GetValue(CurrentStoreRoomProperty); }
            set { SetValue(CurrentStoreRoomProperty, value); }
        }

        #endregion
    }
}
