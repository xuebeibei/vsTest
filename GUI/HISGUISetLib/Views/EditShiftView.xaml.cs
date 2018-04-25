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
using HISGUISetLib.ViewModels;
using System.Data;
using HISGUICore.MyContorls;
using Microsoft.Win32;

namespace HISGUISetLib.Views
{
    [Export]
    [Export("EditShiftView", typeof(EditShiftView))]
    public partial class EditShiftView : HISGUIViewBase
    {
        private bool bIsEdit;
        private CommContracts.Shift m_Shift;
        public EditShiftView(CommContracts.Shift Shift = null)
        {
            InitializeComponent();
            
            bIsEdit = false;
            if (Shift != null)
            {
                this.m_Shift = Shift;
                this.NameEdit.Text = Shift.Name;
                this.StartTimeContorl.SetMyValue(Shift.StartTime);
                this.EndTimeContorl.SetMyValue(Shift.EndTime);
                bIsEdit = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameEdit.Text.Trim()))
            {
                return;
            }

            string strStartTime = this.StartTimeContorl.GetMyValue();
            string strEndTime = this.EndTimeContorl.GetMyValue();


            if(bIsEdit)
            {
                m_Shift.Name = this.NameEdit.Text;
                m_Shift.StartTime = strStartTime;
                m_Shift.EndTime = strEndTime;

                CommClient.Shift shiftClient = new CommClient.Shift();
                if (shiftClient.UpdateShift(m_Shift))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                CommContracts.Shift shift = new CommContracts.Shift();
                shift.Name = this.NameEdit.Text;
                shift.StartTime = strStartTime;
                shift.EndTime = strEndTime;

                CommClient.Shift shiftClient = new CommClient.Shift();
                if (shiftClient.SaveShift(shift))
                {
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
            }
            
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).DialogResult = false;
            (this.Parent as Window).Close();
        }
    }
}
