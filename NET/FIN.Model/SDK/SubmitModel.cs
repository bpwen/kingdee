using System;

namespace FIN.Model.SDK
{
    /// <summary>
    /// 金蝶提交Model
    /// </summary>
    [Serializable]
    public partial class SubmitModel
    {
        public SubmitModel()
        { }
        #region Model

        private int _CreateOrgId = 0;
        /// <summary>
        /// 创建者组织内码（非必录）
        /// </summary>
        public int CreateOrgId
        {
            set { _CreateOrgId = value; }
            get { return _CreateOrgId; }
        }

        private string _Numbers = "";
        /// <summary>
        /// 单据编码集合，数组类型，格式：[No1,No2,...]（使用编码时必录）
        /// </summary>
        public string Numbers
        {
            set { _Numbers = value; }
            get { return _Numbers; }
        }

        private string _Ids = "";
        /// <summary>
        /// 单据内码集合，字符串类型，格式："Id1,Id2,..."（使用内码时必录）
        /// </summary>
        public string Ids
        {
            set { _Ids = value; }
            get { return _Ids; }
        }

        private int _SelectedPostId = 0;
        /// <summary>
        /// 工作流发起员工岗位内码，整型（非必录） 注（员工身兼多岗时不传参默认取第一个岗位）
        /// </summary>
        public int SelectedPostId
        {
            set { _SelectedPostId = value; }
            get { return _SelectedPostId; }
        }

        private string _NetworkCtrl = "";
        /// <summary>
        /// 是否启用网控，布尔类型，默认false（非必录）
        /// </summary>
        public string NetworkCtrl
        {
            set { _NetworkCtrl = value; }
            get { return _NetworkCtrl; }
        }

        private string _IgnoreInterationFlag = "";
        /// <summary>
        /// 是否允许忽略交互，布尔类型，默认true（非必录）
        /// </summary>
        public string IgnoreInterationFlag
        {
            set { _IgnoreInterationFlag = value; }
            get { return _IgnoreInterationFlag; }
        }

        #endregion Model
    }
}
