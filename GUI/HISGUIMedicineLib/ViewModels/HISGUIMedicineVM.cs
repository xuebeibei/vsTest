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

        // 显示新建入库界面
        public void ShowInStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewInStockView");
        }

        // 显示新建出库界面
        public void ShowOutStoreDetail()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewOutStockView");
        }

        // 保存药品入库单
        public bool SaveMedicineInStock(List<CommContracts.MedicineInStoreDetail> list, bool bIsAutoCheck = false)
        {
            CommClient.MedicineInStore myd = new CommClient.MedicineInStore();
            CurrentMedicineInStore.OperateUserID = 1;
            CurrentMedicineInStore.ToStoreID = 1;
            CurrentMedicineInStore.MedicineInStoreDetails = list;

            if (myd.SaveMedicineInStock(CurrentMedicineInStore))
                return true;

            return false;
        }

        // 药品入库单的审核入库
        public bool ReCheckMedicineInStore()
        {
            CommClient.StoreRoomMedicineNum myd = new CommClient.StoreRoomMedicineNum();

            if (myd.ReCheckMedicineInStore(CurrentMedicineInStore))
            {
                CommClient.MedicineInStore mInStore = new CommClient.MedicineInStore();
                CurrentMedicineInStore.ReCheckUserID = 1;
                CurrentMedicineInStore.ReCheckStatusEnum = CommContracts.ReCheckStatusEnum.已审核;

                if (mInStore.RecheckMedicineInStock(CurrentMedicineInStore))
                    return true;
            }

            return false;
        }

        // 得到所有的入库单
        public List<CommContracts.MedicineInStore> getAllMedicineInStore(int StoreID, CommContracts.
            InStoreEnum inStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            CommClient.MedicineInStore myd = new CommClient.MedicineInStore();
            return myd.getAllMedicineInStore(StoreID,inStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        // 得到所有的出库单
        public List<CommContracts.MedicineOutStore> getAllMedicineOutStore(int StoreID, CommContracts.
            OutStoreEnum outStoreEnum,
            DateTime StartInStoreTime,
            DateTime EndInStoreTime,
            string InStoreNo = "")
        {
            CommClient.MedicineOutStore myd = new CommClient.MedicineOutStore();
            return myd.getAllMedicineOutStore(StoreID, outStoreEnum, StartInStoreTime, EndInStoreTime, InStoreNo);
        }

        // 得到所有供货商
        public List<CommContracts.Supplier> getAllSupplier()
        {
            CommClient.Supplier myd = new CommClient.Supplier();
            return myd.GetAllSuppliers("");
        }

        // 得到所有库存
        public List<CommContracts.StoreRoomMedicineNum> getAllMedicineItemNum(int StoreID, 
            string ItemName,
            int SupplierID, 
            int ItemType, 
            bool IsStatusOk, 
            bool IsHasNum, 
            bool IsOverDate, 
            bool IsNoEnough)
        {
            CommClient.StoreRoomMedicineNum myd = new CommClient.StoreRoomMedicineNum();
            return myd.getAllMedicineItemNum( StoreID,ItemName, SupplierID, ItemType, IsStatusOk, IsHasNum, IsOverDate, IsNoEnough);
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
    }
}
