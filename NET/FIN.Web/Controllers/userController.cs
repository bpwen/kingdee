using FIN.API.admin;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace FIN.Web.Controllers
{
    public class userController : ApiController
    {
        user user = new user();

        [HttpPost]
        public JObject userlogin()
        {
            return user.login();
        }

        [HttpPost]
        public JObject usertoken()
        {
            return user.usertoken();
        }
    }
}