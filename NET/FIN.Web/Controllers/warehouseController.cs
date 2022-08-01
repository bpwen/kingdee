using FIN.API.warehouse;
using FIN.Web.AuthAttributes;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace FIN.Web.Controllers
{
    /// <summary>
    /// 仓库
    /// </summary>
    [ApiAuthorize]
    public class warehouseController : ApiController
    {

        warehouseAPI warehouseAPI = new warehouseAPI();

        #region 【获取仓库列表】
        /// <summary>
        /// 获取物料列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject List()
        {
            return warehouseAPI.List();
        }
        #endregion
    }
}