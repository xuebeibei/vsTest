﻿using System;
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
    public partial class SelectItemsList : UserControl
    {
        public CommContracts.Medicine CurrentMedicine { get; set; }        // 药品
        public CommContracts.TherapyItem CurrentTherapyItem { get; set; }  // 治疗
        public CommContracts.AssayItem CurrentAssayItem { get; set; }      // 化验
        public CommContracts.InspectItem CurrentInspectItem { get; set; }  // 检查
        public CommContracts.MaterialItem CurrentMaterialItem { get; set; }// 材料
        public CommContracts.OtherServiceItem CurrentOtherServiceItem { get; set; } // 其他服务
        public CommContracts.StoreRoomMedicineNum CurrentStoreRoomMedicineNum { get; set; }  // 库存

        private MyTableEditEnum editEnum;
        public SelectItemsList(MyTableEditEnum itemEnum)
        {
            InitializeComponent();
            editEnum = itemEnum;
            initGrid();
            getAllData();
        }

        private void initGrid()
        {
        }

        private void getAllData()
        {
            string strFindName = ""; // 暂时先搜索空
            if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao || editEnum == MyTableEditEnum.medicineInStock)
            {
                CommClient.Medicine myd = new CommClient.Medicine();
                List<CommContracts.Medicine> list = myd.GetAllMedicine();

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.zhiliao)
            {
                CommClient.TherapyItem therapyItem = new CommClient.TherapyItem();
                List<CommContracts.TherapyItem> list = therapyItem.GetAllTherapyItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if(editEnum == MyTableEditEnum.jianyan)
            {
                CommClient.AssayItem therapyItem = new CommClient.AssayItem();
                List<CommContracts.AssayItem> list = therapyItem.GetAllAssayItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.jiancha)
            {
                CommClient.InspectItem therapyItem = new CommClient.InspectItem();
                List<CommContracts.InspectItem> list = therapyItem.GetAllInspectItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if(editEnum == MyTableEditEnum.cailiao)
            {
                CommClient.MaterialItem therapyItem = new CommClient.MaterialItem();
                List<CommContracts.MaterialItem> list = therapyItem.GetAllMaterialItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if(editEnum == MyTableEditEnum.qita)
            {
                CommClient.OtherServiceItem otherServiceItem = new CommClient.OtherServiceItem();
                List<CommContracts.OtherServiceItem> list = otherServiceItem.GetAllOtherServiceItem(strFindName);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if (editEnum == MyTableEditEnum.medicineOutStock)
            {
                CommClient.StoreRoomMedicineNum storeRoomMedicineNum = new CommClient.StoreRoomMedicineNum();
                List<CommContracts.StoreRoomMedicineNum> list = storeRoomMedicineNum.getAllMedicineItemNum(1,"",0,-1,true,true,false,false);

                this.Grid1.ItemsSource = list;
                this.Grid1.Focus();
            }
            else if(editEnum == MyTableEditEnum.medicineCheckStock)
            {

            }
        }


        private void Grid1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                if (editEnum == MyTableEditEnum.xichengyao || editEnum == MyTableEditEnum.zhongyao || editEnum == MyTableEditEnum.medicineInStock)
                {
                    CommContracts.Medicine medicine = ((sender as DataGrid).CurrentCell.Item as CommContracts.Medicine);

                    CurrentMedicine = medicine;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.zhiliao)
                {
                    CommContracts.TherapyItem therapyItem = ((sender as DataGrid).CurrentCell.Item as CommContracts.TherapyItem);

                    CurrentTherapyItem = therapyItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.jianyan)
                {
                    CommContracts.AssayItem therapyItem = ((sender as DataGrid).CurrentCell.Item as CommContracts.AssayItem);

                    CurrentAssayItem = therapyItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.jiancha)
                {
                    CommContracts.InspectItem therapyItem = ((sender as DataGrid).CurrentCell.Item as CommContracts.InspectItem);

                    CurrentInspectItem = therapyItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if(editEnum == MyTableEditEnum.cailiao)
                {
                    CommContracts.MaterialItem materialItem = ((sender as DataGrid).CurrentCell.Item as CommContracts.MaterialItem);

                    CurrentMaterialItem = materialItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();

                }
                else if(editEnum == MyTableEditEnum.qita)
                {
                    CommContracts.OtherServiceItem otherServiceItem = ((sender as DataGrid).CurrentCell.Item as CommContracts.OtherServiceItem);

                    CurrentOtherServiceItem = otherServiceItem;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if (editEnum == MyTableEditEnum.medicineOutStock)
                {
                    CommContracts.StoreRoomMedicineNum storeRoomMedicineNum = ((sender as DataGrid).CurrentCell.Item as CommContracts.StoreRoomMedicineNum);

                    CurrentStoreRoomMedicineNum = storeRoomMedicineNum;
                    (this.Parent as Window).DialogResult = true;
                    (this.Parent as Window).Close();
                }
                else if(editEnum == MyTableEditEnum.medicineCheckStock)
                {

                }
            }
        }
    }
}
