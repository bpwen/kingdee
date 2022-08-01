using System;

namespace FIN.Model.customer
{
    /// <summary>
    /// 客户添加
    /// </summary>
    [Serializable]
    public class customerModel
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string FName { get; set; }

        #region 【创建组织】
        /// <summary>
        /// 创建组织
        /// </summary>
        public string FCreateOrgId { get; set; }
        #endregion

        #region 【使用组织】
        /// <summary>
        /// 使用组织
        /// </summary>
        public string FUseOrgId { get; set; }
        #endregion

        /// <summary>
        /// 手机号码
        /// </summary>
        public string FTEL { get; set; }

        #region 【客户类别】
        string _FCustTypeId = "T";
        /// <summary>
        /// 客户类别
        /// </summary>
        public string FCustTypeId
        {
            set { _FCustTypeId = value; }
            get { return _FCustTypeId; }
        }
        #endregion

        #region 【客户分组】
        string _FGroup = "AP";
        /// <summary>
        /// 客户分组
        /// </summary>
        public string FGroup
        {
            set { _FGroup = value; }
            get { return _FGroup; }
        }
        #endregion

        #region 【客户分组】
        string _FTRADINGCURRID = "PRE001";
        /// <summary>
        /// 结算币别
        /// </summary>
        public string FTRADINGCURRID
        {
            set { _FTRADINGCURRID = value; }
            get { return _FTRADINGCURRID; }
        }
        #endregion

        #region 【价目表】
        string _FPRICELISTID = "XSJMB0002";
        /// <summary>
        /// 价目表
        /// </summary>
        public string FPRICELISTID
        {
            set { _FPRICELISTID = value; }
            get { return _FPRICELISTID; }
        }
        #endregion

        /// <summary>
        /// 通讯地址
        /// </summary>
        public string FADDRESS { get; set; }

        #region 【加盟时间】
        /// <summary>
        /// 加盟时间
        /// </summary>
        public string F_PAEZ_Date { get; set; }
        #endregion

        /// <summary>
        /// 客户来源归属地没有则IP地址
        /// </summary>
        public string F_PAEZ_Text3 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FDescription { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string F_PAEZ_Text1 { get; set; }


        public string JSON()
        {
            string arr = "{";
            arr += "	\"NeedUpDateFields\": [],";
            arr += "	\"NeedReturnFields\": [],";
            arr += "	\"IsDeleteEntry\": \"true\",";
            arr += "	\"SubSystemId\": \"\",";
            arr += "	\"IsVerifyBaseDataField\": \"false\",";
            arr += "	\"IsEntryBatchFill\": \"true\",";
            arr += "	\"ValidateFlag\": \"true\",";
            arr += "	\"NumberSearch\": \"true\",";
            arr += "	\"IsAutoAdjustField\": \"false\",";
            arr += "	\"InterationFlags\": \"\",";
            arr += "	\"IgnoreInterationFlag\": \"\",";
            arr += "	\"Model\": {";
            arr += "		\"FCUSTID\": 0,";
            arr += "		\"FCreateOrgId\": {";
            arr += "			\"FNumber\": \""+ FCreateOrgId + "\"";
            arr += "		},";
            arr += "		\"FUseOrgId\": {";
            arr += "			\"FNumber\": \""+ FUseOrgId + "\"";
            arr += "		},";
            arr += "		\"FName\": \""+ FName + "\",";
            arr += "		\"FCOUNTRY\": {";
            arr += "			\"FNumber\": \"China\"";
            arr += "		},";
            arr += "		\"FADDRESS\": \"" + FADDRESS + "\",";
            arr += "		\"FTEL\": \"" + FTEL + "\",";
            arr += "		\"FINVOICETITLE\": \"" + FName + "\",";
            arr += "		\"FIsGroup\": false,";
            arr += "		\"FIsDefPayer\": false,";
            arr += "		\"FCustTypeId\": {";
            arr += "			\"FNumber\": \""+ FCustTypeId + "\"";
            arr += "		},";
            arr += "		\"FGroup\": {";
            arr += "			\"FNumber\": \""+ FGroup + "\"";
            arr += "		},";
            arr += "		\"FTRADINGCURRID\": {";
            arr += "			\"FNumber\": \""+ FTRADINGCURRID + "\"";
            arr += "		},";
            arr += "		\"FPRICELISTID\": {";
            arr += "			\"FNumber\": \""+ FPRICELISTID + "\"";
            arr += "		},";
            arr += "		\"FDescription\": \""+ FDescription + "\",";
            arr += "		\"FInvoiceType\": \"1\",";
            arr += "		\"FTaxType\": {";
            arr += "			\"FNumber\": \"SFL02_SYS\"";
            arr += "		},";
            arr += "		\"FPriority\": 1,";
            arr += "		\"FTaxRate\": {";
            arr += "			\"FNumber\": \"SL02_SYS\"";
            arr += "		},";
            arr += "		\"FISCREDITCHECK\": true,";
            arr += "		\"FIsTrade\": true,";
            arr += "		\"FUncheckExpectQty\": false,";
            arr += "		\"F_PAEZ_Date\": \""+ F_PAEZ_Date + "\",";
            arr += "		\"F_PAEZ_CheckBox\": false,";
            arr += "		\"F_PAEZ_Text1\": \""+ F_PAEZ_Text1 + "\",";
            arr += "		\"F_PAEZ_Base\": {";
            arr += "			\"FNUMBER\": \"W\"";
            arr += "		},";
            arr += "		\"F_PAEZ_Text3\": \""+ F_PAEZ_Text3 + "\",";
            arr += "		\"FT_BD_CUSTOMEREXT\": {";
            arr += "			\"FEnableSL\": false,";
            arr += "			\"FALLOWJOINZHJ\": false";
            arr += "		}";
            arr += "	}";
            arr += "}";

            return arr;
        }
    }
}
