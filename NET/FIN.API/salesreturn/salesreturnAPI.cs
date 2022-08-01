using FIN.BPW;
using FIN.Model.SDK;
using FIN.Model.SDK.Model;
using FIN.Model.SDK.Pushdown;
using FIN.Model.SDK.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FIN.API.salesreturn
{
    /// <summary>
    /// 销售退货单
    /// </summary>
    public class salesreturnAPI
    {
        string Key = "SAL_RETURNSTOCK";
        ViewModel ViewModel = new ViewModel();
        Return Return = new Return();
        SubmitModel SubmitModel = new SubmitModel();
        SdkModel Model = new SdkModel();

        result result = new result();
        outboundOrder.outboundOrder outboundOrder = new outboundOrder.outboundOrder();
        PushdownModel PushdownModel = new PushdownModel();

        public JObject Add()
        {
            #region 【出库单编码】
            string Number = Request.Form("Number");
            if (Number == null)
            {
                return Response.error("缺少出库单编码");
            }
            #endregion

            #region 【客户】
            string FCustomerID = Request.Form("FCustomerID");
            if (FCustomerID == null)
            {
                return Response.error("缺少客户编码");
            }
            #endregion

            #region 【查询出库单是否存在】
            ViewModel.Number = Number;
            string msg = SDK.View("SAL_OUTSTOCK", ViewModel);
            string Message = SDK.Result(msg);
            if (Message != "")
            {
                return Response.error(Message);
            }
            #endregion

            result = JsonConvert.DeserializeObject<result>(msg);

            #region 【判断客户编码是否和出库单的客户一样不】
            if (FCustomerID != result.Result.Result.CustomerID.Number)
            {
                return Response.error("无权限操作");
            }
            #endregion

            #region 【下推】
            PushdownModel.Numbers = ViewModel.Number;
            PushdownModel.RuleId = "OutStock-SalReturnStock";
            Return = outboundOrder.Pushdown(PushdownModel);
            if (Return.Message != "")
            {
                return Response.error(Return.Message);
            }
            else
            {
                result = JsonConvert.DeserializeObject<result>(Return.GetModel.ToString());
            }
            #endregion

            Model.Id = result.Result.ResponseStatus.SuccessEntitys[0].Id;
            Model.Number = result.Result.ResponseStatus.SuccessEntitys[0].Number;
            Model.IsSuccess = result.Result.ResponseStatus.IsSuccess;

            SubmitModel.Numbers = Model.Number;

            SDK.Submit(Key, SubmitModel);
            SDK.Audit(Key, SubmitModel);

            return Response.GetModel(Model);
        }
    }
}
