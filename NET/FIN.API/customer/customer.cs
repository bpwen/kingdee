using FIN.API.organization;
using FIN.BPW;
using FIN.Model.customer;
using FIN.Model.organization;
using FIN.Model.SDK;
using FIN.Model.SDK.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FIN.API.customer
{
    /// <summary>
    /// 客户
    /// </summary>
    public class customer
    {
        string Key = "BD_Customer";
        SubmitModel SubmitModel = new SubmitModel();
        customerModel customerModel = new customerModel();
        ExecuteBillQuery ExecuteModel = new ExecuteBillQuery();

        organizationAPI organizationAPI = new organizationAPI();
        organizationModel organizationModel = new organizationModel();

        #region 【添加客户】
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <returns></returns>
        public JObject Add()
        {
            #region 【组织机构】
            string FUseOrgId = Request.Form("FNumber");
            if (FUseOrgId == "")
            {
                return Response.error("缺少组织机构");
            }
            else
            {
                organizationModel = organizationAPI.GetModel("", FUseOrgId);
                if (organizationModel == null)
                {
                    return Response.error("该组织机构不存在");
                }
                else
                {
                    FUseOrgId = organizationModel.FNumber;
                }
            }
            customerModel.FCreateOrgId = FUseOrgId;
            customerModel.FUseOrgId = FUseOrgId;
            #endregion

            string FName = Request.Form("FName");
            if(FName == "")
            {
                return Response.error("缺少客户姓名");
            }
            customerModel.FName = FName;

            string FTEL = Request.Form("FTEL");
            if (FTEL == "")
            {
                return Response.error("缺少客户电话号码");
            }
            customerModel.FTEL = FTEL;
            customerModel.F_PAEZ_Date = Time.val("yyyy-MM-dd HH:mm:ss");

            string F_PAEZ_Text3 = Request.Form("customer_source");
            if (F_PAEZ_Text3 == "")
            {
                return Response.error("缺少客户来源");
            }
            customerModel.F_PAEZ_Text3 = F_PAEZ_Text3;

            customerModel.FADDRESS = Request.Form("FADDRESS");
            customerModel.FDescription = Request.Form("FDescription");
            customerModel.F_PAEZ_Text1 = Request.Form("IDcard");

            #region 【去判断客户姓名是否已存在】
            Dictionary<string, string> ExistsArray = GetModel(FName, FTEL, "", customerModel.F_PAEZ_Text1, organizationModel.Id);
            if (ExistsArray != null)
            {
                return Response.error("客户已存在");
            }
            #endregion

            string msg = SDK.Save(Key, customerModel.JSON());

            string Message = SDK.Result(msg);
            if (Message != "")
            {
                return Response.error(Message);
            }
            else
            {
                result result = JsonConvert.DeserializeObject<result>(msg);

                Dictionary<string, object> array = new Dictionary<string, object>();
                array["Number"] = result.Result.Number;
                SubmitModel.Numbers = array["Number"].ToString();
                SDK.Submit(Key, SubmitModel);
                SDK.Audit(Key, SubmitModel);

                return Response.GetModel(array);
            }
        }
        #endregion

        #region 【获取客户存在否】
        /// <summary>
        /// 获取客户存在否
        /// </summary>
        /// <returns></returns>
        public JObject Exists()
        {
            string FName = Request.Form("FName");
            string FTEL = Request.Form("FTEL");
            string IDcard = Request.Form("IDcard");

            #region 【组织机构】
            string FUseOrgId = Request.Form("FNumberid");
            //if (FUseOrgId == "")
            //{
            //    return Response.error("缺少组织机构");
            //}
            //else
            //{
            //    organizationModel = organizationAPI.GetModel("", FUseOrgId);
            //    if (organizationModel == null)
            //    {
            //        return Response.error("该组织机构不存在");
            //    }
            //    else
            //    {
            //        FUseOrgId = organizationModel.Id;
            //    }
            //}
            #endregion

            string FNUMBER = Request.Form("FNUMBER");
            if (FNUMBER == "")
            {
                if (FName == "" && IDcard == "")
                {
                    return Response.error("缺少客户名称");
                }
            }
            
            if (FNUMBER == "" && FTEL == "" && IDcard == "")
            {
                return Response.error("手机号码或客户编码,身份证必须传递一个");
            }

            Dictionary<string, string> array = GetModel(FName, FTEL, FNUMBER, IDcard, FUseOrgId);
            return Response.GetModel(array);
        }

        /// <summary>
        /// 获取客户存在否
        /// </summary>
        /// <param name="FName">客户姓名</param>
        /// <param name="FTEL">手机号</param>
        /// <param name="FNUMBER">客户编码</param>
        /// <param name="F_PAEZ_Text1">身份证</param>
        /// <param name="FUseOrgId">使用组织</param>
        /// <returns></returns>
        public Dictionary<string, string> GetModel(string FName, string FTEL, string FNUMBER, string F_PAEZ_Text1, string FUseOrgId)
        {
            ExecuteModel.FormId = Key;
            ExecuteModel.FieldKeys = "FCUSTID,FNUMBER,FName,FTEL,F_PAEZ_Text1";
            //string FilterString = "FUSEORGID="+ FUseOrgId + " and FName='" + FName + "' and FTEL='" + FTEL + "'";
            //if(FNUMBER != "")
            //{
            //    FilterString = "FUSEORGID=" + FUseOrgId + " and FNUMBER='" + FNUMBER + "'";
            //}

            //if(F_PAEZ_Text1 != "")
            //{
            //    FilterString = "FUSEORGID=" + FUseOrgId + " and F_PAEZ_Text1='" + F_PAEZ_Text1 + "'";
            //}

            string FilterString = "FName='" + FName + "' and FTEL='" + FTEL + "'";
            if (FNUMBER != "")
            {
                FilterString = "FNUMBER='" + FNUMBER + "'";
            }

            if (F_PAEZ_Text1 != "")
            {
                FilterString = "F_PAEZ_Text1='" + F_PAEZ_Text1 + "'";
            }

            ExecuteModel.FilterString = FilterString;
            string data = SDK.ExecuteBillQuery(ExecuteModel);

            JArray rs = (JArray)JsonConvert.DeserializeObject(data);
            Dictionary<string, string> array = new Dictionary<string, string>();
            if (rs.Count != 0)
            {
                //array["Id"] = rs[0][0].ToString();
                array["Number"] = rs[0][1].ToString();
                //array["FName"] = rs[0][2].ToString();
                //array["FTEL"] = rs[0][3].ToString();
                //array["IDcard"] = rs[0][4].ToString();

                return array;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
