using FIN.API.organization;
using FIN.BPW;
using FIN.Model.organization;
using FIN.Model.SDK;
using FIN.Model.SDK.Model;
using FIN.Model.SDK.View;
using FIN.Model.warehouse;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FIN.API.warehouse
{
    /// <summary>
    /// 仓库列表
    /// </summary>
    public class warehouseAPI
    {
        string Key = "BD_STOCK";
        Return Return = new Return();
        ExecuteBillQuery ExecuteModel = new ExecuteBillQuery();

        organizationAPI organizationAPI = new organizationAPI();
        organizationModel organizationModel = new organizationModel();

        AwarehouseModel AwarehouseModel = new AwarehouseModel();
        BwarehouseModel BwarehouseModel = new BwarehouseModel();

        /// <summary>
        /// 获取仓库列表
        /// </summary>
        /// <returns></returns>
        public JObject List()
        {
            #region 【组织机构】
            string FUseOrgId = Request.Form("FNumber");
            if(FUseOrgId == "")
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
            ExecuteModel.FieldKeys = "FStockId,FName,FNumber";
            string FilterString = "FUseOrgId=" + FUseOrgId + " and FDocumentStatus='C' and FForbidStatus='A'";
            string FName = Request.Form("FName");
            if (FName != "")
            {
                FilterString += " and FName like '%" + FName + "%'";
            }
            ExecuteModel.FilterString = FilterString;
            string data = SDK.ExecuteBillQuery(ExecuteModel);
            JArray rs = (JArray)JsonConvert.DeserializeObject(data);
            List<warehouseModel> Model = new List<warehouseModel>();
            if (rs.Count != 0)
            {
                for (int i = 0; i < rs.Count; i++)
                {
                    Model.Add(new warehouseModel()
                    {
                        //FStockId = rs[i][0].ToString(),
                        FNumber = rs[i][2].ToString(),
                        FName = rs[i][1].ToString()
                    });
                }
            }
            return Response.GetModel(Model);
        }

        #region 【项目其他地方调用返回Return】
        /// <summary>
        /// 项目其他地方调用返回Return
        /// </summary>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        public Return GetModel(ViewModel ViewModel, int type)
        {
            string msg = SDK.View(Key, ViewModel);
            string Message = SDK.Result(msg);
            if (Message != "")
            {
                Return.Message = Message;
            }
            else
            {
                if (type == 0)
                {
                    Return.GetModel = GetModel(msg);
                }
                else if(type == 1)
                {
                    Return.GetModel = GetModelA(msg);
                }
            }
            return Return;
        }
        #endregion

        #region 【返回成功后的数据】
        /// <summary>
        /// 返回成功后的数据
        /// </summary>
        /// <returns></returns>
        public AwarehouseModel GetModel(string msg)
        {
            result result = JsonConvert.DeserializeObject<result>(msg);
            ResultB Result = result.Result.Result;

            AwarehouseModel.FNumber = Result.Number;
            AwarehouseModel.FName = Result.Name[0].Value;

            return AwarehouseModel;
        }
        public BwarehouseModel GetModelA(string msg)
        {
            result result = JsonConvert.DeserializeObject<result>(msg);
            ResultB Result = result.Result.Result;

            BwarehouseModel.FStockId = Result.Id;
            BwarehouseModel.FNumber = Result.Number;
            BwarehouseModel.FName = Result.Name[0].Value;

            return BwarehouseModel;
        }
        #endregion
    }
}