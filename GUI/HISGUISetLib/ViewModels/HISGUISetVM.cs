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

        // 得到所有的用户
        public List<CommContracts.User> GetAllUser(string strName = "")
        {
            CommClient.User myd = new CommClient.User();

            List<CommContracts.User> list = new List<CommContracts.User>();
            list = myd.GetAllLoginUser(strName);
            return list;
        }

        // 删除供用户
        public bool DeleteUser(int userID)
        {
            CommClient.User myd = new CommClient.User();
            if (myd.DeleteLoginUser(userID))
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
        public bool DeleteMedicine(int userID)
        {
            CommClient.Medicine myd = new CommClient.Medicine();
            if (myd.DeleteMedicine(userID))
            {
                return true;
            }

            return false;
        }

        // 得到所有的物资
        public List<CommContracts.Material> GetAllMaterial(string strName = "")
        {
            CommClient.MaterialItem myd = new CommClient.MaterialItem();

            List<CommContracts.Material> list = new List<CommContracts.Material>();
            list = myd.GetAllMaterial(strName);
            return list;
        }

        // 删除供物资
        public bool DeleteMaterial(int userID)
        {
            CommClient.MaterialItem myd = new CommClient.MaterialItem();
            if (myd.DeleteMaterial(userID))
            {
                return true;
            }

            return false;
        }
    }
}
