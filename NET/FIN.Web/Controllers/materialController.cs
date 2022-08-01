using FIN.API.material;
using FIN.Web.AuthAttributes;
using Newtonsoft.Json.Linq;
using System.Web.Http;

/// <summary>
/// 物料API接口
/// </summary>
namespace FIN.Web.Controllers
{
    [ApiAuthorize]
    public class materialController : ApiController
    {
        materialAPI materialAPI = new materialAPI();

        #region 【获取客户存在否】
        /// <summary>
        /// 获取物料列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject List()
        {
            return materialAPI.List();
        }
        #endregion

        #region 【获取对象实体】
        /// <summary>
        /// 获取对象实体
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject GetModel()
        {
            return materialAPI.GetModel();
        }
        #endregion
    }
}