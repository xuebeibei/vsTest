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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HISGUICore.MyContorls
{
    public class Doctor
    {
        public Doctor()
        {

        }
        public Doctor(int id, string name, string department)
        {
            DoctorId = id;
            DoctorName = name;
            DoctorDepartment = department;
        }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorDepartment { get; set; }
    }
    /// <summary>
    /// DoctorFind.xaml 的交互逻辑
    /// </summary>
    public partial class DoctorFind : UserControl
    {
        
        public DoctorFind()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Doctor> signalList = new List<Doctor>();
            signalList.Add(new Doctor(1, "aa", "bb"));

            //CommClient.Employee myd = new CommClient.Employee();
            //// 得到所有有效号源
            //List<CommContracts.Employee> listOfSignalSource = myd.getAllDoctor();


            //foreach (CommContracts.Employee sg in listOfSignalSource)
            //{
            //    Doctor temp = new Doctor();

            //    temp.DoctorId = sg.ID;
            //    temp.DoctorName = sg.Name;
            //    temp.DoctorDepartment = sg.GetDepartment.Name;

            //    signalList.Add(temp);

            //}

            this.listView1.ItemsSource = signalList;
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
