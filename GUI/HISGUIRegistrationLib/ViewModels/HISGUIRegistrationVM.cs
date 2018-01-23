using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;
using HISGUIRegistrationLib;
using HISGUICore;
using System.Data;

namespace HISGUIRegistrationLib.ViewModels
{
    public class PatientMsg
    {
        public PatientMsg(string name,
            string gender,
            string tel,
            string addr,
            string patientCardNum,
            string feeType,
            string idCardNum)
        {
            this.Name = name;
            this.Gender = gender;
            this.Tel = tel;
            this.Addr = addr;
            this.PatientCardNum = patientCardNum;
            this.FeeType = feeType;
            this.IdCardNum = idCardNum;
        }

        public PatientMsg()
        {
            this.Name = "";
            this.Gender = "男";
            this.Tel = "";
            this.Addr = "";
            this.PatientCardNum = "";
            this.FeeType = "";
            this.IdCardNum = "";
        }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Tel { get; set; }
        public string Addr { get; set; }
        public string PatientCardNum { get; set; }
        public string FeeType { get; set; }
        public string IdCardNum { get; set; }
    }
    public class SignalSource
    {
        public SignalSource(int id,
            int departmentID,
            DateTime? datetime,
            string timeIntival,
            string type,
            int maxNum,
            int addMaxNum,
            int hasUsedNum,
            string specialist,
            string explan,
            decimal price)
        {
            this.SignalID = id;
            this.DepartmentID = departmentID;
            this.VistTime = datetime;
            this.TimeIntival = timeIntival;
            this.SignalType = type;
            this.MaxNum = maxNum;
            this.AddMaxNum = addMaxNum;
            this.HasUsedNum = hasUsedNum;
            this.Specialist = specialist;
            this.Explain = explan;
            this.Price = price;
        }

        public SignalSource()
        {
            this.SignalID = 0;
            this.DepartmentID = 0;
            this.SignalType = "普通门诊";
            this.AddMaxNum = 0;
            this.HasUsedNum = 0;
            this.Specialist = "";
            this.Price = 0.00m;
            this.Explain = "";
        }
        public int SignalID { get; set; }      // 编号
        public DateTime? VistTime { get; set; } // 看诊日期
        public string TimeIntival { get; set; }   // 看诊时段
        public int DepartmentID { get; set; }  // 科室
        public string SignalType { get; set; }    // 号别
        public int MaxNum { get; set; }        // 最大号源
        public int AddMaxNum { get; set; }     // 临时加号号源
        public int HasUsedNum { get; set; }    // 已挂号源
        public string Specialist { get; set; }    // 专家
        public decimal Price { get; set; }      // 费用
        public string Explain { get; set; }    // 说明

    }

    public class RegistrationBill
    {
        public RegistrationBill()
        {
            this.ID = 1;
            this.BillNo = "0001";
            this.Patient = new PatientMsg();
            this.Signal = new SignalSource();
            this.MakeTime = "";
            this.MakerUser = "";
            this.CancelTime = "";
            this.CancelUser = "";
            this.DueFee = 0;
            this.RealFee = 0;
            this.SeeDoctorStatus = "未就诊";

        }
        public int ID { get; set; }
        public string BillNo { get; set; }
        public PatientMsg Patient { get; set; }
        public SignalSource Signal { get; set; }
        public string MakeTime { get; set; }
        public string MakerUser { get; set; }
        public string CancelTime { get; set; }
        public string CancelUser { get; set; }
        public double DueFee { get; set; }
        public double RealFee { get; set; }
        public string SeeDoctorStatus { get; set; }
    }

    [Export]
    [Export("HISGUIRegistrationVM", typeof(HISGUIVMBase))]
    class HISGUIRegistrationVM : HISGUIVMBase
    {

        public List<CommContracts.Department> getDepts()
        {
            CommClient.Department myd = new CommClient.Department();
            List<CommContracts.Department> data = myd.getALLDepartment(CommContracts.DepartmentEnum.临床科室);

            return data;
        }

        public List<CommContracts.Department> getTrees(int parentid, List<CommContracts.Department> nodes)
        {
            List<CommContracts.Department> mainNodes = nodes.Where(x => x.ParentID == parentid).ToList<CommContracts.Department>();
            List<CommContracts.Department> otherNodes = nodes.Where(x => x.ParentID != parentid).ToList<CommContracts.Department>();
            //foreach (CommContracts.Department dpt in mainNodes)
            //{
            //    dpt.Nodes = getTrees(dpt.ID, otherNodes);
            //}
            return mainNodes;
        }

        public List<SignalSource> getSignalSource(int DepartmentID, DateTime dateTime, int timeInterval)
        {
            CommClient.SignalSource myd = new CommClient.SignalSource();
            // 得到所有有效号源
            List<CommContracts.SignalSource> listOfSignalSource = myd.getALLSignalSource(DepartmentID, dateTime, timeInterval);

            List<SignalSource> signalList = new List<SignalSource>();

            foreach (CommContracts.SignalSource sg in listOfSignalSource)
            {
                SignalSource temp = new SignalSource();

                temp.SignalID = sg.ID;
                temp.DepartmentID = sg.GetDepartment.ID;
                temp.VistTime = sg.VistTime;

                if (sg.TimeIntival == 1)
                {
                    temp.TimeIntival = "上午";
                }
                else if (sg.TimeIntival == 2)
                {
                    temp.TimeIntival = "下午";
                }
                else if (sg.TimeIntival == 3)
                {
                    temp.TimeIntival = "晚上";
                }

                if (sg.SignalType == 1)
                {
                    temp.SignalType = "普通门诊";
                }
                else if (sg.SignalType == 2)
                {
                    temp.SignalType = "专家";
                }

                temp.MaxNum = sg.MaxNum;
                temp.AddMaxNum = sg.AddMaxNum;
                temp.HasUsedNum = sg.HasUsedNum;

                if (sg.Specialist == 0)
                {
                    temp.Specialist = "";
                }
                else
                {
                    temp.Specialist = sg.Specialist.ToString();
                }

                temp.Explain = sg.Explain;
                temp.Price = sg.Price;

                signalList.Add(temp);

            }

            return signalList;
        }

        public void getPatient()
        {
            var tempPatient = new PatientMsg("张三", "男", "1453939922", "北京市海淀区", "1001", "自费", "410993199802013245");
            PatientMsgTest = tempPatient;
            RegistrationBillTest.Patient = tempPatient;

        }

        public void initSignalTime()
        {
            DateTime tempTime = new DateTime();
            tempTime = DateTime.Now;
        }

        public void showDepartmentSignal(int DepartmentID)
        {
            DataTable data = new DataTable();
            data.Columns.Add("时段\\日期", typeof(string));
            CommClient.SignalSource myd = new CommClient.SignalSource();

            // 得到所有挂号日期
            List<DateTime> aa = myd.getAllSignalDate(DepartmentID);
            int nDateNum = 0;
            foreach (DateTime temp in aa)
            {
                data.Columns.Add(temp.ToString("yyyy-MM-dd \n dddd"), typeof(String));
                nDateNum++;
            }



            // 得到可挂号的时段
            List<int> TimeList = myd.getAllSignalTimeIntival(DepartmentID);
            int nTimeIntivalNum = 0;
            foreach (int temp in TimeList)
            {
                data.Rows.Add();
                data.Rows[nTimeIntivalNum][0] = temp.ToString();

                nTimeIntivalNum++;
            }

            for (int row = 0; row < nTimeIntivalNum; row++)
            {
                for (int column = 0; column < nDateNum; column++)
                {
                    string sss = myd.getSignalSourceTip(DepartmentID, aa.ElementAt(column), TimeList.ElementAt(row));


                    data.Rows[row][column + 1] = sss;

                }
            }

            _dt = data;

        }

        public void showSelectSignal(SignalSource temp)
        {
            if (temp != null && temp is SignalSource)
            {
                SignalSourceTest = temp;
                RegistrationBillTest.Signal = SignalSourceTest;
            }
        }

        public void newRegistrationBill()
        {
            var temp = new RegistrationBill();
            temp.MakerUser = "admin";
            temp.MakeTime = DateTime.Now.ToString();

            RegistrationBillTest = temp;
        }

        public bool SaveRegistrationBill()
        {
            if(RegistrationBillTest.Patient == null)
            {
                return false;
            }
            else if(RegistrationBillTest.Signal == null)
            {
                return false;
            }

            CommClient.Registration myd = new CommClient.Registration();

            CommContracts.Registration registration = new CommContracts.Registration();
            registration.RegisterFee = 20.0m;
            registration.RegisterTime = DateTime.Now;
            registration.SignalSourceID = SignalSourceTest.SignalID;
            registration.RegisterUserID = 1;
            registration.PatientID = 1;


            myd.SetRegistration(registration);
            if(myd.SaveRegistration())
            {
                CommClient.SignalSource myd1 = new CommClient.SignalSource();
                myd1.UpdateSignalSource(SignalSourceTest.SignalID);
            }
            return true;
        }

        #region PatientMsgTest
        public static readonly DependencyProperty PatientMsgTestProperty = DependencyProperty.Register(
            "PatientMsgTest", typeof(PatientMsg), typeof(HISGUIRegistrationVM), new PropertyMetadata((sender, e) => { }));

        public PatientMsg PatientMsgTest
        {
            get { return (PatientMsg)GetValue(PatientMsgTestProperty); }
            set { SetValue(PatientMsgTestProperty, value); }
        }

        #endregion

        #region RegistrationBillTest
        public static readonly DependencyProperty RegistrationBillTestProperty = DependencyProperty.Register(
            "RegistrationBillTest", typeof(RegistrationBill), typeof(HISGUIRegistrationVM), new PropertyMetadata((sender, e) => { }));

        public RegistrationBill RegistrationBillTest
        {
            get { return (RegistrationBill)GetValue(RegistrationBillTestProperty); }
            set { SetValue(RegistrationBillTestProperty, value); }
        }

        #endregion

        #region RegistrationNo
        public static readonly DependencyProperty RegistrationNoProperty = DependencyProperty.Register(
            "RegistrationNo", typeof(string), typeof(HISGUIRegistrationVM), new PropertyMetadata((sender, e) => { }));

        public string RegistrationNo
        {
            get { return (string)GetValue(RegistrationNoProperty); }
            set { SetValue(RegistrationNoProperty, value); }
        }

        #endregion

        #region SignalSourceTest 
        public static readonly DependencyProperty SignalSourceTestProperty = DependencyProperty.Register(
            "SignalSourceTest", typeof(SignalSource), typeof(HISGUIRegistrationVM), new PropertyMetadata((sender, e) => { }));

        public SignalSource SignalSourceTest
        {
            get { return (SignalSource)GetValue(SignalSourceTestProperty); }
            set { SetValue(SignalSourceTestProperty, value); }
        }

        #endregion

        #region _dt 
        public static readonly DependencyProperty _dtProperty = DependencyProperty.Register(
            "_dt", typeof(DataTable), typeof(HISGUIRegistrationVM), new PropertyMetadata((sender, e) => { }));

        public DataTable _dt
        {
            get { return (DataTable)GetValue(_dtProperty); }
            set { SetValue(_dtProperty, value); }
        }

        #endregion

    }
}
