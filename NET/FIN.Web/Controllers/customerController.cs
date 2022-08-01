using FIN.API.customer;
using FIN.Web.AuthAttributes;
using Newtonsoft.Json.Linq;
using System.Web.Http;

/// <summary>
/// 客户
/// </summary>
namespace FIN.Web.controllers
{
    [ApiAuthorize]
    public class customerController : ApiController
    {
        customer customer = new customer();

        #region 【获取客户存在否】
        /// <summary>
        /// 获取客户存在否
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject Exists()
        {
            return customer.Exists();
        }
        #endregion

        #region 【添加客户】
        [HttpPost]
        public JObject Add()
        {
            return customer.Add();
        }
        #endregion
    }
}