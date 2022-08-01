using FIN.API.IDL;
using FIN.API.organization;
using FIN.BPW;
using FIN.Model.material;
using FIN.Model.organization;
using FIN.Model.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FIN.API.material
{
    /// <summary>
    /// 物料API接口
    /// </summary>
    public class materialAPI
    {
        string Key = "BD_MATERIAL";
        View View = new View();
        ExecuteBillQuery ExecuteModel = new ExecuteBillQuery();

        organizationAPI organizationAPI = new organizationAPI();
        organizationModel organizationModel = new organizationModel();

        /// <summary>
        /// 获取物料列表
        /// </summary>
        /// <returns></returns>
        public JObject List()
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
                    FUseOrgId = organizationModel.Id;
                }
            }
            #endregion

            ExecuteModel.FormId = Key;
            ExecuteModel.FieldKeys = "FMATERIALID,FName,FMASTERID";
            string FilterString = "FUSEORGID=" + FUseOrgId + " and FDocumentStatus='C' and FForbidStatus='A'";
            string FName = Request.Form("FName");
            if (FName != "")
            {
                FilterString += " and FName like '%"+ FName + "%'";
            }
            ExecuteModel.FilterString = FilterString;
            string data = SDK.ExecuteBillQuery(ExecuteModel);
            JArray rs = (JArray)JsonConvert.DeserializeObject(data);
            List<materialModel> Model = new List<materialModel>();
            if (rs.Count != 0)
            {
                for (int i = 0; i < rs.Count; i++)
                {
                    Model.Add(new materialModel()
                    {
                        //Id = rs[i][0].ToString(),
                        Id = rs[i][2].ToString(),
                        FName = rs[i][1].ToString()
                    });
                }
            }
            return Response.GetModel(Model);
        }


        #region 【获取对象实体】
        /// <summary>
        /// 获取对象实体
        /// </summary>
        /// <returns></returns>
        public JObject GetModel()
        {
            View.Key = Key;
            return View.GetModel();
        }
        #endregion
    }
}
