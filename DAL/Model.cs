using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DAL
{
    /// <summary>
    /// 数据库连接类
    /// </summary>
    public class HisContext : DbContext
    {

        /// <summary>
        /// 科室
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// 一级科室
        /// </summary>
        public DbSet<LevelOneDepartment> LevelOneDepartments { get; set; }


        /// <summary>
        /// 二级科室
        /// </summary>
        public DbSet<LevelTwoDepartment> LevelTwoDepartments { get; set; }

        /// <summary>
        /// 门诊医生挂号号源表
        /// </summary>
        public DbSet<DoctorClinicWorkPlan> DoctorClinicWorkPlans { get; set; }

        /// <summary>
        /// 门诊挂号单表
        /// </summary>
        public DbSet<ClinicRegistration> ClinicRegistrations { get; set; }

        /// <summary>
        /// 医嘱项字典表
        /// </summary>
        public DbSet<DoctorAdviceItem> DoctorAdviceItems { get; set; }

        /// <summary>
        /// 给药频率
        /// </summary>
        public DbSet<Frequency> Frequencys { get; set; }

        /// <summary>
        /// 给药途径
        /// </summary>
        public DbSet<AdministrationRoute> AdministrationRoutes { get; set; }

        /// <summary>
        /// 医嘱明细记录表
        /// </summary>
        public DbSet<DoctorAdviceDetail> DoctorAdviceDetails { get; set; }

        /// <summary>
        /// 医嘱诊断字典
        /// </summary>
        public DbSet<DiagnoseItem> DiagnoseItems { get; set; }

        /// <summary>
        /// 医嘱明细组表
        /// </summary>
        public DbSet<DoctorAdviceDetailGroup> DoctorAdviceDetailGroups{ get;set; }

        /// <summary>
        /// 医嘱诊断明细表
        /// </summary>
        public DbSet<ClinicDoctorAdvice_DiagnoseItem> ClinicDoctorAdvice_DiagnoseItems { get; set; }

        /// <summary>
        /// 门诊医嘱表
        /// </summary>
        public DbSet<ClinicDoctorAdvice> ClinicDoctorAdvices { get; set; }


        /// <summary>
        /// 排班
        /// </summary>
        public DbSet<WorkPlan> WorkPlans { get; set; }

        /// <summary>
        /// 挂号单
        /// </summary>
        public DbSet<Registration> Registrations { get; set; }

        /// <summary>
        /// 退号单
        /// </summary>
        public DbSet<CancelRegistration> CancelRegistrations { get; set; }
        /// <summary>
        /// 患者
        /// </summary>
        public DbSet<Patient> Patients { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public DbSet<Job> Jobs { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.Employees”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.Triages”的 XML 注释
        public DbSet<Triage> Triages { get; set; }
        /// <summary>
        /// 药品
        /// </summary>
        public DbSet<Medicine> Medicines { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.Medicines”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicalRecords”的 XML 注释
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicalRecords”的 XML 注释
        //public DbSet<Inpatient> Inpatients { get; set; }
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.AssayItems”的 XML 注释
        public DbSet<AssayItem> AssayItems { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.AssayItems”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.Specimens”的 XML 注释
        public DbSet<Specimen> Specimens { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.Specimens”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InspectItems”的 XML 注释
        public DbSet<InspectItem> InspectItems { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InspectItems”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.BodyRegions”的 XML 注释
        public DbSet<BodyRegion> BodyRegions { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.BodyRegions”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyItems”的 XML 注释
        public DbSet<TherapyItem> TherapyItems { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyItems”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialItems”的 XML 注释
        public DbSet<MaterialItem> MaterialItems { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialItems”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.OtherServiceItem”的 XML 注释
        public DbSet<OtherServiceItem> OtherServiceItem { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.OtherServiceItem”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineInStores”的 XML 注释
        public DbSet<MedicineInStore> MedicineInStores { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineInStores”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineInStoreDetails”的 XML 注释
        public DbSet<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineInStoreDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineOutStores”的 XML 注释
        public DbSet<MedicineOutStore> MedicineOutStores { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineOutStores”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineOutStoreDetails”的 XML 注释
        public DbSet<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineOutStoreDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineCheckStores”的 XML 注释
        public DbSet<MedicineCheckStore> MedicineCheckStores { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineCheckStores”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineCheckStoreDetails”的 XML 注释
        public DbSet<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineCheckStoreDetails”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialInStores”的 XML 注释
        public DbSet<MaterialInStore> MaterialInStores { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialInStores”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialInStoreDetails”的 XML 注释
        public DbSet<MaterialInStoreDetail> MaterialInStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialInStoreDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialOutStores”的 XML 注释
        public DbSet<MaterialOutStore> MaterialOutStores { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialOutStores”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialOutStoreDetails”的 XML 注释
        public DbSet<MaterialOutStoreDetail> MaterialOutStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialOutStoreDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialCheckStores”的 XML 注释
        public DbSet<MaterialCheckStore> MaterialCheckStores { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialCheckStores”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialCheckStoreDetails”的 XML 注释
        public DbSet<MaterialCheckStoreDetail> MaterialCheckStoreDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialCheckStoreDetails”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.StoreRooms”的 XML 注释
        public DbSet<StoreRoom> StoreRooms { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.StoreRooms”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.StoreNumBases”的 XML 注释
        public DbSet<StoreNumBase> StoreNumBases { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.StoreNumBases”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.StoreRoomMedicineNums”的 XML 注释
        public DbSet<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.StoreRoomMedicineNums”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.StoreRoomMaterialNums”的 XML 注释
        public DbSet<StoreRoomMaterialNum> StoreRoomMaterialNums { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.StoreRoomMaterialNums”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.Suppliers”的 XML 注释
        public DbSet<Supplier> Suppliers { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.Suppliers”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.SickRooms”的 XML 注释
        public DbSet<SickRoom> SickRooms { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.SickRooms”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.SickBeds”的 XML 注释
        public DbSet<SickBed> SickBeds { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.SickBeds”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.PrePays”的 XML 注释
        public DbSet<PatientCardPrePay> PatientCardPrePays { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.PrePays”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineDoctorAdvices”的 XML 注释
        public DbSet<MedicineDoctorAdvice> MedicineDoctorAdvices { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineDoctorAdvices”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialDoctorAdvices”的 XML 注释
        public DbSet<MaterialDoctorAdvice> MaterialDoctorAdvices { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialDoctorAdvices”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.AssayDoctorAdvices”的 XML 注释
        public DbSet<AssayDoctorAdvice> AssayDoctorAdvices { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.AssayDoctorAdvices”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InspectDoctorAdvices”的 XML 注释
        public DbSet<InspectDoctorAdvice> InspectDoctorAdvices { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InspectDoctorAdvices”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyDoctorAdvices”的 XML 注释
        public DbSet<TherapyDoctorAdvice> TherapyDoctorAdvices { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyDoctorAdvices”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.OtherServiceDoctorAdvices”的 XML 注释
        public DbSet<OtherServiceDoctorAdvice> OtherServiceDoctorAdvices { get; set; }

        /// <summary>
        /// 号别表
        /// </summary>
        public DbSet<SignalType> SignalTypes { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.SignalItems”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.DoctorAdviceBases”的 XML 注释
        public DbSet<DoctorAdviceBase> DoctorAdviceBases { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.DoctorAdviceBases”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.GoodsBases”的 XML 注释
        public DbSet<GoodsBase> GoodsBases { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.GoodsBases”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.ChargeDetailBases”的 XML 注释
        public DbSet<ChargeDetailBase> ChargeDetailBases { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.ChargeDetailBases”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineChargeDetails”的 XML 注释
        public DbSet<MedicineChargeDetail> MedicineChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineChargeDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialChargeDetails”的 XML 注释
        public DbSet<MaterialChargeDetail> MaterialChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialChargeDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyChargeDetails”的 XML 注释
        public DbSet<TherapyChargeDetail> TherapyChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyChargeDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.AssayChargeDetails”的 XML 注释
        public DbSet<AssayChargeDetail> AssayChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.AssayChargeDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InspectChargeDetails”的 XML 注释
        public DbSet<InspectChargeDetail> InspectChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InspectChargeDetails”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.OtherServiceChargeDetails”的 XML 注释
        public DbSet<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.OtherServiceChargeDetails”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.ChargeBases”的 XML 注释
        public DbSet<ChargeBase> ChargeBases { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.ChargeBases”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineCharges”的 XML 注释
        public DbSet<MedicineCharge> MedicineCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MedicineCharges”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialCharges”的 XML 注释
        public DbSet<MaterialCharge> MaterialCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MaterialCharges”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyCharges”的 XML 注释
        public DbSet<TherapyCharge> TherapyCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.TherapyCharges”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.AssayCharges”的 XML 注释
        public DbSet<AssayCharge> AssayCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.AssayCharges”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InspectCharges”的 XML 注释
        public DbSet<InspectCharge> InspectCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InspectCharges”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.OtherServiceCharges”的 XML 注释
        public DbSet<OtherServiceCharge> OtherServiceCharges { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.OtherServiceCharges”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InHospitalApplys”的 XML 注释
        public DbSet<InHospitalApply> InHospitalApplys { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InHospitalApplys”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.MyTableBases”的 XML 注释
        public DbSet<MyTableBase> MyTableBases { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.MyTableBases”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InHospitals”的 XML 注释
        public DbSet<InHospital> InHospitals { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InHospitals”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InHospitalPatientDoctor”的 XML 注释
        public DbSet<InHospitalPatientDoctor> InHospitalPatientDoctor { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InHospitalPatientDoctor”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.LeaveHospitals”的 XML 注释
        public DbSet<LeaveHospital> LeaveHospitals { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.LeaveHospitals”的 XML 注释
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.RecallHospitals”的 XML 注释
        public DbSet<RecallHospital> RecallHospitals { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.RecallHospitals”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.InjectionBills”的 XML 注释
        public DbSet<InjectionBill> InjectionBills { get; set; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.InjectionBills”的 XML 注释

#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.PatientCardManages”的 XML 注释
        public DbSet<PatientCardManage> PatientCardManages { get; set; }

        /// <summary>
        /// 员工登录记录
        /// </summary>
        public DbSet<EmployeeLoginHistory> EmployeeLoginHistorys { get; set; }

        /// <summary>
        /// 看诊时间段表
        /// </summary>
        public DbSet<SignalTime> SignalTimes { get; set; }

        /// <summary>
        /// 放号渠道表
        /// </summary>
        public DbSet<RegistrationDitch> RegistrationDitchs { get; set; }

        /// <summary>
        /// 员工部门变更表
        /// </summary>
        public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistorys { get; set; }

        /// <summary>
        /// 员工职位变更表
        /// </summary>
        public DbSet<EmployeeJobHistory> EmployeeJobHistorys { get; set; }

        /// <summary>
        /// 班次表
        /// </summary>
        public DbSet<Shift> Shifts { get; set; }

        /// <summary>
        /// 值班类别表
        /// </summary>
        public DbSet<WorkType> WorkTypes { get; set; }

        public DbSet<ClinicMedicalRecordModel> ClinicMedicalRecordModels { get; set; }

        /// <summary>
        /// 医院信息
        /// </summary>
        public DbSet<HospitalMsg> HospitalMsgs { get; set; }


#pragma warning disable CS1591 // 缺少对公共可见类型或成员“HisContext.OnModelCreating(DbModelBuilder)”的 XML 注释
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“HisContext.OnModelCreating(DbModelBuilder)”的 XML 注释
        {
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            base.OnModelCreating(modelBuilder);

            // TPT mapping 
            modelBuilder.Entity<DoctorAdviceBase>().ToTable("tpt.DoctorAdviceBase");
            modelBuilder.Entity<MedicineDoctorAdvice>().ToTable("tpt.MedicineDoctorAdvice");
            modelBuilder.Entity<DoctorAdviceDetailBase>().ToTable("tpt.DoctorAdviceDetailBase");
            modelBuilder.Entity<MedicineDoctorAdviceDetail>().ToTable("tpt.MedicineDoctorAdviceDetail");

            modelBuilder.Entity<MaterialDoctorAdvice>().ToTable("tpt.MaterialDoctorAdvice");
            modelBuilder.Entity<MaterialDoctorAdviceDetail>().ToTable("tpt.MaterialDoctorAdviceDetail");
            modelBuilder.Entity<AssayDoctorAdvice>().ToTable("tpt.AssayDoctorAdvice");
            modelBuilder.Entity<AssayDoctorAdviceDetail>().ToTable("tpt.AssayDoctorAdviceDetail");
            modelBuilder.Entity<InspectDoctorAdvice>().ToTable("tpt.InspectDoctorAdvice");
            modelBuilder.Entity<InspectDoctorAdviceDetail>().ToTable("tpt.InspectDoctorAdviceDetail");

            modelBuilder.Entity<TherapyDoctorAdvice>().ToTable("tpt.TherapyDoctorAdvice");
            modelBuilder.Entity<TherapyDoctorAdviceDetail>().ToTable("tpt.TherapyDoctorAdviceDetail");

            modelBuilder.Entity<OtherServiceDoctorAdvice>().ToTable("tpt.OtherServiceDoctorAdvice");
            modelBuilder.Entity<OtherServiceDoctorAdviceDetail>().ToTable("tpt.OtherServiceDoctorAdviceDetail");

            modelBuilder.Entity<GoodsBase>().ToTable("tpt.GoodsBase");
            modelBuilder.Entity<Medicine>().ToTable("tpt.Medicine");
            modelBuilder.Entity<MaterialItem>().ToTable("tpt.MaterialItem");

            modelBuilder.Entity<StoreNumBase>().ToTable("tpt.StoreNumBase");
            modelBuilder.Entity<StoreRoomMedicineNum>().ToTable("tpt.StoreRoomMedicineNum");
            modelBuilder.Entity<StoreRoomMaterialNum>().ToTable("tpt.StoreRoomMaterialNum");

            modelBuilder.Entity<StoreOperateBillDetailBase>().ToTable("tpt.StoreOperateBillDetailBase");
            modelBuilder.Entity<MedicineInStoreDetail>().ToTable("tpt.MedicineInStoreDetail");
            modelBuilder.Entity<MedicineOutStoreDetail>().ToTable("tpt.MedicineOutStoreDetail");
            modelBuilder.Entity<MedicineCheckStoreDetail>().ToTable("tpt.MedicineCheckStoreDetail");
            modelBuilder.Entity<MaterialInStoreDetail>().ToTable("tpt.MaterialInStoreDetail");
            modelBuilder.Entity<MaterialOutStoreDetail>().ToTable("tpt.MaterialOutStoreDetail");
            modelBuilder.Entity<MaterialCheckStoreDetail>().ToTable("tpt.MaterialCheckStoreDetail");

            modelBuilder.Entity<StoreOperateBillBase>().ToTable("tpt.StoreOperateBillBase");
            modelBuilder.Entity<MedicineInStore>().ToTable("tpt.MedicineInStore");
            modelBuilder.Entity<MedicineOutStore>().ToTable("tpt.MedicineOutStore");
            modelBuilder.Entity<MedicineCheckStore>().ToTable("tpt.MedicineCheckStore");
            modelBuilder.Entity<MaterialInStore>().ToTable("tpt.MaterialInStore");
            modelBuilder.Entity<MaterialOutStore>().ToTable("tpt.MaterialOutStore");
            modelBuilder.Entity<MaterialCheckStore>().ToTable("tpt.MaterialCheckStore");

            modelBuilder.Entity<ChargeDetailBase>().ToTable("tpt.ChargeDetailBase");
            modelBuilder.Entity<MedicineChargeDetail>().ToTable("tpt.MedicineChargeDetail");
            modelBuilder.Entity<MaterialChargeDetail>().ToTable("tpt.MaterialChargeDetail");
            modelBuilder.Entity<TherapyChargeDetail>().ToTable("tpt.TherapyChargeDetail");
            modelBuilder.Entity<AssayChargeDetail>().ToTable("tpt.AssayChargeDetail");
            modelBuilder.Entity<InspectChargeDetail>().ToTable("tpt.InspectChargeDetail");
            modelBuilder.Entity<OtherServiceChargeDetail>().ToTable("tpt.OtherServiceChargeDetail");

            modelBuilder.Entity<ChargeBase>().ToTable("tpt.ChargeBase");
            modelBuilder.Entity<MedicineCharge>().ToTable("tpt.MedicineCharge");
            modelBuilder.Entity<MaterialCharge>().ToTable("tpt.MaterialCharge");
            modelBuilder.Entity<TherapyCharge>().ToTable("tpt.TherapyCharge");
            modelBuilder.Entity<AssayCharge>().ToTable("tpt.AssayCharge");
            modelBuilder.Entity<InspectCharge>().ToTable("tpt.InspectCharge");
            modelBuilder.Entity<OtherServiceCharge>().ToTable("tpt.OtherServiceCharge");

            modelBuilder.Entity<MyTableBase>().ToTable("tpt.MyTableBase");
            modelBuilder.Entity<InHospital>().ToTable("tpt.InHospital");
            modelBuilder.Entity<InHospitalPatientDoctor>().ToTable("tpt.InHospitalPatientDoctor");
            modelBuilder.Entity<LeaveHospital>().ToTable("tpt.LeaveHospital");
            modelBuilder.Entity<RecallHospital>().ToTable("tpt.RecallHospital");

            modelBuilder.Entity<InjectionBill>().ToTable("tpt.InjectionBill");

            modelBuilder.Entity<PatientCardManage>().ToTable("tpt.PatientCardManage");

            modelBuilder.Entity<PatientCardPrePay>().ToTable("tpt.PatientCardPrePays");
        }
    }
}
