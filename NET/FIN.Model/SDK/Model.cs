using System;

namespace FIN.Model.SDK.Model
{
    /// <summary>
    /// 金蝶数据回调
    /// </summary>
    [Serializable]
    public class SdkModel
    {
        public SdkModel() { }

        public int Id { set; get; }
        public string Name { set; get; }
        public string Number { set; get; }

        public bool IsSuccess { set; get; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { set; get; }
        /// <summary>
        /// 单位
        /// </summary>
        public Unit unit { set; get; }
        /// <summary>
        /// 币种
        /// </summary>
        public Currency currency { set; get; }
    }

    /// <summary>
    /// 单位
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 单位编码
        /// </summary>
        public string Number { set; get; }
    }

    /// <summary>
    /// 币种
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// 单位名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 单位编码
        /// </summary>
        public string Number { set; get; }
    }
}
