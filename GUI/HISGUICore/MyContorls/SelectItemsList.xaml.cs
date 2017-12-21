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
    /// <summary>
    /// SelectItemsList.xaml 的交互逻辑
    /// </summary>
    public partial class SelectItemsList : UserControl
    {
        public CommContracts.Medicine CurrentMedicine { get; set; }
        public SelectItemsList()
        {
            InitializeComponent();

            initGrid();
            getAllData();
        }

        private void initGrid()
        {
        }

        private void getAllData()
        {
            CommClient.Medicine myd = new CommClient.Medicine();
            // 得到所有当天科室坐诊医生

            List<CommContracts.Medicine> list = myd.getAllMedicine();

            this.Grid1.ItemsSource = list;
            this.Grid1.Focus();
            
        }

       
        private void Grid1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter || e.Key == Key.Return)
            {
                CommContracts.Medicine medicine = ((sender as DataGrid).CurrentCell.Item as CommContracts.Medicine);

                CurrentMedicine = medicine;
                (this.Parent as Window).DialogResult = true;
                (this.Parent as Window).Close();
            }
        }
    }
}
