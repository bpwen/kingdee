using System.Web.Http;
using Newtonsoft.Json.Linq;
using FIN.Web.AuthAttributes;
using FIN.API.stock;

namespace FIN.Web.Controllers
{
    /// <summary>
    /// 库存
    /// </summary>
    [ApiAuthorize]
    public class stockController : ApiController
    {
        stock stock = new stock();

        [HttpPost]
        public JObject count()
        {
            return stock.count();
        }
    }
}