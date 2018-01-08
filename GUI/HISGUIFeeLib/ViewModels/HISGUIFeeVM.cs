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
    }
}
