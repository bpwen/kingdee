using System;

namespace FIN.Model.outboundOrder
{
    /// <summary>
    /// 销售出库单 Model
    /// </summary>
    [Serializable]
    public partial class outboundOrderModel
    {
        public outboundOrderModel()
        { }

        #region 【销售组织】
        private string _FSaleOrgId;
        /// <summary>
        /// 销售组织(必填项)：如100
        /// </summary>
        public string FSaleOrgId
        {
            set { _FSaleOrgId = value; }
            get { return _FSaleOrgId; }
        }
        #endregion

        #region 【日期】
        private string _FDATE;
        /// <summary>
        /// 日期(必填项)
        /// </summary>
        public string FDATE
        {
            set { _FDATE = value; }
            get { return _FDATE; }
        }
        #endregion

        #region 【发货组织】
        private string _FStockOrgId;
        /// <summary>
        /// 发货组织(必填项)：如100
        /// </summary>
        public string FStockOrgId
        {
            set { _FStockOrgId = value; }
            get { return _FStockOrgId; }
        }
        #endregion

        #region 【客户】
        private string _FCustomerID;
        /// <summary>
        /// 客户(必填项)：如00001
        /// </summary>
        public string FCustomerID
        {
            set { _FCustomerID = value; }
            get { return _FCustomerID; }
        }
        #endregion

        #region 【单据类型】
        private string _FBillTypeID;
        /// <summary>
        /// 单据类型(必填项)：如XSCKD01_SYS
        /// </summary>
        public string FBillTypeID
        {
            set { _FBillTypeID = value; }
            get { return _FBillTypeID; }
        }
        #endregion

        #region 【结算组织】
        private string _FSettleOrgID;
        /// <summary>
        /// 结算组织(必填项)：如100  //这个是销售出库单选项卡财务信息里面
        /// </summary>
        public string FSettleOrgID
        {
            set { _FSettleOrgID = value; }
            get { return _FSettleOrgID; }
        }
        #endregion

        #region 【结算币别】
        private string _FSettleCurrID;
        /// <summary>
        /// 结算币别(必填项)：如PRE001
        /// </summary>
        public string FSettleCurrID
        {
            set { _FSettleCurrID = value; }
            get { return _FSettleCurrID; }
        }
        #endregion

        #region 【本位币】
        private string _FLocalCurrID;
        /// <summary>
        /// 本位币(必填项)：如PRE001    //选项卡上面那个财务信息　PRE001　为人民币
        /// </summary>
        public string FLocalCurrID
        {
            set { _FLocalCurrID = value; }
            get { return _FLocalCurrID; }
        }
        #endregion

        #region 【汇率类型】
        private string _FExchangeTypeID;
        /// <summary>
        /// 汇率类型(必填项)：如HLTX01_SYS　//选项卡上面那个财务信息　TX01_SYS　为固定费率
        /// </summary>
        public string FExchangeTypeID
        {
            set { _FExchangeTypeID = value; }
            get { return _FExchangeTypeID; }
        }
        #endregion

        #region 【明细信息】
        private string _FEntity;
        /// <summary>
        /// 明细信息
        /// </summary>
        public string FEntity
        {
            set { _FEntity = value; }
            get { return _FEntity; }
        }
        #endregion

        #region 【】
        private string _FOwnerTypeIdHead; 
        public string FOwnerTypeIdHead
        {
            set { _FOwnerTypeIdHead = value; }
            get { return _FOwnerTypeIdHead; }
        }
        #endregion
    }
}