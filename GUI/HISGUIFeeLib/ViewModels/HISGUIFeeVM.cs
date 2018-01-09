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

        // 当前住院患者的住院号ID
        #region CurrentInHospitalID
        public static readonly DependencyProperty CurrentInHospitalIDProperty = DependencyProperty.Register(
            "CurrentInHospitalID", typeof(int), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public int CurrentInHospitalID
        {
            get { return (int)GetValue(CurrentInHospitalIDProperty); }
            set { SetValue(CurrentInHospitalIDProperty, value); }
        }

        #endregion

        // 当前医生收费的挂号单ID
        #region CurrentRegistrationID
        public static readonly DependencyProperty CurrentRegistrationIDProperty = DependencyProperty.Register(
            "CurrentRegistrationID", typeof(int), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public int CurrentRegistrationID
        {
            get { return (int)GetValue(CurrentRegistrationIDProperty); }
            set { SetValue(CurrentRegistrationIDProperty, value); }
        }

        #endregion

        // 当前是门诊还是住院收费
        #region IsClinicOrInHospital
        public static readonly DependencyProperty IsClinicOrInHospitalProperty = DependencyProperty.Register(
            "IsClinicOrInHospital", typeof(bool), typeof(HISGUIFeeVM), new PropertyMetadata((sender, e) => { }));

        public bool IsClinicOrInHospital
        {
            get { return (bool)GetValue(IsClinicOrInHospitalProperty); }
            set { SetValue(IsClinicOrInHospitalProperty, value); }
        }

        #endregion
    }
}
