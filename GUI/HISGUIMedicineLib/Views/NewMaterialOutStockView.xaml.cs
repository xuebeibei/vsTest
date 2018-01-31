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
    [Export("NewMaterialOutStockView", typeof(NewMaterialOutStockView))]
    public partial class NewMaterialOutStockView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public NewMaterialOutStockView()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.materialOutStock);
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

            if (vm.CurrentMaterialOutStore != null)
            {
                this.myTableEdit.ClearAllDetails();
                //if (vm.CurrentMaterialOutStore.FromSupplier != null)
                //    this.SupplierEdit.Text = vm.CurrentMaterialOutStore.FromSupplier.Name;   // 界面上的没起作用

                if (vm.CurrentMaterialOutStore.MaterialOutStoreDetails != null)
                {
                    List<MyDetail> list = new List<MyDetail>();
                    foreach (var tem in vm.CurrentMaterialOutStore.MaterialOutStoreDetails)
                    {
                        MyDetail myDetail = new MyDetail();
                        myDetail.ID = tem.ID;
                        myDetail.SingleDose = tem.Num;
                        if (tem.StoreRoomMaterialNum != null)
                        {
                            myDetail.ExpirationDate = tem.StoreRoomMaterialNum.ExpirationDate;
                            myDetail.BatchID = tem.StoreRoomMaterialNum.Batch;
                            if (tem.StoreRoomMaterialNum.MaterialItem != null)
                            {
                                myDetail.SingleDoseUnit = tem.StoreRoomMaterialNum.MaterialItem.Unit;
                                myDetail.Name = tem.StoreRoomMaterialNum.MaterialItem.Name;
                                myDetail.Manufacturer = tem.StoreRoomMaterialNum.MaterialItem.Manufacturer;
                                myDetail.Specifications = tem.StoreRoomMaterialNum.MaterialItem.Specifications;
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
                if (vm.CurrentMaterialOutStore != null)
                {
                    if (vm.CurrentMaterialOutStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
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

        private List<CommContracts.MaterialOutStoreDetail> GetDetails()
        {
            List<MyDetail> list = myTableEdit.GetAllDetails();
            List<CommContracts.MaterialOutStoreDetail> Details = new List<CommContracts.MaterialOutStoreDetail>();
            foreach (var tem in list)
            {
                CommContracts.MaterialOutStoreDetail detail = new CommContracts.MaterialOutStoreDetail();
                detail.Num = tem.SingleDose;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                detail.StoreRoomMaterialNumID = tem.StoreRoomNumID;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;

                Details.Add(detail);
            }
            return Details;
        }
        private bool MySaveMaterialOutStore(bool bIsRecheck = false)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            CommContracts.MaterialOutStore materialOutStore = new CommContracts.MaterialOutStore();
            if (vm.CurrentUser != null)
                materialOutStore.OperateUserID = vm.CurrentUser.ID;
            if (vm.CurrentStoreRoom != null)
                materialOutStore.ToStoreID = vm.CurrentStoreRoom.ID;

            materialOutStore.MaterialOutStoreDetails = GetDetails();

            bool? result = vm?.SaveMaterialOutStock(materialOutStore, bIsRecheck);
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

            if (MySaveMaterialOutStore())
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

            if (MySaveMaterialOutStore(true))
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
            bool? result = vm?.ReCheckMaterialOutStore();
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
