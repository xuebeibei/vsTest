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
using HISGUIClinicDoctorLib;
using HISGUICore;
using System.Data;

namespace HISGUIClinicDoctorLib.ViewModels
{
    [Export]
    [Export("HISGUIClinicDoctorVM", typeof(HISGUIVMBase))]
    class HISGUIClinicDoctorVM : HISGUIVMBase
    {
        public override void RegisterCommands()
        {
            base.RegisterCommands();
        }

        //显示分诊界面
        public void DoctorWorkManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "DoctorWorkView");
        }

        // 获得当前医生的患者
        public Dictionary<int, string> GetPatients()
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.getAllRegistration();
        }

        // 显示接诊界面
        public void ReceivingNewPatientsManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "ReceivingNewPatientsView");
        }
    }
}
