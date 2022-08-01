using System;

namespace FIN.Model.SDK.Pushdown
{
    /// <summary>
    /// 金蝶下推 Model
    /// </summary>
    [Serializable]
    public partial class PushdownModel
    {
        public PushdownModel()
        { }
        #region Model

        private string _Ids = "";
        /// <summary>
        /// 单据内码集合，字符串类型，格式："Id1,Id2,..."（使用内码时必录）
        /// </summary>
        public string Ids
        {
            set { _Ids = value; }
            get { return _Ids; }
        }

        private string _Number = "";
        /// <summary>
        /// 单据编码集合，数组类型，格式：[No1,No2,...]（使用编码时必录）
        /// </summary>
        public string Numbers
        {
            set { _Number = value; }
            get { return _Number; }
        }

        private string _EntryIds = "";
        /// <summary>
        /// 分录内码集合，逗号分隔（分录下推时必录） 注（按分录下推时，单据内码和编码不需要填,否则按整单下推）
        /// </summary>
        public string EntryIds
        {
            set { _EntryIds = value; }
            get { return _EntryIds; }
        }

        #region 【RuleId】
        private string _RuleId = "";
        /// <summary>
        /// 转换规则内码，字符串类型（未启用默认转换规则时，则必录）
        /// </summary>
        public string RuleId
        {
            set { _RuleId = value; }
            get { return _RuleId; }
        }
        #endregion

        #region 【TargetBillTypeId】
        private string _TargetBillTypeId = "";
        /// <summary>
        /// 目标单据类型内码，字符串类型（非必录）
        /// </summary>
        public string TargetBillTypeId
        {
            set { _TargetBillTypeId = value; }
            get { return _TargetBillTypeId; }
        }
        #endregion

        #region 【TargetOrgId】
        private int _TargetOrgId = 0;
        /// <summary>
        /// 目标组织内码，整型（非必录）
        /// </summary>
        public int TargetOrgId
        {
            set { _TargetOrgId = value; }
            get { return _TargetOrgId; }
        }
        #endregion

        #region 【TargetFormId】
        private string _TargetFormId = "";
        /// <summary>
        /// 目标单据FormId，字符串类型，（启用默认转换规则时，则必录）
        /// </summary>
        public string TargetFormId
        {
            set { _TargetFormId = value; }
            get { return _TargetFormId; }
        }
        #endregion

        #region 【IsEnableDefaultRule】
        private bool _IsEnableDefaultRule = false;
        /// <summary>
        /// 是否启用默认转换规则，布尔类型，默认false（非必录）
        /// </summary>
        public bool IsEnableDefaultRule
        {
            set { _IsEnableDefaultRule = value; }
            get { return _IsEnableDefaultRule; }
        }
        #endregion

        #region 【IsDraftWhenSaveFail】
        private bool _IsDraftWhenSaveFail = false;
        /// <summary>
        /// 保存失败时是否暂存，布尔类型，默认false（非必录）  注（暂存的单据是没有编码的）
        /// </summary>
        public bool IsDraftWhenSaveFail
        {
            set { _IsDraftWhenSaveFail = value; }
            get { return _IsDraftWhenSaveFail; }
        }
        #endregion

        #region 【CustomParams】
        private string _CustomParams = "";
        /// <summary>
        /// 自定义参数，字典类型，格式："{key1:value1,key2:value2,...}"（非必录）  注（传到转换插件的操作选项中，平台不会解析里面的值）
        /// </summary>
        public CustomParamsA CustomParams{set; get;}
        #endregion

        #endregion Model
    }

    public class CustomParamsA{
    }

}
