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
using HISGUITriageLib;
using HISGUICore;
using System.Data;

namespace HISGUITriageLib.ViewModels
{
    [Export]
    [Export("HISGUITriageVM", typeof(HISGUIVMBase))]
    class HISGUITriageVM : HISGUIVMBase
    {
        public Dictionary<int, string> GetAllUnTriagePatient()
        {
            CommClient.Registration myd = new CommClient.Registration();
            //myd.getAllRegistration();

            //// 得到所有的待分诊患者列表
            //CommClient.Registration registration = new CommClient.Registration();

            //CommContracts.Department department = new CommContracts.Department();
            //department.ID = 1;
            //department.Name = "外科";
            //department.IsDoctorDepartment = true;

            //CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
            //signalSource.AddMaxNum = 20;
            //signalSource.Explain = "";
            //signalSource.GetDepartment = department;
            //signalSource.HasUsedNum = 2;
            //signalSource.ID = 1;
            //signalSource.VistTime = new DateTime(2017, 11, 23);
            //signalSource.SignalType = 1;
            //signalSource.Specialist = 3;

            //CommContracts.Patient patient = new CommContracts.Patient();
            //patient.Name = "测试患者1";
            //patient.BirthDay = new DateTime(1991, 3, 21);
            //patient.Gender = CommContracts.Patient.GenderEnum.man;
            //patient.Volk = CommContracts.Patient.VolkEnum.hanzu;

            //CommContracts.Registration registration1 = new CommContracts.Registration();
            //registration1.Fee = 20;
            //registration1.GetDateTime = DateTime.Now;
            //registration1.GetPatient = patient;
            //registration1.GetSignalSource = signalSource;
            //registration.SetRegistration(registration1);

            Dictionary<int, string> list = new Dictionary<int, string>();
            //list.Add(registration);
            list = myd.getAllRegistration();

            return list;
        }

        public List<CommContracts.Employee> getAllDoctor()
        {
            List<CommContracts.Employee> list = new List<CommContracts.Employee>();

            CommClient.Employee myd = new CommClient.Employee();
            list = myd.getAllDoctor();
            return list;
        }
    }
}
