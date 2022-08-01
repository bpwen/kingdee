using FIN.API.organization;
using FIN.Web.AuthAttributes;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace FIN.Web.Controllers
{
    /// <summary>
    /// 组织机构
    /// </summary>
    [ApiAuthorize]
    public class organizationController : ApiController
    {
        organizationAPI organizationAPI = new organizationAPI();

        #region 【获取仓库列表】
        /// <summary>
        /// 组织机构列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject List()
        {
            return organizationAPI.List();
        }
        #endregion

        #region 【获取仓库列表】
        /// <summary>
        /// 查看组织机构详情
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JObject GetModel()
        {
            return organizationAPI.GetModel();
        }
        #endregion
    }
}