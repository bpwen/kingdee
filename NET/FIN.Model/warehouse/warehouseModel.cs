using System;

namespace FIN.Model.warehouse
{
    /// <summary>
    /// 获取仓库列表
    /// </summary>
    [Serializable]
    public partial class warehouseModel
    {
        public warehouseModel()
        { }
        /// <summary>
        /// 代码
        /// </summary>
        public string FNumber { set; get; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string FName { set; get; }
    }

    public partial class AwarehouseModel
    {
        public AwarehouseModel()
        { }
        /// <summary>
        /// 仓库内码
        /// </summary>
        //public string FStockId { set; get; }
        /// <summary>
        /// 代码
        /// </summary>
        public string FNumber { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FName { set; get; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public string Count { set; get; }
    }

    public partial class BwarehouseModel
    {
        public BwarehouseModel()
        { }
        /// <summary>
        /// 仓库内码
        /// </summary>
        public int FStockId { set; get; }

        /// <summary>
        /// 代码
        /// </summary>
        public string FNumber { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FName { set; get; }
    }
}
