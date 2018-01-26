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
    [Export("HISGUINurseVM", typeof(HISGUIVMBase))]
    class HISGUINurseVM : HISGUIVMBase
    {
        public override void RegisterCommands()
        {
            base.RegisterCommands();
        }

        //显示分诊界面
        public void TriageManage()
        {
            this.RegionManager.RequestNavigate("DownRegion", "NurseWorkView");
        }

        // 查找某个患者最后一次挂号情况
        public CommContracts.Registration ReadLastRegistration(int PatientID, DateTime? DateTime = null)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.ReadLastRegistration(PatientID, DateTime);
        }

        // 更新挂号单
        public bool UpdateRegistration(CommContracts.Registration registration)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.UpdateRegistration(registration);
        }

        // 得到某一天所有的号源
        public List<CommContracts.SignalSource> GetOneDaySignalSourceList(DateTime date)
        {
            CommClient.SignalSource myd = new CommClient.SignalSource();
            return myd.GetSignalSourceList(0, 0, date, date);
        }

        // 得到某一天的所有到诊患者
        public List<CommContracts.Registration> GetOneDayRegistrationList(DateTime date)
        {
            CommClient.Registration myd = new CommClient.Registration();
            return myd.GetDepartmentRegistrationList(0, 0, date, date);
        }

    }
}
