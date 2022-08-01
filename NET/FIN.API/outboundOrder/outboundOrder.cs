using FIN.API.IDL;
using FIN.API.organization;
using FIN.BPW;
using FIN.Model.organization;
using FIN.Model.outboundOrder;
using FIN.Model.SDK;
using FIN.Model.SDK.Model;
using FIN.Model.SDK.Pushdown;
using FIN.Model.SDK.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FIN.API.outboundOrder
{
    /// <summary>
    /// 销售出库单
    /// </summary>
    public class outboundOrder
    {
        string Key = "SAL_OUTSTOCK";
        View View = new View();
        Data AddData = new Data();
        Add_list AddList = new Add_list();
        SdkModel SdkModel = new SdkModel();
        ViewModel ViewModel = new ViewModel();
        Return Return = new Return();
        SubmitModel SubmitModel = new SubmitModel();
        outboundOrderModel M_Model = new outboundOrderModel();
        customer.customer customer = new customer.customer();
        SdkModel Model = new SdkModel();

        organizationAPI organizationAPI = new organizationAPI();
        organizationModel organizationModel = new organizationModel();

        #region 【添加出库单-保存】
        /// <summary>
        /// 添加出库单-保存
        /// </summary>
        /// <returns></returns>
        public JObject Add(Add dataJson)
        {
            #region 【组织机构】
            if (dataJson.FNumber == null)
            {
                return Response.error("缺少组织机构");
            }
            else
            {
                organizationModel = organizationAPI.GetModel("", dataJson.FNumber);
                if (organizationModel == null)
                {
                    return Response.error("该组织机构不存在");
                }
            }
            #endregion

            #region 【客户】
            if (dataJson.FCustomerID == null)
            {
                return Response.error("缺少客户编码");
            }
            else
            {
                Dictionary<string, string> FCustomerID = customer.GetModel("", "", dataJson.FCustomerID, "", organizationModel.Id);
                if (FCustomerID == null)
                {
                    return Response.error("客户不存在");
                }
            }
            M_Model.FCustomerID = dataJson.FCustomerID;
            #endregion

            #region 【仓库】
            if (dataJson.FStockID == null)
            {
                return Response.error("缺少仓库编码");
            }
            #endregion

            if (dataJson.list == null || dataJson.list.Count == 0)
            {
                return Response.error("缺少商品列表");
            }

            #region 【商品循环】
            string FEntity = "";
            if (dataJson.list.Count != 0)
            {
                M_Model.FSaleOrgId = organizationModel.FNumber;
                M_Model.FDATE = Time.val("yyyy-MM-dd HH:mm:ss");
                M_Model.FStockOrgId = organizationModel.FNumber;
                M_Model.FBillTypeID = "XSCKD01_SYS";
                M_Model.FSettleOrgID = organizationModel.FNumber;

                M_Model.FSettleCurrID = "PRE001";
                M_Model.FLocalCurrID = "PRE001";

                M_Model.FExchangeTypeID = "HLTX01_SYS";
                M_Model.FOwnerTypeIdHead = "BD_OwnerOrg";


                int Count = dataJson.list.Count;
                for (int i = 0; i < Count; i++)
                {
                    AddList = dataJson.list[i];
                    if (AddList.FRealQty == null)
                    {
                        return Response.error("缺少实发数量");
                    }

                    #region 【物料查询】
                    if (AddList.FMaterialID == null)
                    {
                        return Response.error("缺少物料ID");
                    }

                    ViewModel.Id = AddList.FMaterialID;
                    View.Key = "BD_MATERIAL";
                    Return = View.GetModel(ViewModel);
                    if (Return.Message != "")
                    {
                        return Response.error(Return.Message);
                    }
                    else
                    {
                        SdkModel = JsonConvert.DeserializeObject<SdkModel>(json.parse(Return.GetModel));
                    }

                    AddList.FUnitID = SdkModel.unit.Number;
                    AddList.FMaterialID = SdkModel.Number;
                    #endregion

                    AddList.FStockID = dataJson.FStockID;
                    AddList.FOwnerTypeID = M_Model.FOwnerTypeIdHead;
                    AddList.FOwnerID = 101;
                    AddList.FStockStatusID = "KCZT01_SYS";
                    FEntity += AddData.FEntity(AddList);

                    if(i != (Count - 1))
                    {
                        FEntity += ",";
                    }
                }
            }
            #endregion

            M_Model.FEntity = FEntity;

            string Data = AddData.Add(M_Model);
            string msg = SDK.Save(Key, Data);

            string Message = SDK.Result(msg);
            if (Message != "")
            {
                return Response.error(Message);
            }
            else
            {
                result result = JsonConvert.DeserializeObject<result>(msg);
                Model.Id = result.Result.Id;
                Model.Number = result.Result.Number;
                Model.IsSuccess = result.Result.ResponseStatus.IsSuccess;
                SubmitModel.Numbers = Model.Number;
                SDK.Submit(Key, SubmitModel);
                SDK.Audit(Key, SubmitModel);

                return Response.GetModel(Model);
            }
        }
        #endregion

        #region 【查询是否单据编号存在】
        /// <summary>
        /// 查询是否单据编号存在
        /// </summary>
        /// <returns></returns>
        public JObject Exists()
        {
            View.Key = Key;
            JObject Str = View.GetModel();

            json.port port = JsonConvert.DeserializeObject<json.port>(Str.ToString());

            if(port.data == null)
            {
                return Response.GetModel(false);
            }
            else
            {
                return Response.GetModel(true);
            }
        }
        #endregion

        #region 【下推到销售退货单】
        public Return Pushdown(PushdownModel _PushdownModel)
        {
            string msg = SDK.Pushdown(Key, _PushdownModel);
            string Message = SDK.Result(msg);
            if (Message != "")
            {
                Return.Message = Message;
            }
            else
            {
                Return.GetModel = msg;
            }
            return Return;
        }
        #endregion
    }
}
