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

namespace HISGUISetLib.Views
{
    /// <summary>
    /// HospitalInfoSetView.xaml 的交互逻辑
    /// </summary>
    public partial class HospitalInfoSetView : UserControl
    {
        public HospitalInfoSetView()
        {
            InitializeComponent();
            this.Loaded += HospitalInfoSetView_Loaded;
        }

        private void HospitalInfoSetView_Loaded(object sender, RoutedEventArgs e)
        {
            CommClient.HospitalMsg hospitalMsgClient = new CommClient.HospitalMsg();
            CommContracts.HospitalMsg hospitalMsg = new CommContracts.HospitalMsg();
            hospitalMsg = hospitalMsgClient.GetAllHospitalMsg().ElementAt(0);
            this.HospitalNameBox.Text = hospitalMsg.HospitalName;
            this.bIsYiBaoCheckBox.IsChecked = hospitalMsg.bIsYiBao;
            this.YiBaoNoBox.Text = hospitalMsg.YiBaoNo;

            EditGrid.IsEnabled = false;

            this.SaveBtn.Visibility = Visibility.Collapsed;
            this.EditBtn.Visibility = Visibility.Visible;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            CommContracts.HospitalMsg hospitalMsg = new CommContracts.HospitalMsg();
            hospitalMsg.HospitalName = this.HospitalNameBox.Text;
            hospitalMsg.bIsYiBao = this.bIsYiBaoCheckBox.IsChecked.Value;
            hospitalMsg.YiBaoNo = this.YiBaoNoBox.Text;

            CommClient.HospitalMsg hospitalMsgClient = new CommClient.HospitalMsg();
            if(hospitalMsgClient.SaveHospitalMsg(hospitalMsg))
            {
                MessageBox.Show("保存成功！");
                this.SaveBtn.Visibility = Visibility.Collapsed;
                this.EditBtn.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("保存失败！");
                this.SaveBtn.Visibility = Visibility.Visible;
                this.EditBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void bIsYiBaoCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if(this.bIsYiBaoCheckBox.IsChecked.Value)
            {
                YiBaoNoBox.IsEnabled = true;
            }
            else
            {
                YiBaoNoBox.IsEnabled = false;
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditGrid.IsEnabled = true;

            this.SaveBtn.Visibility = Visibility.Visible;
            this.EditBtn.Visibility = Visibility.Collapsed;
        }
    }
}
