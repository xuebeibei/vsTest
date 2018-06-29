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
    public partial class DoctorAdviceItemFindView : Window
    {
        public CommContracts.DoctorAdviceItem CurrentAdviceItem { get; set; }
        public DoctorAdviceItemFindView(string strFindText)
        {
            InitializeComponent();
            List<CommContracts.DoctorAdviceItem> list = new List<CommContracts.DoctorAdviceItem>();
            //CommClient.DoctorAdviceItem doctorAdviceItemClient = new CommClient.DoctorAdviceItem();
            //list = doctorAdviceItemClient.GetAllDoctorAdviceItem();

            list.Add(new CommContracts.DoctorAdviceItem()
            {
                ID = 1,
                doctorAdviceItemType = CommContracts.DoctorAdviceItemType.西成药品,
                Name = "克林霉素",
                Abbr = "klms",
                MinPackageName = "粒",
                MinPackageNum = 0.125M,
                MinPackageUnit = "g",
                SellPackageName = "盒",
                ScalingFactor = 12
            });


            list.Add(new CommContracts.DoctorAdviceItem()
            {
                ID = 2,
                doctorAdviceItemType = CommContracts.DoctorAdviceItemType.西成药品,
                Name = "阿莫西林",
                Abbr = "amxl",
                MinPackageName = "粒",
                MinPackageNum = 1.2M,
                MinPackageUnit = "g",
                SellPackageName = "盒",
                ScalingFactor = 12
            });


            list.Add(new CommContracts.DoctorAdviceItem()
            {
                ID = 3,
                doctorAdviceItemType = CommContracts.DoctorAdviceItemType.西成药品,
                Name = "0.9%氯化钠溶液",
                Abbr = "bfzjlhnry",
                MinPackageName = "瓶",
                MinPackageNum = 100,
                MinPackageUnit = "ml",
                SellPackageName = "瓶",
                ScalingFactor = 1
            });

            var query = from u in list
                        where u.Name.StartsWith(strFindText) || u.Abbr.StartsWith(strFindText)
                        select u;



            m_list.ItemsSource = query;
        }

        private void WindowKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void listKeyUp(object sender, KeyEventArgs e)
        {
            var item = this.m_list.SelectedItem as CommContracts.DoctorAdviceItem;
            if (item == null)
                return;


            if (e.Key == Key.Enter)
            {
                CurrentAdviceItem = item;
                this.DialogResult = true;
                Close();
            }
        }
    }
}
