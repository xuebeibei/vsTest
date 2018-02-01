using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace DAL
{
    public enum GenderEnum { man, woman };
    public enum VolkEnum { hanzu, other };
    public enum SeeDoctorStatusEnum { 未到诊, 候诊中, 接诊中, 接诊结束, 申请入院 };
    public enum TriageStatusEnum { no, yes };
    public enum JobEnum
    {
        初级,        // 初级
        中级,         // 中级
        高级          // 高级
    }
    public enum DepartmentEnum
    {
        其他科室,     // 其他科室
        临床科室, // 临床科室
        医技科室       // 医技科室  
    }

    public enum MedicineTypeEnum
    {
        xiyao,
        zhongchengyao,
        zhongyao
    }
    public enum YiBaoEnum
    {
        jia,
        yi,
        feijiafeiyi
    }

    public enum UsageEnum
    {
        口服,
        注射
    }

    public enum DDDSEnum
    {
        一日1次,
        一日2次,
        一日3次
    }

    /// <summary>
    /// <para>自定义Decimal类型的精度属性</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalPrecisionAttribute : Attribute
    {
        #region Field
        private byte _precision = 18;
        public byte _scale = 4;
        #endregion

        #region Construct
        /// <summary>
        /// <para>自定义Decimal类型的精确度属性</para>
        /// </summary>
        /// <param name="precision">precision
        /// <para>精度（默认18）</para></param>
        /// <param name="scale">scale
        /// <para>小数位数（默认4）</para></param>
        public DecimalPrecisionAttribute(byte precision = 18, byte scale = 4)
        {
            Precision = precision;
            Scale = scale;
        }
        #endregion

        #region Property
        /// <summary>
        /// 精确度（默认18）
        /// </summary>
        public byte Precision
        {
            get { return this._precision; }
            set { this._precision = value; }
        }

        /// <summary>
        /// 保留位数（默认4）
        /// </summary>
        public byte Scale
        {
            get { return this._scale; }
            set { this._scale = value; }
        }
        #endregion
    }

    /// <summary>
    /// 用于modelBuilder全局设置自定义精度属性
    /// </summary>
    public class DecimalPrecisionAttributeConvention
        : PrimitivePropertyAttributeConfigurationConvention<DecimalPrecisionAttribute>
    {
        public override void Apply(ConventionPrimitivePropertyConfiguration configuration, DecimalPrecisionAttribute attribute)
        {
            if (attribute.Precision < 1 || attribute.Precision > 38)
            {
                throw new InvalidOperationException("Precision must be between 1 and 38.");
            }
            if (attribute.Scale > attribute.Precision)
            {
                throw new InvalidOperationException("Scale must be between 0 and the Precision value.");
            }
            configuration.HasPrecision(attribute.Precision, attribute.Scale);
        }
    }

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
        public DbSet<Inpatient> Inpatients { get; set; }
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

        public DbSet<RecipeChargeBill> RecipeChargeBills { get; set; }
        public DbSet<RecipeChargeDetail> RecipeChargeDetails { get; set; }

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
        }
    }

    public enum SignalTimeEnum
    {
        上午,
        下午,
        晚上
    }

    public enum PayWayEnum
    {
        账户支付,
        现金支付
    }

    public enum RecipeTypeEnum
    {
        PuTong,             // 普通处方
        JiZhen,             // 急诊处方
        ErKe,               // 儿科处方  
        MaJingYi,           // 麻精一   
        JingEr              // 精二  
    }

    public enum DoctorAdviceContentEnum
    {
        XiChengYao,
        ZhongYao
    }

    public enum ChargeStatusEnum
    {
        未收费,
        部分收费,
        全部收费
    }

    public enum DosageFormEnum
    {
        片剂,
        颗粒,
        水剂
    }

    public enum MedicalRecordEnum
    {
        MenZhen,              // 门诊病历
        RuYuan,               // 入院记录 
        BingCheng,            // 病程记录
        ChuYuan,              // 出院记录
        BiangAnShouYe         // 病案首页 
    }
    
    public enum BaoXianEnum
    {
        自费,
        城乡居民医保,
        城镇职工医保
    }

    public enum MarriageEnum
    {
        未婚,
        已婚,
        离异,
        丧偶
    }

    public enum IllnesSstateEnum
    {
        危,
        急,
        一般
    }

    public enum InHospitalStatusEnum
    {
        未入院,
        在院中,
        已出院
    }
    public enum InStoreEnum
    {
        采购入库,
        赠与入库,
        其他入库
    }

    public enum ReCheckStatusEnum
    {
        待审核,
        已审核
    }
    
    public enum OutStoreEnum
    {
        科室出库,
        报损出库,
        分销出库,
        退货出库,
        其他出库
    }
    public enum StoreRoomEnum
    {
        一级库,
        二级库,
        三级库
    }
    
    public enum SickRoomEnum
    {
        普通病房,
        重症病房
    }

    public enum PrePayWayEnum
    {
        现金,
        支付宝,
        微信
    }
}
