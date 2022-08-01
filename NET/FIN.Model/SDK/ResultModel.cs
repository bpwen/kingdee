using System.Collections.Generic;

namespace FIN.Model.SDK.View
{
    #region 【】
    /// <summary>
    /// 错误信息
    /// </summary>
    public partial class Return
    {
        public Return()
        { }

        #region Model

        private string _Message = "";
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message
        {
            set { _Message = value; }
            get { return _Message; }
        }

        private object _GetModel = null;
        /// <summary>
        /// 对象实体
        /// </summary>
        public object GetModel
        {
            set { _GetModel = value; }
            get { return _GetModel; }
        }

        #endregion Model

    }
    #endregion

    #region 【】
    public class resultAB
    {
        public ResultAB Result { set; get; }
    }
    public class ResultAB
    {
        public ResponseStatusAB ResponseStatus { set; get; }
    }
    public class ResponseStatusAB
    {
        public int ErrorCode { set; get; }
        public bool IsSuccess { set; get; }
        public List<ErrorsA> Errors { set; get; }
        public List<SuccessEntitysA> SuccessEntitys { set; get; }
        public List<SuccessMessagesA> SuccessMessages { set; get; }
        public int MsgCode { set; get; }
    }
    #endregion

    #region 【】
    public class result
    {
        public ResultA Result { set; get; }
    }

    public class ResultA
    {
        public ResponseStatusA ResponseStatus { set; get; }
        public int Id { set; get; }
        public string Number { set; get; }
        public List<NeedReturnDataA> NeedReturnData { set; get; }
        public ResultB Result { set; get; }
    }

    public class ResponseStatusA
    {
        public int ErrorCode { set; get; }
        public bool IsSuccess { set; get; }
        public List<ErrorsA> Errors { set; get; }
        public List<SuccessEntitysA> SuccessEntitys { set; get; }
        public List<SuccessMessagesA> SuccessMessages { set; get; }
        public int MsgCode { set; get; }
    }

    public class ErrorsA
    {
        public string FieldName { set; get; }
        public string Message { set; get; }
        public int DIndex { set; get; }
    }

    public class SuccessEntitysA
    {
        public int Id { set; get; }
        public string Number { set; get; }
        public int DIndex { set; get; }
    }

    public class SuccessMessagesA
    {
       
    }

    public class NeedReturnDataA
    { 
    
    }

    public class ResultB
    {
        public int Id { set; get; }
        public List<KeyValue> Name { set; get; }
        public string Number { set; get; }
        public List<KeyValue> Specification { set; get; }
        /// <summary>
        /// 单位
        /// </summary>
        public List<MaterialStockA> MaterialStock { set; get; }
        /// <summary>
        /// 企业
        /// </summary>
        public SaleOrgIdA SaleOrgId { set; get; }

        /// <summary>
        /// 客户
        /// </summary>
        public CustomerIDA CustomerID { set; get; }
    }

    public class KeyValue
    {
        public int Key { set; get; }
        public string Value { set; get; }
    }

    public class MaterialStockA
    {
        public StoreUnitIDA StoreUnitID { set; get; }
        public CurrencyIdA CurrencyId { set; get; }
    }

    public class StoreUnitIDA
    {
        public List<KeyValue> Name { set; get; }
        public string Number { set; get; }
    }

    public class CurrencyIdA
    {
        public List<KeyValue> Name { set; get; }
        public string Number { set; get; }
    }

    /// <summary>
    /// 企业
    /// </summary>
    public class SaleOrgIdA
    {
        public int Id { set; get; }
        public List<KeyValue> Name { set; get; }
        public string Number { set; get; }
    }

    /// <summary>
    /// 客户
    /// </summary>
    public class CustomerIDA
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public List<KeyValue> Name { set; get; }
        /// <summary>
        /// 客户编码
        /// </summary>
        public string Number { set; get; }
        /// <summary>
        /// 电话
        /// </summary>
        public string TEL { set; get; }
    }

    #endregion
}
