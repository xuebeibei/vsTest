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
        public void NewStock()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NewInStockView");
        }

        public bool SaveMedicineInStock(List<CommContracts.MedicineInStoreDetail> list, bool bIsAutoCheck = false)
        {
            CommClient.MedicineInStore recipe = new CommClient.MedicineInStore();
            CommContracts.MedicineInStore medicineInStore = new CommContracts.MedicineInStore();
            medicineInStore.NO = "001";
            medicineInStore.OperateTime = DateTime.Now;
            medicineInStore.OperateUserID = 1;
            medicineInStore.SumOfMoney = 100;
            medicineInStore.FromSupplierID = 1;
            medicineInStore.ToStoreID = 1;
            medicineInStore.ReCheckUserID = 1;

            medicineInStore.MedicineInStoreDetails = list;

            if (recipe.SaveMedicineInStock(medicineInStore))
                return true;

            return false;
        }
    }
}
