using System.Web;
using Newtonsoft.Json.Linq;

namespace FIN.BPW
{
    public class Response
    {
        #region 【接口返回接口应用】

        #region 【GetModel】
        public static JObject GetModel(object value)
        {
            json.port arr = new json.port();
            arr.data = value;
            return json.parseToString(arr);
        }
        #endregion

        #region 【error】
        public static JObject error(string value)
        {
            json.port arr = new json.port();
            arr.error = value;
            return json.parseToString(arr);
        }
        #endregion

        #endregion

        #region 【Cookies】
        /// <summary>
        /// 获取指定 Cookies
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Cookies(string name)
        {
            if(HttpContext.Current.Request.Cookies[name] != null)
            {
                return HttpContext.Current.Request.Cookies[name].Value;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 创建 Cookies
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public static void Cookies(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = value;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion
    }
}
