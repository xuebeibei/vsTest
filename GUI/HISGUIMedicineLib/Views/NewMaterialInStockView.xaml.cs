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
    [Export("NewMaterialInStockView", typeof(NewMaterialInStockView))]
    public partial class NewMaterialInStockView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        private List<CommContracts.Supplier> supplierList;
        public NewMaterialInStockView()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.materialInStock);
            InStockPanel.Children.Add(myTableEdit);
            CommClient.Supplier supplier = new CommClient.Supplier();
            supplierList = supplier.GetAllSuppliers("");
            this.SupplierEdit.ItemsSource = supplierList;
            this.InStockWay.ItemsSource = Enum.GetValues(typeof(CommContracts.InStoreEnum));

            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            initDate();
            initEnable();
            initVisible();
        }

        private void initDate()
        {
            var vm = this.DataContext as HISGUIMedicineVM;

            if (vm.CurrentMaterialInStore != null)
            {
                this.myTableEdit.ClearAllDetails();

                if (vm.CurrentMaterialInStore.MaterialInStoreDetails != null)
                {
                    List<MyDetail> list = new List<MyDetail>();
                    foreach (var tem in vm.CurrentMaterialInStore.MaterialInStoreDetails)
                    {
                        MyDetail myDetail = new MyDetail();
                        myDetail.ID = tem.MaterialID;
                        myDetail.ExpirationDate = tem.ExpirationDate;
                        myDetail.BatchID = tem.Batch;
                        myDetail.SingleDose = tem.Num;
                        if (tem.Material != null)
                        {
                            myDetail.SingleDoseUnit = tem.Material.Unit;
                            myDetail.Name = tem.Material.Name;
                            myDetail.Manufacturer = tem.Material.Manufacturer;
                            myDetail.Specifications = tem.Material.Specifications;
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
                if (vm.CurrentMaterialInStore != null)
                {
                    if (vm.CurrentMaterialInStore.ReCheckStatusEnum == CommContracts.ReCheckStatusEnum.已审核)
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

        private List<CommContracts.MaterialInStoreDetail> GetDetails()
        {
            List<MyDetail> list = myTableEdit.GetAllDetails();
            List<CommContracts.MaterialInStoreDetail> Details = new List<CommContracts.MaterialInStoreDetail>();
            foreach (var tem in list)
            {
                CommContracts.MaterialInStoreDetail detail = new CommContracts.MaterialInStoreDetail();
                detail.Num = tem.SingleDose;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                detail.Batch = tem.BatchID;
                detail.ExpirationDate = tem.ExpirationDate;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                detail.MaterialID = tem.ID;

                Details.Add(detail);
            }
            return Details;
        }

        private bool MySaveMaterialInStore(bool bIsRecheck = false)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            CommContracts.MaterialInStore materialInStore = new CommContracts.MaterialInStore();
            if (vm.CurrentUser != null)
                materialInStore.OperateUserID = vm.CurrentUser.ID;
            if (vm.CurrentStoreRoom != null)
                materialInStore.ToStoreID = vm.CurrentStoreRoom.ID;
            if ((CommContracts.Supplier)this.SupplierEdit.SelectedItem != null)
                materialInStore.FromSupplierID = ((CommContracts.Supplier)this.SupplierEdit.SelectedItem).ID;
            materialInStore.MaterialInStoreDetails = GetDetails();

            bool? result = vm?.SaveMaterialInStock(materialInStore, bIsRecheck);
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
            if (MySaveMaterialInStore())
            {
                MessageBox.Show("保存成功!");
                var vm = this.DataContext as HISGUIMedicineVM;
                vm?.MedicineWorkManage();
                return;
            }
            MessageBox.Show("保存失败!");
        }

        private void SaveAndCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MySaveMaterialInStore(true))
            {
                MessageBox.Show("保存并审核成功!");
                var vm = this.DataContext as HISGUIMedicineVM;
                vm?.MedicineWorkManage();
                return;
            }
            MessageBox.Show("保存并审核失败!");
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.MedicineWorkManage();
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
            bool? result = vm?.ReCheckMaterialInStore();
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

        private void SupplierEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tem = SupplierEdit.SelectedItem as CommContracts.Supplier;
            if (tem == null)
                return;

            var vm = this.DataContext as HISGUIMedicineVM;
            vm.CurrentMaterialInStore.FromSupplierID = tem.ID;
        }
    }
}
