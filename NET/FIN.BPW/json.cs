using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Script.Serialization;

namespace FIN.BPW
{
    public class json
    {
        #region 【json转换为字符串】
        /// <summary>
        /// json转换为字符串
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static string parse(object rs)
        {
            return new JavaScriptSerializer().Serialize(rs);
        }
        #endregion

        #region 【字符串转换为json】
        /// <summary>
        /// 字符串转换为json
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static JObject parse(string rs)
        {
            try
            {
                return (JObject)JsonConvert.DeserializeObject(rs);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region 【字符串转换为json】
        /// <summary>
        /// 对象转字符在转json
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static JObject parseToString(object value)
        {
            return parse(parse(value));
        }
        #endregion


        #region 【json端口】
        /// <summary>
        /// json端口
        /// </summary>
        public class port
        {
            public object data { get; set; }
            /// <summary>
            /// 错误提示
            /// </summary>
            public string error { get; set; }
        }
        #endregion
    }
}
