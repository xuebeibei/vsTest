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
using HISGUIPatientCardLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUIPatientCardLib.ViewModels
{
    [Export]
    [Export("HISGUIPatientCardVM", typeof(HISGUIVMBase))]
    class HISGUIPatientCardVM : HISGUIVMBase
    {
        public override void RegisterCommands()
        {
            base.RegisterCommands();
        }

        //显示就诊卡界面
        public void PatientCardManageView()
        {
            this.RegionManager.RequestNavigate("DownRegion", "PatientCardManageView");
        }

        /// <summary>
        /// 保存就诊卡办理
        /// </summary>
        public bool SavePatientCardManage(CommContracts.PatientCardManage patientCardManage, ref string ErrorMsg)
        {
            CommClient.PatientCardManage manage = new CommClient.PatientCardManage();
            return manage.SavePatientCardManage(patientCardManage, ref ErrorMsg);
        }
        
        /// <summary>
        /// 更新患者登记信息
        /// </summary>
        public bool UpdatePatientMsg(CommContracts.Patient patient, ref string ErrorMsg)
        {
            CommClient.Patient client = new CommClient.Patient();
            return client.UpdatePatient(patient, ref ErrorMsg);
        }

        // 当前住院患者的住院号
        #region CurrentPatient
        public static readonly DependencyProperty CurrentInPatientProperty = DependencyProperty.Register(
            "CurrentPatient", typeof(CommContracts.Patient), typeof(HISGUIPatientCardVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.Patient CurrentPatient
        {
            get { return (CommContracts.Patient)GetValue(CurrentInPatientProperty); }
            set { SetValue(CurrentInPatientProperty, value); }
        }

        #endregion

        // 当前住院患者的住院号
        #region PatientCardManage
        public static readonly DependencyProperty PatientCardManageProperty = DependencyProperty.Register(
            "PatientCardManage", typeof(CommContracts.PatientCardManage), typeof(HISGUIPatientCardVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.PatientCardManage PatientCardManage
        {
            get { return (CommContracts.PatientCardManage)GetValue(PatientCardManageProperty); }
            set { SetValue(PatientCardManageProperty, value); }
        }

        #endregion
    }
}
