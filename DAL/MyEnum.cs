using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum GenderEnum
    {
        /// <summary>
        /// 男
        /// </summary>
        man,
        /// <summary>
        /// 女
        /// </summary>
        woman
    };
    /// <summary>
    /// 民族
    /// </summary>
    public enum VolkEnum
    {
        /// <summary>
        /// 未填
        /// </summary>
        unKnow,
        /// <summary>
        /// 汉族
        /// </summary>
        hanzu,
        /// <summary>
        /// 少数民族
        /// </summary>
        other
    };
    /// <summary>
    /// 看诊状态
    /// </summary>
    public enum SeeDoctorStatusEnum
    {
        /// <summary>
        /// 已经成功挂号却未到达分诊台标记到诊
        /// </summary>
        未到诊,
        /// <summary>
        /// 已经到达分诊台进行标记到诊
        /// </summary>
        候诊中,
        /// <summary>
        /// 医生已经开始接诊
        /// </summary>
        接诊中,
        /// <summary>
        /// 正常结束门诊接诊
        /// </summary>
        接诊结束,
        /// <summary>
        /// 以申请入院而结束门诊接诊
        /// </summary>
        申请入院
    };
    /// <summary>
    /// 分诊状态，已经不用
    /// </summary>
    public enum TriageStatusEnum
    {
        /// <summary>
        /// 未分诊
        /// </summary>
        no,
        /// <summary>
        /// 已分诊
        /// </summary>
        yes
    };
    /// <summary>
    /// 职位等级
    /// </summary>
    public enum JobEnum
    {
        /// <summary>
        /// 最初级，受中级管制
        /// </summary>
        初级,
        /// <summary>
        /// 中级，受高级管制
        /// </summary>
        中级,
        /// <summary>
        /// 高级，可以管制中级和初级
        /// </summary>
        高级
    }
    /// <summary>
    /// 部门种类
    /// </summary>
    public enum DepartmentEnum
    {
        /// <summary>
        /// 除了临床和医技之外的部门,例如库房等
        /// </summary>
        其他科室,
        /// <summary>
        /// 临床，例如内科、外科等
        /// </summary>
        临床科室,
        /// <summary>
        /// 医技科室，例如化验室等
        /// </summary>
        医技科室
    }

    /// <summary>
    /// 药品种类
    /// </summary>
    public enum MedicineTypeEnum
    {
        /// <summary>
        /// 西药
        /// </summary>
        xiyao,
        /// <summary>
        /// 中成药
        /// </summary>
        zhongchengyao,
        /// <summary>
        /// 中药
        /// </summary>
        zhongyao
    }

    /// <summary>
    /// 医保分类
    /// </summary>
    public enum YiBaoEnum
    {
        /// <summary>
        /// 甲类
        /// </summary>
        jia,
        /// <summary>
        /// 乙类
        /// </summary>
        yi,
        /// <summary>
        /// 非甲乙类
        /// </summary>
        feijiafeiyi
    }
    /// <summary>
    /// 药品用法，用以产生注射单，暂时未用到
    /// </summary>
    public enum UsageEnum
    {
        /// <summary>
        /// 口服
        /// </summary>
        口服,
        /// <summary>
        /// 注射
        /// </summary>
        注射
    }
    /// <summary>
    /// 用药频率，用以提示患者正确服药，暂时未用到
    /// </summary>
    public enum DDDSEnum
    {
        /// <summary>
        /// 一日1次
        /// </summary>
        一日1次,
        /// <summary>
        /// 一日2次
        /// </summary>
        一日2次,
        /// <summary>
        /// 一日3次
        /// </summary>
        一日3次
    }
    /// <summary>
    /// 看诊时段
    /// </summary>
    public enum SignalTimeEnum
    {
        /// <summary>
        /// 上午
        /// </summary>
        上午,
        /// <summary>
        /// 下午
        /// </summary>
        下午,
        /// <summary>
        /// 晚上
        /// </summary>
        晚上
    }
    /// <summary>
    /// 患者在收费出收取费用时候的支付方式
    /// </summary>
    public enum PayWayEnum
    {
        /// <summary>
        /// 使用患者就诊卡中的余额支付
        /// </summary>
        账户支付,
        /// <summary>
        /// 使用现金支付
        /// </summary>
        现金支付
    }
    /// <summary>
    /// 处方类别，处方管理办法规定的类别，暂时未用到
    /// </summary>
    public enum RecipeTypeEnum
    {
        /// <summary>
        /// 普通处方
        /// </summary>
        PuTong,
        /// <summary>
        /// 急诊处方
        /// </summary>
        JiZhen,
        /// <summary>
        /// 儿科处方 
        /// </summary>
        ErKe,
        /// <summary>
        /// 麻精一
        /// </summary>
        MaJingYi,
        /// <summary>
        /// 精二
        /// </summary>
        JingEr
    }
    /// <summary>
    /// 处方内容类别
    /// </summary>
    public enum DoctorAdviceContentEnum
    {
        /// <summary>
        /// 西药和中成药处方
        /// </summary>
        XiChengYao,
        /// <summary>
        /// 中药处方
        /// </summary>
        ZhongYao
    }
    /// <summary>
    /// 医嘱单的收费情况
    /// </summary>
    public enum ChargeStatusEnum
    {
        /// <summary>
        /// 未收取费用
        /// </summary>
        未收费,
        /// <summary>
        /// 部分收取费用,当医嘱的实效较长的时候，暂时未用
        /// </summary>
        部分收费,
        /// <summary>
        /// 全部收费
        /// </summary>
        全部收费
    }
    /// <summary>
    /// 药品剂型
    /// </summary>
    public enum DosageFormEnum
    {
        /// <summary>
        /// 片剂
        /// </summary>
        片剂,
        /// <summary>
        /// 颗粒
        /// </summary>
        颗粒,
        /// <summary>
        /// 水剂
        /// </summary>
        水剂
    }
    /// <summary>
    /// 病例类别，暂时未用
    /// </summary>
    public enum MedicalRecordEnum
    {
        /// <summary>
        /// 门诊病例
        /// </summary>
        MenZhen,
        /// <summary>
        /// 入院记录,暂时未用
        /// </summary>
        RuYuan,              
        /// <summary>
        /// 病程记录
        /// </summary>
        BingCheng,  
        /// <summary>
        /// 出院记录
        /// </summary>
        ChuYuan,              
        /// <summary>
        /// 病案首页
        /// </summary>
        BiangAnShouYe
    }
    /// <summary>
    /// 医保类别
    /// </summary>
    public enum BaoXianEnum
    {
        /// <summary>
        /// 自费
        /// </summary>
        自费,
        /// <summary>
        /// 城乡居民医保
        /// </summary>
        城乡居民医保,
        /// <summary>
        /// 城乡居民医保
        /// </summary>
        城镇职工医保
    }
    /// <summary>
    /// 婚姻状况
    /// </summary>
    public enum MarriageEnum
    {
        /// <summary>
        /// 未婚
        /// </summary>
        未婚,
        /// <summary>
        /// 已婚
        /// </summary>
        已婚,
        /// <summary>
        /// 离异
        /// </summary>
        离异,
        /// <summary>
        /// 丧偶
        /// </summary>
        丧偶
    }
    /// <summary>
    /// 病情状况
    /// </summary>
    public enum IllnesSstateEnum
    {
        /// <summary>
        /// 病危
        /// </summary>
        危,
        /// <summary>
        /// 紧急
        /// </summary>
        急,
        /// <summary>
        /// 一般
        /// </summary>
        一般
    }
    /// <summary>
    /// 住院状态
    /// </summary>
    public enum InHospitalStatusEnum
    {
        /// <summary>
        /// 未入院
        /// </summary>
        未入院,
        /// <summary>
        /// 在院，不可以门诊
        /// </summary>
        在院中,
        /// <summary>
        /// 已出院
        /// </summary>
        已出院
    }
    /// <summary>
    /// 入库方式
    /// </summary>
    public enum InStoreEnum
    {
        /// <summary>
        /// 采购入库
        /// </summary>
        采购入库,
        /// <summary>
        /// 赠与入库
        /// </summary>
        赠与入库,
        /// <summary>
        /// 其他入库
        /// </summary>
        其他入库
    }
    /// <summary>
    /// 审核状态
    /// </summary>
    public enum ReCheckStatusEnum
    {
        /// <summary>
        /// 等待审核
        /// </summary>
        待审核,
        /// <summary>
        /// 审核通过
        /// </summary>
        已审核
    }
    /// <summary>
    /// 出库方式
    /// </summary>
    public enum OutStoreEnum
    {
        /// <summary>
        /// 科室领取
        /// </summary>
        科室出库,
        /// <summary>
        /// 报损
        /// </summary>
        报损出库,
        /// <summary>
        /// 向下级医疗单位分销
        /// </summary>
        分销出库,
        /// <summary>
        /// 退货
        /// </summary>
        退货出库,
        /// <summary>
        /// 其他
        /// </summary>
        其他出库
    }
    /// <summary>
    /// 库房等级
    /// </summary>
    public enum StoreRoomEnum
    {
        /// <summary>
        /// 一级库，总药库等
        /// </summary>
        一级库,
        /// <summary>
        /// 二级库，门诊药房、住院药房等
        /// </summary>
        二级库,
        /// <summary>
        /// 三级库科室库房等
        /// </summary>
        三级库
    }
    /// <summary>
    /// 病房类别
    /// </summary>
    public enum SickRoomEnum
    {
        /// <summary>
        /// 普通病房
        /// </summary>
        普通病房,
        /// <summary>
        /// 重症病房
        /// </summary>
        重症病房
    }
    /// <summary>
    /// 缴款方式，用于患者在给自己的就诊卡充值时候
    /// </summary>
    public enum PrePayWayEnum
    {
        /// <summary>
        /// 现金支付
        /// </summary>
        现金,
        /// <summary>
        /// 支付宝便捷支付
        /// </summary>
        支付宝,
        /// <summary>
        /// 微信便捷支付
        /// </summary>
        微信
    }
    /// <summary>
    /// 申请状态
    /// </summary>
    public enum InHospitalApplyEnum
    {
        /// <summary>
        /// 未处理
        /// </summary>
        未处理,
        /// <summary>
        /// 已经处理
        /// </summary>
        已处理
    }
    /// <summary>
    /// 护士执行医嘱状态
    /// </summary>
    public enum ExecuteEnum
    {
        /// <summary>
        /// 未执行
        /// </summary>
        未执行,
        /// <summary>
        /// 已执行，已执行医嘱不能撤销，不能修改，对应收费单不能退费
        /// </summary>
        已执行
    }
}
