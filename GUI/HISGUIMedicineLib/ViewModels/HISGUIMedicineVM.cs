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

        // 得到所有供货商
        public List<CommContracts.Supplier> getAllSupplier()
        {
            CommClient.Supplier myd = new CommClient.Supplier();
            return myd.GetAllSuppliers("");
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

        // 当前界面编辑状态
        #region IsEdit
        public static readonly DependencyProperty IsEditProperty = DependencyProperty.Register(
            "IsEdit", typeof(bool), typeof(HISGUIMedicineVM), new PropertyMetadata((sender, e) => { }));

        public bool IsEdit
        {
            get { return (bool)GetValue(IsEditProperty); }
            set { SetValue(IsEditProperty, value); }
        }

        #endregion
    }
}
