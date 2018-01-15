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
        public List<CommContracts.Department> GetFindAllDepartment()
        {
            CommClient.Department myd = new CommClient.Department();

            List<CommContracts.Department> list = new List<CommContracts.Department>();
            list = myd.getALLDepartment();
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
    }
}
