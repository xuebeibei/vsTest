using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DAL
{
    public class HisContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SignalSource> SignalSources { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Triage> Triages { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        //public DbSet<Inpatient> Inpatients { get; set; }
        public DbSet<AssayItem> AssayItems { get; set; }
        public DbSet<Specimen> Specimens { get; set; }
        public DbSet<InspectItem> InspectItems { get; set; }
        public DbSet<BodyRegion> BodyRegions { get; set; }
        public DbSet<TherapyItem> TherapyItems { get; set; }
        public DbSet<MaterialItem> MaterialItems { get; set; }
        public DbSet<OtherServiceItem> OtherServiceItem { get; set; }
        public DbSet<MedicineInStore> MedicineInStores { get; set; }
        public DbSet<MedicineInStoreDetail> MedicineInStoreDetails { get; set; }
        public DbSet<MedicineOutStore> MedicineOutStores { get; set; }
        public DbSet<MedicineOutStoreDetail> MedicineOutStoreDetails { get; set; }
        public DbSet<MedicineCheckStore> MedicineCheckStores { get; set; }
        public DbSet<MedicineCheckStoreDetail> MedicineCheckStoreDetails { get; set; }

        public DbSet<MaterialInStore> MaterialInStores { get; set; }
        public DbSet<MaterialInStoreDetail> MaterialInStoreDetails { get; set; }
        public DbSet<MaterialOutStore> MaterialOutStores { get; set; }
        public DbSet<MaterialOutStoreDetail> MaterialOutStoreDetails { get; set; }
        public DbSet<MaterialCheckStore> MaterialCheckStores { get; set; }
        public DbSet<MaterialCheckStoreDetail> MaterialCheckStoreDetails { get; set; }

        public DbSet<StoreRoom> StoreRooms { get; set; }
        public DbSet<StoreNumBase> StoreNumBases { get; set; }
        public DbSet<StoreRoomMedicineNum> StoreRoomMedicineNums { get; set; }
        public DbSet<StoreRoomMaterialNum> StoreRoomMaterialNums { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<SickRoom> SickRooms { get; set; }
        public DbSet<SickBed> SickBeds { get; set; }

        public DbSet<PrePay> PrePays { get; set; }

        public DbSet<MedicineDoctorAdvice> MedicineDoctorAdvices { get; set; }
        public DbSet<MaterialDoctorAdvice> MaterialDoctorAdvices { get; set; }

        public DbSet<AssayDoctorAdvice> AssayDoctorAdvices { get; set; }
        public DbSet<InspectDoctorAdvice> InspectDoctorAdvices { get; set; }

        public DbSet<TherapyDoctorAdvice> TherapyDoctorAdvices { get; set; }

        public DbSet<OtherServiceDoctorAdvice> OtherServiceDoctorAdvices { get; set; }
        public DbSet<SignalItem> SignalItems { get; set; }

        public DbSet<DoctorAdviceBase> DoctorAdviceBases { get; set; }

        public DbSet<GoodsBase> GoodsBases { get; set; }

        public DbSet<ChargeDetailBase> ChargeDetailBases { get; set; }
        public DbSet<MedicineChargeDetail> MedicineChargeDetails { get; set; }
        public DbSet<MaterialChargeDetail> MaterialChargeDetails { get; set; }
        public DbSet<TherapyChargeDetail> TherapyChargeDetails { get; set; }
        public DbSet<AssayChargeDetail> AssayChargeDetails { get; set; }
        public DbSet<InspectChargeDetail> InspectChargeDetails { get; set; }
        public DbSet<OtherServiceChargeDetail> OtherServiceChargeDetails { get; set; }

        public DbSet<ChargeBase> ChargeBases { get; set; }
        public DbSet<MedicineCharge> MedicineCharges { get; set; }
        public DbSet<MaterialCharge> MaterialCharges { get; set; }
        public DbSet<TherapyCharge> TherapyCharges { get; set; }
        public DbSet<AssayCharge> AssayCharges { get; set; }
        public DbSet<InspectCharge> InspectCharges { get; set; }
        public DbSet<OtherServiceCharge> OtherServiceCharges { get; set; }

        public DbSet<InHospitalApply> InHospitalApplys { get; set; }

        public DbSet<MyTableBase> MyTableBases { get; set; }
        public DbSet<InHospital> InHospitals { get; set; }
        public DbSet<InHospitalPatientDoctor> InHospitalPatientDoctor { get; set; }
        public DbSet<LeaveHospital> LeaveHospitals { get; set; }
        public DbSet<RecallHospital> RecallHospitals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
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
        }
    }
}
