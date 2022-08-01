using System;

namespace FIN.Model.SDK.View
{
    /// <summary>
    /// 金蝶查看Model
    /// </summary>
    [Serializable]
    public partial class ViewModel
    {
        public ViewModel()
        { }
        #region Model
        
        private int _CreateOrgId = 0;
        /// <summary>
        /// 创建者组织内码（非必录)
        /// </summary>
        public int CreateOrgId
        {
            set { _CreateOrgId = value; }
            get { return _CreateOrgId; }
        }

        private string _Number = "";
        /// <summary>
        /// 单据编码，字符串类型（使用编码时必录）
        /// </summary>
        public string Number
        {
            set { _Number = value; }
            get { return _Number; }
        }

        private string _Id = "";
        /// <summary>
        /// Id：表单内码（使用内码时必录）
        /// </summary>
        public string Id
        {
            set { _Id = value; }
            get { return _Id; }
        }

        #endregion Model
    }
}
