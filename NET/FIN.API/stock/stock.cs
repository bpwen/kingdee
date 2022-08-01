using System;
using System.Collections.Generic;
using FIN.API.organization;
using FIN.API.warehouse;
using FIN.BPW;
using FIN.Model.organization;
using FIN.Model.SDK;
using FIN.Model.SDK.View;
using FIN.Model.stock;
using FIN.Model.warehouse;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FIN.API.stock
{
    /// <summary>
    /// 即时库存
    /// </summary>
    public class stock
    {
        stockModel stockModel = new stockModel();

        ExecuteBillQuery ExecuteModel = new ExecuteBillQuery();

        organizationAPI organizationAPI = new organizationAPI();
        organizationModel organizationModel = new organizationModel();

        ViewModel ViewModel = new ViewModel();

        Return Return = new Return();
        warehouseAPI warehouseAPI = new warehouseAPI();

        AwarehouseModel AwarehouseModel = new AwarehouseModel();
        BwarehouseModel BwarehouseModel = new BwarehouseModel();

        #region 【获取商品库存】
        /// <summary>
        /// 获取商品库存
        /// </summary>
        /// <returns></returns>
        public JObject count()
        {
            #region 【组织机构】
            string FUseOrgId = Request.Form("FNumber");
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

            string fmaterialid = Request.Form("fmaterialid");
            if (fmaterialid == "")
            {
                return Response.error("缺少商品编号");
            }

            string fstockid = Request.Form("fstockid");
            if(fstockid != "")
            {
                ViewModel.Number = fstockid;
                Return = warehouseAPI.GetModel(ViewModel, 1);
                if (Return.Message != "")
                {
                    return Response.error(Return.Message);
                }
                else
                {
                    BwarehouseModel = JsonConvert.DeserializeObject<BwarehouseModel>(json.parse(Return.GetModel));
                    fstockid = BwarehouseModel.FStockId.ToString();
                }
            }

            stockModel = count(fmaterialid, fstockid, FUseOrgId);

            return Response.GetModel(stockModel);
        }
        /// <summary>
        /// 获取商品库存
        /// </summary>
        /// <param name="fmaterialid">商品编号</param>
        /// <param name="fstockid">仓库编号 注解：为空则查询商品总数量，不为空则指定查询商品某仓库数量</param>
        /// <param name="FUseOrgId">组织机构编码</param>
        /// <returns></returns>
        public stockModel count(string fmaterialid, string fstockid, string FUseOrgId)
        {
            ExecuteModel.FormId = "STK_Inventory";
            ExecuteModel.FieldKeys = "FBaseQty,FStockId";
            //string FilterString = "FStockOrgId=" + FUseOrgId + " and FMaterialId=" + fmaterialid;
            string FilterString = "FMaterialId=" + fmaterialid;
            if (fstockid != "")
            {
                FilterString += " and FStockId=" + fstockid;
            }
            ExecuteModel.FilterString = FilterString;

            string data = SDK.ExecuteBillQuery(ExecuteModel);
            JArray array = (JArray)JsonConvert.DeserializeObject(data);
            if (array.Count != 0)
            {
                long Count = 0;
                List<AwarehouseModel> Model = new List<AwarehouseModel>();
                for (int i = 0; i < array.Count; i++)
                {
                    string _count = array[i][0].ToString();
                    if (!IF.Null(_count) && _count != "0")
                    {
                        Count += Convert.ToInt32(_count);

                        ViewModel.Id = array[i][1].ToString();
                        Return = warehouseAPI.GetModel(ViewModel, 0);

                        AwarehouseModel = JsonConvert.DeserializeObject<AwarehouseModel>(json.parse(Return.GetModel));

                        Model.Add(new AwarehouseModel()
                        {
                            FName = AwarehouseModel.FName,
                            FNumber = AwarehouseModel.FNumber,
                            Count = _count
                        });
                    }
                }

                stockModel.count = Count;
                stockModel.list = Model;

            }

            return stockModel;
        }
        #endregion
    }
}
