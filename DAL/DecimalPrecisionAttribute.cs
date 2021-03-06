﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// <para>自定义Decimal类型的精度属性</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalPrecisionAttribute : Attribute
    {
        #region Field
        private byte _precision = 18;
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“DecimalPrecisionAttribute._scale”的 XML 注释
        public byte _scale = 4;
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“DecimalPrecisionAttribute._scale”的 XML 注释
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
}
