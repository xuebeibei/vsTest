using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public enum InHospitalApplyEnum
    {
        未处理,
        已处理
    }
}
