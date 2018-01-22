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
using HISGUICore.MyContorls;
using HISGUIDoctorLib.ViewModels;
using System.Data;

namespace HISGUIDoctorLib.Views
{
    [Export]
    [Export("MedicineDoctorAdviceView", typeof(MedicineDoctorAdviceView))]
    public partial class MedicineDoctorAdviceView : HISGUIViewBase
    {
        private MyTableEdit myXiChengTableEdit;
        private MyTableEdit myZhongTableEdit;

        public MedicineDoctorAdviceView()
        {
            InitializeComponent();
            myXiChengTableEdit = new MyTableEdit(MyTableEditEnum.xichengyao);
            xiyaoPanel.Children.Add(myXiChengTableEdit);
            myZhongTableEdit = new MyTableEdit(MyTableEditEnum.zhongyao);
            zhongyaoPanel.Children.Add(myZhongTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIDoctorVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            getAllDoctorAdviceList();
            newAllDoctorAdvice();
        }

        private void SelectDrugBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CopyDoctorAdviceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MyDetail> listDetail = new List<MyDetail>();
            CommContracts.DoctorAdviceContentEnum doctorAdviceContentEnum = CommContracts.DoctorAdviceContentEnum.XiChengYao;
            if (this.tabControl.SelectedIndex == 0)
            {
                listDetail = myXiChengTableEdit.GetAllDetails();
                doctorAdviceContentEnum = CommContracts.DoctorAdviceContentEnum.XiChengYao;
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                listDetail = myZhongTableEdit.GetAllDetails();
                doctorAdviceContentEnum = CommContracts.DoctorAdviceContentEnum.ZhongYao;
            }

            List<CommContracts.MedicineDoctorAdviceDetail> list = new List<CommContracts.MedicineDoctorAdviceDetail>();
            foreach (var tem in listDetail)
            {
                CommContracts.MedicineDoctorAdviceDetail doctorAdviceDetail = new CommContracts.MedicineDoctorAdviceDetail();
                //doctorAdviceDetail.GroupNum = tem.GroupNum;
                doctorAdviceDetail.MedicineID = tem.ID;
                doctorAdviceDetail.AllNum = tem.SingleDose;
                //doctorAdviceDetail.Usage = tem.Usage;
                //doctorAdviceDetail.DDDS = tem.DDDS;
                //doctorAdviceDetail.DaysNum = tem.DaysNum;
                //doctorAdviceDetail.IntegralDose = tem.IntegralDose;
                doctorAdviceDetail.Remarks = tem.Illustration;
                list.Add(doctorAdviceDetail);
            }

            var vm = this.DataContext as HISGUIDoctorVM;
            bool? saveResult = vm?.SaveMedicineDoctorAdvice(doctorAdviceContentEnum, list);

            if (!saveResult.HasValue)
            {
                MessageBox.Show("保存失败！");
                return;
            }
            else if ((bool)saveResult.Value)
            {
                MessageBox.Show("保存成功！");
                newDoctorAdvice();
                getDoctorAdviceList();
            }
            else
            {
                MessageBox.Show("保存失败！");
                return;
            }
        }

        private void SaveTempletBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            newDoctorAdvice();
        }

        private void newDoctorAdvice()
        {
            if (this.tabControl.SelectedIndex == 0)
            {
                newXiChengYao();
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                newZhongYao();
            }
        }

        private void newAllDoctorAdvice()
        {
            newXiChengYao();
            newZhongYao();
        }

        private void newXiChengYao()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.XiChengDoctorAdviceMsg.Text = vm?.NewMedicineDoctorAdvice();
            this.myXiChengTableEdit.ClearAllDetails();
            
            this.AllXiChengList.SelectedItems.Clear();
            this.myXiChengTableEdit.IsEnabled = true;
            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void newZhongYao()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.ZhongDoctorAdviceMsg.Text = vm?.NewMedicineDoctorAdvice();
            this.myZhongTableEdit.ClearAllDetails();
            this.myZhongTableEdit.IsEnabled = true;
            this.AllZhongList.SelectedItems.Clear();

            this.SaveBtn.IsEnabled = true;
            this.DeleteBtn.IsEnabled = false;
        }

        private void getAllDoctorAdviceList()
        {
            getAllXiCheng();
            getAllZhong();
        }

        private void getDoctorAdviceList()
        {
            if (this.tabControl.SelectedIndex == 0)
            {
                getAllXiCheng();
            }
            else if (this.tabControl.SelectedIndex == 1)
            {
                getAllZhong();
            }
        }

        private void getAllXiCheng()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.AllXiChengList.ItemsSource = vm?.getAllXiCheng();

        }
        private void getAllZhong()
        {
            var vm = this.DataContext as HISGUIDoctorVM;
            this.AllZhongList.ItemsSource = vm?.getAllZhong();
        }

        private void AllXiChengList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.MedicineDoctorAdvice doctorAdvice = AllXiChengList.SelectedItem as CommContracts.MedicineDoctorAdvice;
            ShowDetails(doctorAdvice, CommContracts.DoctorAdviceContentEnum.XiChengYao);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }

        private void AllZhongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommContracts.MedicineDoctorAdvice doctorAdvice = AllZhongList.SelectedItem as CommContracts.MedicineDoctorAdvice;
            ShowDetails(doctorAdvice, CommContracts.DoctorAdviceContentEnum.ZhongYao);

            this.SaveBtn.IsEnabled = false;
            this.DeleteBtn.IsEnabled = true;
        }

        private void ShowDetails(CommContracts.MedicineDoctorAdvice doctorAdvice , CommContracts.DoctorAdviceContentEnum doctorAdviceContentEnum)
        {
            if (doctorAdvice == null)
                return;

            CommClient.Medicine myd = new CommClient.Medicine();
            CommContracts.Medicine medicine = new CommContracts.Medicine();
            List<MyDetail> list = new List<MyDetail>();
            foreach (var tem in doctorAdvice.MedicineDoctorAdviceDetails)
            {
                MyDetail doctorAdviceDetail = new MyDetail();

                //doctorAdviceDetail.GroupNum = tem.GroupNum;
                doctorAdviceDetail.ID = tem.MedicineID;
                medicine = myd.GetMedicine(tem.MedicineID);
                doctorAdviceDetail.Name = medicine.Name;
                doctorAdviceDetail.Specifications = medicine.Specifications;
                //doctorAdviceDetail.SingleDose = tem.SingleDose;
                //doctorAdviceDetail.Usage = tem.Usage;
                //doctorAdviceDetail.DDDS = tem.DDDS;
                //doctorAdviceDetail.DaysNum = tem.DaysNum;
                //doctorAdviceDetail.IntegralDose = tem.IntegralDose;
                //doctorAdviceDetail.Illustration = tem.Illustration;
                list.Add(doctorAdviceDetail);
            }

            if (doctorAdviceContentEnum == CommContracts.DoctorAdviceContentEnum.XiChengYao)
            {
                this.XiChengDoctorAdviceMsg.Text = doctorAdvice.ToString();
                myXiChengTableEdit.SetAllDetails(list);
                myXiChengTableEdit.IsEnabled = false;
            }
            else if(doctorAdviceContentEnum == CommContracts.DoctorAdviceContentEnum.ZhongYao)
            {
                this.ZhongDoctorAdviceMsg.Text = doctorAdvice.ToString();
                myZhongTableEdit.SetAllDetails(list);
                myZhongTableEdit.IsEnabled = false;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
