using System;
using System.Collections.Generic;
using System.Data;
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
using TXTextControl;
using TXTextControl.DocumentServer;
using TXTextControl.DocumentServer.Fields;

namespace HISGUIDoctorLib.Views
{
    public partial class ClinicMedicalRecordView : UserControl
    {
        //private DataSet dsAddresses;
        private MailMerge mailMerge1;
        public ClinicMedicalRecordView()
        {
            InitializeComponent();
        }

        private void mnuFile_OpenFile_Click(object sender, RoutedEventArgs e)
        {
            TXTextControl.LoadSettings ls = new TXTextControl.LoadSettings();
            ls.ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord;
            ls.ApplicationFieldTypeNames = new string[] { "表单文本" };

            textControl1.Load(TXTextControl.StreamType.MSWord | TXTextControl.StreamType.WordprocessingML, ls);
        }

        private void mnuFile_SaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            //textControl1.Save(TXTextControl.StreamType.MSWord | TXTextControl.StreamType.WordprocessingML);
            string str = "";
            //textControl1.Save(out str,)
            textControl1.Save(out str, TXTextControl.StringStreamType.RichTextFormat);

            //MessageBox.Show(str);

            CommClient.MedicalRecord medicalRecordClient = new CommClient.MedicalRecord();
            CommContracts.MedicalRecord medicalRecord = new CommContracts.MedicalRecord();
            medicalRecord.ContentXml = str;
            medicalRecord.RegistrationID = 7;
            medicalRecord.WriteUserID = 1;
            medicalRecord.WriteTime = DateTime.Now;

            medicalRecordClient.SaveMedicalRecord(medicalRecord);



        }

        private void textControl1_Loaded(object sender, RoutedEventArgs e)
        {
            textControl1.Focus();

            //dsAddresses = new DataSet();
            //dsAddresses.ReadXml("data2.xml");

            mailMerge1 = new MailMerge();
            mailMerge1.TextComponent = textControl1;

            TXTextControl.LoadSettings ls = new TXTextControl.LoadSettings();
            ls.ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord;
            ls.LoadSubTextParts = true;

            //textControl1.Load("333.docx", StreamType.WordprocessingML, ls);

            CommClient.MedicalRecord medicalRecordClient = new CommClient.MedicalRecord();
            CommContracts.MedicalRecord medicalRecord = medicalRecordClient.GetMedicalRecord(7);

            textControl1.Load(medicalRecord.ContentXml, TXTextControl.StringStreamType.RichTextFormat);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            // inserts a new ApplicationField of type FORMTEXT
            FormText ftField = new FormText();
            ftField.Text = "[新表单文本框字段]";

            textControl1.ApplicationFields.Add(ftField.ApplicationField);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            // casts an ApplicationField of type FORMTEXT to a FormTextBox object
            // and opens the appropriate dialog box
            if (textControl1.ApplicationFields.GetItem().TypeName == "FORMTEXT")
            {
                FormText curFormText = new FormText(textControl1.ApplicationFields.GetItem());

                curFormText.ShowDialog();
            }
        }

        private void FormFieldMenu_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            //enables of disables the properties menu item
            if (textControl1.ApplicationFields.GetItem() == null)
                FormFields_Properties.IsEnabled = false;
            else
                FormFields_Properties.IsEnabled = true;
        }

        private void mnuCut_Click(object sender, RoutedEventArgs e)
        {
            textControl1.Cut();
        }

        private void mnuCopy_Click(object sender, RoutedEventArgs e)
        {
            textControl1.Copy();
        }

        private void mnuPaste_Click(object sender, RoutedEventArgs e)
        {
            textControl1.Paste();
        }

        private void mnuFormat_Character_Click(object sender, RoutedEventArgs e)
        {
            textControl1.FontDialog();
        }

        private void mnuFormat_Paragraph_Click(object sender, RoutedEventArgs e)
        {
            textControl1.ParagraphFormatDialog();
        }

        private void fileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mnuAddDate_Click(object sender, RoutedEventArgs e)
        {
            CommClient.Employee employeeClient = new CommClient.Employee();
            List<CommContracts.Employee> list = employeeClient.GetAllEmployee();

            mailMerge1.SearchPath = "";

            mailMerge1.MergeObject(list.ElementAt(0));

        }
    }
}
