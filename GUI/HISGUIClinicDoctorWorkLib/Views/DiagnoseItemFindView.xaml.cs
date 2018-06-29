using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HISGUIClinicDoctorWorkLib.Views
{
    public partial class DiagnoseItemFindView : Window
    {
        public CommContracts.DiagnoseItem CurrentZhenDuan { get; set; }
        public DiagnoseItemFindView(string strFindText)
        {
            InitializeComponent();

            List<CommContracts.DiagnoseItem> list = new List<CommContracts.DiagnoseItem>();

            CommClient.DiagnoseItem diagnoseItemClient = new CommClient.DiagnoseItem();
            list = diagnoseItemClient.GetAllDiagnoseItem();

            var query = from u in list
                        where u.Name.StartsWith(strFindText) || u.Abbr.StartsWith(strFindText)
                        select u;

            m_list.ItemsSource = query;
        }

        private void listKeyUp(object sender, KeyEventArgs e)
        {
            var item = this.m_list.SelectedItem as CommContracts.DiagnoseItem;
            if (item == null)
                return;

            
            if (e.Key == Key.Enter)
            {
                CurrentZhenDuan = item;
                this.DialogResult = true;
                Close();
            }
        }

        private void WindowKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
