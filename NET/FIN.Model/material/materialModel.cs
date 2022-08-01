using System;

namespace FIN.Model.material
{
    /// <summary>
    /// 用户
    /// </summary>
    [Serializable]
    public partial class materialModel
    {
        public materialModel()
        { }
        /// <summary>
        /// id
        /// </summary>
        public string Id { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string FName { set; get; }
    }
}
