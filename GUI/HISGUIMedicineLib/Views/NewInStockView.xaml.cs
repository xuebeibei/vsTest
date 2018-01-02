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
    [Export("NewInStockView", typeof(NewInStockView))]
    public partial class NewInStockView : HISGUIViewBase
    {
        private MyTableEdit myTableEdit;
        public NewInStockView()
        {
            InitializeComponent();
            myTableEdit = new MyTableEdit(MyTableEditEnum.medicineInStock);
            InStockPanel.Children.Add(myTableEdit);
            this.Loaded += View_Loaded;
        }

        [Import]
        private HISGUIMedicineVM ImportVM
        {
            set { this.VM = value; }
        }

        private void View_Loaded(object sender, RoutedEventArgs e)
        {
            this.InStockDate.SelectedDate = DateTime.Now;
        }

        private List<CommContracts.MedicineInStoreDetail> GetDetails()
        {
            List<MyDetail> list = myTableEdit.GetAllDetails();
            List<CommContracts.MedicineInStoreDetail> Details = new List<CommContracts.MedicineInStoreDetail>();
            foreach (var tem in list)
            {
                CommContracts.MedicineBatch batch = new CommContracts.MedicineBatch();
                batch.MedicineID = tem.ID;
                batch.Batch = tem.BatchID;
                batch.ExpirationDate = tem.ExpirationDate;
                batch.SellPrice = tem.SellPrice;
                batch.StorePrice = tem.StockPrice;

                CommContracts.MedicineInStoreDetail detail = new CommContracts.MedicineInStoreDetail();
                detail.Num = tem.SingleDose;
                detail.SellPrice = tem.SellPrice;
                detail.StorePrice = tem.StockPrice;
                detail.MedicineBatch = batch;

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
