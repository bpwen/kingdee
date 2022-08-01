using FIN.Model.warehouse;
using System;
using System.Collections.Generic;

namespace FIN.Model.stock
{
    /// <summary>
    /// 即时库存
    /// </summary>
    [Serializable]
    public partial class stockModel
    {
        public stockModel()
        { }
        /// <summary>
        /// 仓库内码
        /// </summary>
        //public string FStockId { set; get; }

        /// <summary>
        /// 代码
        /// </summary>
        long _count = 0;
        public long count {
            set { _count = value; }
            get { return _count; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public List<AwarehouseModel> list { set; get; }
    }
}
