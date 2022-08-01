using FIN.BPW;
using FIN.Model.SDK.View;
using FIN.Model.SDK.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FIN.API.IDL
{
    /// <summary>
    /// 查看
    /// </summary>
    public class View
    {
        Unit Unit = new Unit();
        Currency Currency = new Currency();
        SdkModel Model = new SdkModel();
        ViewModel ViewModel = new ViewModel();
        Return Return = new Return();

        public string Key { get; set; }

        #region 【查看返回JSON】
        /// <summary>
        /// 查看返回JSON
        /// </summary>
        /// <returns></returns>
        public JObject GetModel()
        {
            string Number = Request.Form("Number");
            string Id = Request.Form("Id");
            if (Number == "" && Id == "")
            {
                return Response.error("单据编码或ID必须传递一个!");
            }

            ViewModel.Number = Number;
            ViewModel.Id = Id;

            Return = GetModel(ViewModel);
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

        #region 【项目其他地方调用返回Return】
        /// <summary>
        /// 项目其他地方调用返回Return
        /// </summary>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        public Return GetModel(ViewModel ViewModel)
        {
            string msg = SDK.View(Key, ViewModel);
            string Message = SDK.Result(msg);
            if (Message != "")
            {
                Return.Message = Message;
            }
            else
            {
                Return.GetModel = GetModel(msg);
            }
            return Return;
        }
        #endregion

        #region 【返回成功后的数据】
        /// <summary>
        /// 返回成功后的数据
        /// </summary>
        /// <returns></returns>
        public SdkModel GetModel(string msg)
        {
            result result = JsonConvert.DeserializeObject<result>(msg);
            ResultB Result = result.Result.Result;

            Model.Id = Result.Id;

            if (Result.Name != null)
            {
                Model.Name = Result.Name[0].Value;
            }

            Model.Number = Result.Number;

            if (Result.Specification != null)
            {
                Model.Specification = Result.Specification[0].Value;
            }

            if (Result.MaterialStock != null)
            {
                Unit.Name = Result.MaterialStock[0].StoreUnitID.Name[0].Value;
                Unit.Number = Result.MaterialStock[0].StoreUnitID.Number;
                Model.unit = Unit;

                Currency.Name = Result.MaterialStock[0].CurrencyId.Name[0].Value;
                Currency.Number = Result.MaterialStock[0].CurrencyId.Number;
                Model.currency = Currency;
            }

            return Model;
        }
        #endregion
    }
}
