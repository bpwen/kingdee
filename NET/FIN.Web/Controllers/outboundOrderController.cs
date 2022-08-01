using FIN.API.outboundOrder;
using FIN.Model.outboundOrder;
using FIN.Web.AuthAttributes;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace FIN.Web.Controllers
{
    /// <summary>
    /// 出库单
    /// </summary>
    [ApiAuthorize]
    public class outboundOrderController : ApiController
    {
        outboundOrder outboundOrder = new outboundOrder();

        #region 【添加出库单】
        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject Add([FromBody] Add value)
        {
            return outboundOrder.Add(value);
        }
        #endregion

        #region 【查询是否单据编号存在】
        /// <summary>
        /// 查询是否单据编号存在
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject Exists()
        {
            return outboundOrder.Exists();
        }
        #endregion
    }
}