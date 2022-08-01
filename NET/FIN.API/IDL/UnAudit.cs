using FIN.BPW;
using FIN.Model.SDK.View;
using FIN.Model.SDK.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FIN.Model.SDK;
using System.Collections.Generic;

namespace FIN.API.IDL
{
    /// <summary>
    /// 反审核
    /// </summary>
    public class UnAudit
    {
        SdkModel Model = new SdkModel();
        SubmitModel SubmitModel = new SubmitModel();
        Return Return = new Return();

        public string Key { get; set; }

        #region 【反审核-执行】
        /// <summary>
        /// 反审核-执行
        /// </summary>
        /// <returns></returns>
        public JObject Execute()
        {
            string Number = Request.Form("Number");
            if (Number == "")
            {
                return Response.error("缺少单据编码!");
            }

            SubmitModel.Numbers = Number;

            Return = Execute(SubmitModel);
            if (Return.Message != "")
            {
                return Response.error(Return.Message);
            }
            else
            {
                return Response.GetModel(Return.GetModel);
            }
        }
        #endregion

        #region 【项目其他地方调用返回ResultModel】
        /// <summary>
        /// 项目其他地方调用返回ResultModel
        /// </summary>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        public Return Execute(SubmitModel SubmitModel)
        {
            string msg = SDK.UnAudit(Key, SubmitModel);
            string Message = SDK.Result(msg);
            if (Message != "")
            {
                Return.Message = Message;
            }
            else
            {
                Return.GetModel = Execute(msg);
            }
            return Return;
        }
        #endregion

        #region 【返回成功后的数据】
        /// <summary>
        /// 返回成功后的数据
        /// </summary>
        /// <returns></returns>
        public SdkModel Execute(string msg)
        {
            result result = JsonConvert.DeserializeObject<result>(msg);
            List<SuccessEntitysA> SuccessEntitys = result.Result.ResponseStatus.SuccessEntitys;

            Model.Id = SuccessEntitys[0].Id;
            Model.Number = SuccessEntitys[0].Number;
            Model.IsSuccess = result.Result.ResponseStatus.IsSuccess;

            return Model;
        }
        #endregion
    }
}