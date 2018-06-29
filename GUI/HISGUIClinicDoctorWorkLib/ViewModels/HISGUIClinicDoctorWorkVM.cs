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
using HISGUIClinicDoctorWorkLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;
using CommContracts;

namespace HISGUIClinicDoctorWorkLib.ViewModels
{
    [Export]
    [Export("HISGUIClinicDoctorWorkVM", typeof(HISGUIVMBase))]
    class HISGUIClinicDoctorWorkVM : HISGUIVMBase
    {
        public List<CommContracts.ClinicRegistration> getAllClinicRegistration()
        {
            CommClient.ClinicRegistration clinicRegistrationClient = new CommClient.ClinicRegistration();
            return clinicRegistrationClient.GetAllClinicRegistration();
        }
        public List<CommContracts.AdministrationRoute> getAllAdministrationRoute()
        {
            CommClient.AdministrationRoute AdministrationRouteClient = new CommClient.AdministrationRoute();
            return AdministrationRouteClient.GetAllAdministrationRoute();
        }

        public List<CommContracts.Frequency> getAllFrequency()
        {
            CommClient.Frequency FrequencyClient = new CommClient.Frequency();
            return FrequencyClient.GetAllFrequency();
        }

        public bool SaveClinicDoctorAdvice(CommContracts.ClinicDoctorAdvice clinicDoctorAdvice)
        {
            CommClient.ClinicDoctorAdvice clinicDoctorAdviceClient = new CommClient.ClinicDoctorAdvice();
            return clinicDoctorAdviceClient.SaveClinicDoctorAdvice(clinicDoctorAdvice);
        }
        public List<CommContracts.ClinicDoctorAdvice> getAllClinicDoctorAdvice()
        {
            CommClient.ClinicDoctorAdvice ClinicDoctorAdviceClient = new CommClient.ClinicDoctorAdvice();
            return ClinicDoctorAdviceClient.GetAllClinicDoctorAdvice();
        }


        // 当前门诊看诊的患者
        #region CurrentClinicRegistration
        public static readonly DependencyProperty ClinicRegistrationProperty = DependencyProperty.Register(
            "CurrentClinicRegistration", typeof(CommContracts.ClinicRegistration), typeof(HISGUIClinicDoctorWorkVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.ClinicRegistration CurrentClinicRegistration
        {
            get { return (CommContracts.ClinicRegistration)GetValue(ClinicRegistrationProperty); }
            set { SetValue(ClinicRegistrationProperty, value); }
        }

        #endregion


        // 当前医嘱字典项
        #region CurrentAdviceItem
        public static readonly DependencyProperty AdviceItemProperty = DependencyProperty.Register(
            "CurrentAdviceItem", typeof(CommContracts.DoctorAdviceItem), typeof(HISGUIClinicDoctorWorkVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.DoctorAdviceItem CurrentAdviceItem
        {
            get { return (CommContracts.DoctorAdviceItem)GetValue(AdviceItemProperty); }
            set { SetValue(AdviceItemProperty, value); }
        }

        #endregion

        // 当前修改的医嘱
        #region CurrentClinicDoctorAdvice
        public static readonly DependencyProperty CurrentClinicDoctorAdviceProperty = DependencyProperty.Register(
            "CurrentClinicDoctorAdvice", typeof(CommContracts.ClinicDoctorAdvice), typeof(HISGUIClinicDoctorWorkVM), new PropertyMetadata((sender, e) => { }));

        public CommContracts.ClinicDoctorAdvice CurrentClinicDoctorAdvice
        {
            get { return (CommContracts.ClinicDoctorAdvice)GetValue(CurrentClinicDoctorAdviceProperty); }
            set { SetValue(CurrentClinicDoctorAdviceProperty, value); }
        }

        #endregion

        // 挂号列表
        #region ClinicDoctorAdviceList
        public static readonly DependencyProperty ClinicDoctorAdviceListProperty = DependencyProperty.Register(
            "ClinicDoctorAdviceList", typeof(List<CommContracts.ClinicDoctorAdvice>), typeof(HISGUIClinicDoctorWorkVM), new PropertyMetadata((sender, e) => { }));

        public List<CommContracts.ClinicDoctorAdvice> ClinicDoctorAdviceList
        {
            get { return (List<CommContracts.ClinicDoctorAdvice>)GetValue(ClinicDoctorAdviceListProperty); }
            set { SetValue(ClinicDoctorAdviceListProperty, value); }
        }

        #endregion

    }
}
