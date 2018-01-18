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
using HISGUINurseLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;

namespace HISGUINurseLib.ViewModels
{
    [Export]
    [Export("TriageVM", typeof(HISGUIVMBase))]
    class NurseVM : HISGUIVMBase
    {
        public ICommand SelectDoctorCommand { get; set; }
        public ICommand EditPatientMsgCommand { get; set; }
        public ICommand SelectDoctorCancelCommand { get; set; }

        private List<int> CurrentPatientList = new List<int>();

        public override void RegisterCommands()
        {
            base.RegisterCommands();
            SelectDoctorCommand = new DelegateCommand(SelectDoctor);
            EditPatientMsgCommand = new DelegateCommand(EditPatientMsg);
            SelectDoctorCancelCommand = new DelegateCommand(SelectDoctorCancel);
        }

        public void setList(List<int> list)
        {
            CurrentPatientList = list;
        }

        //展开选择医生界面
        public void SelectDoctor()
        {
            this.RegionManager.RequestNavigate("DownRegion", "SelectDoctorView");
        }

        public void EditPatientMsg()
        {
            this.RegionManager.RequestNavigate("DownRegion", "EditPatientMsgView");
        }

        public Dictionary<int, string> GetAllUnTriagePatient()
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.getAllRegistration();
        }

        public void SelectDoctorOK()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NurseWorkView");
        }

        public void SelectDoctorCancel()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NurseWorkView");
        }

        public List<CommContracts.Employee> getAllDoctor()
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            CommClient.Employee myd = new CommClient.Employee();
            list = myd.getAllDoctor();
            return list;
        }

        public bool SaveTriage(int DoctorID)
        {
            bool aa = true;
            foreach(int tem in CurrentPatientList)
            {
                CommClient.Triage myd = new CommClient.Triage();
                myd.SaveTriage(DoctorID, tem);
            }

            return aa;
        }
    }
}
