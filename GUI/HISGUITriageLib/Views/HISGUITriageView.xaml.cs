using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.ServiceLocation;
using Prism.Regions;
using HISGUICore;
using HISGUITriageLib.ViewModels;
using System.Data;


namespace HISGUITriageLib.Views
{
    [Export]
    [Export("HISGUITriageView", typeof(HISGUITriageView))]
    public partial class HISGUITriageView : HISGUIViewBase
    {
        public HISGUITriageView()
        {
            InitializeComponent();
            // 得到所有的待分诊患者列表
            CommClient.Registration registration = new CommClient.Registration();

            CommContracts.Department department = new CommContracts.Department();
            department.ID = 1;
            department.Name = "外科";
            department.IsDoctorDepartment = true;

            CommContracts.SignalSource signalSource = new CommContracts.SignalSource();
            signalSource.AddMaxNum = 20;
            signalSource.Explain = "";
            signalSource.GetDepartment = department;
            signalSource.HasUsedNum = 2;
            signalSource.ID = 1;
            signalSource.VistTime = new DateTime(2017, 11, 23);
            signalSource.SignalType = 1;
            signalSource.Specialist = 3;

            CommContracts.Patient patient = new CommContracts.Patient();
            patient.Name = "测试患者1";
            patient.BirthDay = new DateTime(1991, 3, 21);
            patient.Gender = CommContracts.Patient.GenderEnum.man;
            patient.Volk = CommContracts.Patient.VolkEnum.hanzu;

            CommContracts.Registration registration1 = new CommContracts.Registration();
            registration1.Fee = 20;
            registration1.GetDateTime = DateTime.Now;
            registration1.GetPatient = patient;
            registration1.GetSignalSource = signalSource;
            registration.SetRegistration(registration1);
    

            // 实例化一个控件
            PatientMsgBox msgBox = new PatientMsgBox(registration);

            // 添加到布局中去
            this.aaa.Children.Add(msgBox);

            // 设置控件在布局中的位置
            Grid.SetRow(msgBox, 0);
            Grid.SetColumn(msgBox, 0);
        }

        [Import]
        private HISGUITriageVM ImportVM
        {
            set { this.VM = value; }
        }
    }
}
