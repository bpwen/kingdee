using System;

namespace FIN.Model.organization
{
    /// <summary>
    /// 组织机构
    /// </summary>
    [Serializable]
    public partial class organizationModel
    {
        public organizationModel()
        { }
        /// <summary>
        /// id
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        public string FNumber { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FName { set; get; }
    }
}
