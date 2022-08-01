using System.Collections.Generic;

namespace FIN.Model.outboundOrder
{
    /// <summary>
    /// 接收传递过来的JSON
    /// </summary>
    public class Add
    {
        /// <summary>
        /// 客户编码
        /// 客户编码是添加客户的时候回返值
        /// </summary>
        public string FCustomerID { set; get; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public string FNumber { set; get; }
        /// <summary>
        /// 仓库代码
        /// </summary>
        public string FStockID { set; get; }
        public List<Add_list> list { get; set; }
    }

    public class Add_list
    {
        /// <summary>
        /// 实发数量:用户购买数量
        /// </summary>
        public string FRealQty { set; get; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string FMaterialID { set; get; }
        /// <summary>
        /// 库存单位(必填项)：如UOM001   //选项卡下面那个明细里面
        /// </summary>
        public string FUnitID { set; get; }
        /// <summary>
        /// 货主类型(必填项)：如BD_OwnerOrg   //选项卡下面那个物料数据里面
        /// </summary>
        public string FOwnerTypeID { set; get; }
        /// <summary>
        /// 货主(必填项)：如100    //选项卡下面那个物料数据里面
        /// </summary>
        public int FOwnerID { set; get; }
        /// <summary>
        /// 仓库(必填项)：如002    选项卡下面那个明细里面 KCZT01_SYS 表示可用
        /// </summary>
        public string FStockID { set; get; }
        /// <summary>
        /// 库存状态(必填项)：如KCZT01_SYS   选项卡下面那个明细里面 KCZT01_SYS 表示可用
        /// </summary>
        public string FStockStatusID { set; get; }
    }
}
