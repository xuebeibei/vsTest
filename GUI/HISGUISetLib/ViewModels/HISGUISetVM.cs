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
            if(myd.DeleteDepartment(departmentID))
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
    }
}
