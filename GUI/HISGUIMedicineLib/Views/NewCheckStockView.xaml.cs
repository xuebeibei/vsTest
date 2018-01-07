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
using HISGUIMedicineLib.ViewModels;
using System.Data;

namespace HISGUIMedicineLib.Views
{
    [Export]
    [Export("NewCheckStockView", typeof(NewCheckStockView))]
    public partial class NewCheckStockView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public NewCheckStockView()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.medicineCheckStock);
            CheckPanel.Children.Add(myTableEdit);

            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            initBinding();
            initDate();
            initEnable();
            initVisible();
        }

        private void initBinding()
        {
            //var vm = this.DataContext as HISGUIMedicineVM;
        }

        private void initDate()
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            if (vm.CurrentMedicineCheckStore != null)
            {
                this.myTableEdit.ClearAllDetails();
                
                if (vm.CurrentMedicineCheckStore.MedicineCheckStoreDetails != null)
                {
                    List<MyDetail> list = new List<MyDetail>();
                    foreach (var tem in vm.CurrentMedicineCheckStore.MedicineCheckStoreDetails)
                    {
                        MyDetail myDetail = new MyDetail();
                        myDetail.ID = tem.StoreRoomMedicineNumID;
                        //myDetail.ExpirationDate = tem.ExpirationDate;
                        //myDetail.BatchID = tem.Batch;
                        myDetail.SingleDose = tem.Num;
                        //if (tem.Medicine != null)
                        //{
                        //    myDetail.SingleDoseUnit = tem.Medicine.Unit;
                        //    myDetail.Name = tem.Medicine.Name;
                        //    myDetail.Manufacturer = tem.Medicine.Manufacturer;
                        //    myDetail.Specifications = tem.Medicine.Specifications;
                        //}

                        myDetail.SellPrice = tem.SellPrice;
                        myDetail.StockPrice = tem.StorePrice;
                        myDetail.Total = tem.Num * tem.StorePrice;
                        list.Add(myDetail);
                    }
                    this.myTableEdit.SetAllDetails(list);
                }
            }
        }

        private void initEnable()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            this.myTableEdit.IsEnabled = vm.IsInitViewEdit;
        }

        private void initVisible()
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            if (vm.IsInitViewEdit)
            {
                this.SaveBtn.Visibility = Visibility.Visible;
                this.SaveAndCheckBtn.Visibility = Visibility.Visible;
                this.EditBtn.Visibility = Visibility.Collapsed;
                this.ReCheckBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.SaveBtn.Visibility = Visibility.Collapsed;
                this.SaveAndCheckBtn.Visibility = Visibility.Collapsed;
                if (vm.CurrentMedicineCheckStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
                {
                    this.EditBtn.Visibility = Visibility.Collapsed;
                    this.ReCheckBtn.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.EditBtn.Visibility = Visibility.Visible;
                    this.ReCheckBtn.Visibility = Visibility.Visible;
                }
            }
        }

        private List<CommContracts.MedicineCheckStoreDetail> GetDetails()
        {
            List<MyDetail> list = myTableEdit.GetAllDetails();
            List<CommContracts.MedicineCheckStoreDetail> Details = new List<CommContracts.MedicineCheckStoreDetail>();
            foreach (var tem in list)
            {
                CommContracts.MedicineCheckStoreDetail detail = new CommContracts.MedicineCheckStoreDetail();
                detail.Num = tem.SingleDose;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                //detail.Batch = tem.BatchID;
                //detail.ExpirationDate = tem.ExpirationDate;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                //detail.MedicineID = tem.ID;
                detail.StoreRoomMedicineNumID = tem.ID;

                Details.Add(detail);
            }
            return Details;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            bool? result = vm?.SaveMedicineCheckStock(GetDetails());
            if (result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("保存成功!");
                    vm?.MedicineWorkManage();
                    return;
                }
            }
            MessageBox.Show("保存失败!");
        }

        private void SaveAndCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            bool? result = vm?.SaveMedicineCheckStock(GetDetails(), true);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("保存并审核成功!");
                    vm?.MedicineWorkManage();
                    return;
                }
            }
            MessageBox.Show("保存并审核失败!");
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm.IsInitViewEdit = true;
            initEnable();
            initVisible();
        }

        private void ReCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            bool? result = vm?.ReCheckMedicineCheckStore();
            if (result.HasValue)
            {
                if (result.Value)
                {
                    MessageBox.Show("审核成功!");
                    vm?.MedicineWorkManage();
                    return;
                }
            }
            MessageBox.Show("审核失败!");
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.MedicineWorkManage();
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
