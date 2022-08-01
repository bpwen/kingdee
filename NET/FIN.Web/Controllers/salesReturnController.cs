using FIN.API.salesreturn;
using FIN.Web.AuthAttributes;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace FIN.Web.Controllers
{
    /// <summary>
    /// 销售退货单
    /// </summary>
    [ApiAuthorize]
    public class salesReturnController : ApiController
    {
        salesreturnAPI salesreturnAPI = new salesreturnAPI();

        #region 【添加出库单】
        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject Add()
        {
            return salesreturnAPI.Add();
        }
        #endregion
    }
}