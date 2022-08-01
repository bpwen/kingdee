using System;

namespace FIN.Model.SDK
{
    /// <summary>
    /// 金蝶单据查询 Model
    /// </summary>
    [Serializable]
    public partial class ExecuteBillQuery
    {
        public ExecuteBillQuery()
        { }

        #region Model

        private string _formIde;
        /// <summary>
        /// 业务对象表单Id（必录）
        /// </summary>
        public string FormId
        {
            set { _formIde = value; }
            get { return _formIde; }
        }

        private string _fieldKeys;
        /// <summary>
        /// 需查询的字段key集合，字符串类型，格式："key1,key2,..."（必录） 注（查询单据体内码,需加单据体Key和下划线,如：FEntryKey_FEntryId）
        /// </summary>
        public string FieldKeys
        {
            set { _fieldKeys = value; }
            get { return _fieldKeys; }
        }

        private string _filterString;
        /// <summary>
        /// 过滤条件，数组类型，如：[{"Left":"(","FieldName":"Field1","Compare":"=","Value":"111","Right":")","Logic":"AND"},
        /// </summary>
        public string FilterString
        {
            set { _filterString = value; }
            get { return _filterString; }
        }

        private string _orderString = "";
        /// <summary>
        /// 排序字段，字符串类型（非必录）
        /// </summary>
        public string OrderString
        {
            set { _orderString = value; }
            get { return _orderString; }
        }

        private int _topRowCount;
        /// <summary>
        /// 返回总行数，整型（非必录）
        /// </summary>
        public int TopRowCount
        {
            set { _topRowCount = value; }
            get { return _topRowCount; }
        }

        private int _startRow;
        /// <summary>
        /// 开始行索引，整型（非必录）
        /// </summary>
        public int StartRow
        {
            set { _startRow = value; }
            get { return _startRow; }
        }

        private int _limit;
        /// <summary>
        /// 最大行数，整型，不能超过2000（非必录）
        /// </summary>
        public int Limit
        {
            set { _limit = value; }
            get { return _limit; }
        }

        private string _subSystemId = "";
        /// <summary>
        /// 表单所在的子系统内码，字符串类型（非必录）
        /// </summary>
        public string SubSystemId
        {
            set { _subSystemId = value; }
            get { return _subSystemId; }
        }

        #endregion Model
    }
}