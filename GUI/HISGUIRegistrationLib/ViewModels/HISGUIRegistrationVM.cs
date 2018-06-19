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
using HISGUIRegistrationLib;
using HISGUICore;
using System.Data;
using System.Windows.Input;
using Prism.Commands;
using CommContracts;

namespace HISGUIRegistrationLib.ViewModels
{
    [Export]
    [Export("HISGUIRegistrationVM", typeof(HISGUIVMBase))]
    class HISGUIRegistrationVM : HISGUIVMBase   
    {

        public List<CommContracts.LevelOneDepartment> GetAllLevelOneDepartment()
        {
            CommClient.LevelOneDepartment LevelOneDepartment = new CommClient.LevelOneDepartment();
            //if (IsClinicOrInHospital)
            //{
            //    if (CurrentRegistration != null)
            //        return LevelOneDepartment.getAllXiCheng(CurrentRegistration.ID)
            //    else
            //        return null;
            //}
            //else
            //{
            //    if (CurrentInHospital != null)
            //        return LevelOneDepartment.getAllInHospitalXiCheng(CurrentInHospital.ID);
            //    else
            //        return null;
            //}

            return LevelOneDepartment.GetAllLevelOneDepartment();
        }
    }
}
