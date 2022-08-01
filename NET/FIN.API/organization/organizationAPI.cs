using FIN.BPW;
using FIN.Model.organization;
using FIN.Model.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FIN.API.organization
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public class organizationAPI
    {
        string Key = "ORG_Organizations";
        ExecuteBillQuery ExecuteModel = new ExecuteBillQuery();
        organizationModel organizationModel = new organizationModel();

        /// <summary>
        /// 组织机构列表
        /// </summary>
        /// <returns></returns>
        public JObject List()
        {
            ExecuteModel.FormId = Key;
            ExecuteModel.FieldKeys = "FParentID,FNumber,FName";
            string FilterString = "FDocumentStatus='C' and FForbidStatus='A'";
            string FName = Request.Form("FName");
            if (FName != "")
            {
                FilterString += " and FName like '%" + FName + "%'";
            }
            ExecuteModel.FilterString = FilterString;
            string data = SDK.ExecuteBillQuery(ExecuteModel);
            JArray rs = (JArray)JsonConvert.DeserializeObject(data);
            List<organizationModel> Model = new List<organizationModel>();
            if (rs.Count != 0)
            {
                for (int i = 0; i < rs.Count; i++)
                {
                    Model.Add(new organizationModel()
                    {
                        Id = rs[i][0].ToString(),
                        FNumber = rs[i][1].ToString(),
                        FName = rs[i][2].ToString()
                    });
                }
            }
            return Response.GetModel(Model);
        }


        #region 【查看组织机构详情】
        /// <summary>
        /// 查看组织机构详情
        /// </summary>
        /// <returns></returns>
        public JObject GetModel()
        {
            string FParentID = Request.Form("FParentID");
            string FNumber = Request.Form("FNumber");
            if (FParentID == "" & FNumber == "")
            {
                return Response.error("缺少ID或编码");
            }

            organizationModel = GetModel(FParentID, FNumber);


            return Response.GetModel(organizationModel);
        }

        public organizationModel GetModel(string FParentID, string FNumber)
        {
            ExecuteModel.FormId = Key;
            ExecuteModel.FieldKeys = "FParentID,FNumber,FName";
            string FilterString = "FDocumentStatus='C' and FForbidStatus='A'";
            if (FParentID != "")
            {
                FilterString += " and FParentID='"+ FParentID + "'";
            }
            if (FNumber != "")
            {
                FilterString += " and FNumber='" + FNumber + "'";
            }

            ExecuteModel.FilterString = FilterString;
            string data = SDK.ExecuteBillQuery(ExecuteModel);
            JArray rs = (JArray)JsonConvert.DeserializeObject(data);
            if (rs.Count != 0)
            {
                organizationModel = new organizationModel()
                {
                    Id = rs[0][0].ToString(),
                    FNumber = rs[0][1].ToString(),
                    FName = rs[0][2].ToString()
                };
                return organizationModel;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
