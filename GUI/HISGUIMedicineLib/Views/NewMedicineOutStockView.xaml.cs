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
    [Export("NewMedicineOutStockView", typeof(NewMedicineOutStockView))]
    public partial class NewMedicineOutStockView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public NewMedicineOutStockView()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.medicineOutStock);
            OnStockPanel.Children.Add(myTableEdit);

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
            var vm = this.DataContext as HISGUIMedicineVM;
            //this.DepartmentCombo.ItemsSource = vm?.getAllDepartment();
            this.OutStockWay.ItemsSource = Enum.GetValues(typeof(CommContracts.OutStoreEnum));
        }

        private void initDate()
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            if(vm.CurrentMedicineOutStore != null)
            {
                this.myTableEdit.ClearAllDetails();
                //if (vm.CurrentMedicineOutStore.FromSupplier != null)
                //    this.SupplierEdit.Text = vm.CurrentMedicineOutStore.FromSupplier.Name;   // 界面上的没起作用

                if (vm.CurrentMedicineOutStore.MedicineOutStoreDetails != null)
                {
                    List<MyDetail> list = new List<MyDetail>();
                    foreach (var tem in vm.CurrentMedicineOutStore.MedicineOutStoreDetails)
                    {
                        MyDetail myDetail = new MyDetail();
                        myDetail.ID = tem.ID;
                        myDetail.SingleDose = tem.Num;
                        if (tem.StoreRoomMedicineNum != null)
                        {
                            myDetail.ExpirationDate = tem.StoreRoomMedicineNum.ExpirationDate;
                            myDetail.BatchID = tem.StoreRoomMedicineNum.Batch;
                            if (tem.StoreRoomMedicineNum.Medicine != null)
                            {
                                myDetail.SingleDoseUnit = tem.StoreRoomMedicineNum.Medicine.Unit;
                                myDetail.Name = tem.StoreRoomMedicineNum.Medicine.Name;
                                myDetail.Manufacturer = tem.StoreRoomMedicineNum.Medicine.Manufacturer;
                                myDetail.Specifications = tem.StoreRoomMedicineNum.Medicine.Specifications;
                            }
                        }
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
                if(vm.CurrentMedicineOutStore != null)
                {
                    if (vm.CurrentMedicineOutStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
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
        }

        private List<CommContracts.MedicineOutStoreDetail> GetDetails()
        {
            List<MyDetail> list = myTableEdit.GetAllDetails();
            List<CommContracts.MedicineOutStoreDetail> Details = new List<CommContracts.MedicineOutStoreDetail>();
            foreach (var tem in list)
            {
                CommContracts.MedicineOutStoreDetail detail = new CommContracts.MedicineOutStoreDetail();
                detail.Num = tem.SingleDose;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                detail.StoreRoomMedicineNumID = tem.StoreRoomNumID;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;

                Details.Add(detail);
            }
            return Details;
        }
        
        private bool MySaveMedicineOutStore(bool bIsRecheck = false)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            CommContracts.MedicineOutStore MedicineOutStore = new CommContracts.MedicineOutStore();
            if (vm.CurrentUser != null)
                MedicineOutStore.OperateUserID = vm.CurrentUser.ID;
            if (vm.CurrentStoreRoom != null)
                MedicineOutStore.ToStoreID = vm.CurrentStoreRoom.ID;

            MedicineOutStore.MedicineOutStoreDetails = GetDetails();

            bool? result = vm?.SaveMedicineOutStock(MedicineOutStore, bIsRecheck);
            if (result.HasValue)
            {
                if (result.Value)
                {
                    return true;
                }
            }

            return false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            if (MySaveMedicineOutStore())
            {
                MessageBox.Show("保存成功！");
                vm?.MedicineWorkManage();
                return;
            }

            MessageBox.Show("保存失败！");
        }


        private void SaveAndCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            if (MySaveMedicineOutStore(true))
            {
                MessageBox.Show("保存并审核成功！");
                vm?.MedicineWorkManage();
                return;
            }

            MessageBox.Show("保存并审核失败！");
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
            bool? result = vm?.ReCheckMedicineOutStore();
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

        private void DepartmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EmployeeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
