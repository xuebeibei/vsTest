﻿using System;
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
    [Export("NewInStockView", typeof(NewInStockView))]
    public partial class NewInStockView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public NewInStockView()
        {
            InitializeComponent();
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            myTableEdit = new MyTableEdit(MyTableEditEnum.medicineInStock);
            InStockPanel.Children.Add(myTableEdit);

            var vm = this.DataContext as HISGUIMedicineVM;
            this.SupplierEdit.ItemsSource = vm?.getAllSupplier();
            this.InStockWay.ItemsSource = Enum.GetValues(typeof(CommContracts.InStoreEnum));
            if(vm.CurrentMedicineInStore != null)
            {
                this.SupplierEdit.Text = vm.CurrentMedicineInStore.FromSupplier.Name;   // 界面上的没起作用

                if(vm.CurrentMedicineInStore.MedicineInStoreDetails != null)
                {
                    List<MyDetail> list = new List<MyDetail>();
                    foreach (var tem in vm.CurrentMedicineInStore.MedicineInStoreDetails)
                    {
                        MyDetail myDetail = new MyDetail();
                        myDetail.ID = tem.MedicineID;
                        myDetail.ExpirationDate = tem.ExpirationDate;
                        myDetail.BatchID = tem.Batch;
                        myDetail.SingleDose = tem.Num;
                        if(tem.Medicine != null)
                        {
                            myDetail.SingleDoseUnit = tem.Medicine.Unit;
                            myDetail.Name = tem.Medicine.Name;
                            myDetail.Manufacturer = tem.Medicine.Manufacturer;
                            myDetail.Specifications = tem.Medicine.Specifications;
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

        private List<CommContracts.MedicineInStoreDetail> GetDetails()
        {
            List<MyDetail> list = myTableEdit.GetAllDetails();
            List<CommContracts.MedicineInStoreDetail> Details = new List<CommContracts.MedicineInStoreDetail>();
            foreach (var tem in list)
            {
                CommContracts.MedicineInStoreDetail detail = new CommContracts.MedicineInStoreDetail();
                detail.Num = tem.SingleDose;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                detail.Batch = tem.BatchID;
                detail.ExpirationDate = tem.ExpirationDate;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                detail.MedicineID = tem.ID;

                Details.Add(detail);
            }
            return Details;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
           
            var vm = this.DataContext as HISGUIMedicineVM;
            bool? result = vm?.SaveMedicineInStock(GetDetails());
            if(result.HasValue)
            {
                if(result.Value)
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
            bool? result = vm?.SaveMedicineInStock(GetDetails(), true);
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

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as HISGUIMedicineVM;
            vm?.MedicineWorkManage();
        }
    }
}
