using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace FIN.BPW
{
    public class HttpClient
    {
        private static readonly string SaveURL = ConfigurationManager.AppSettings["SaveURL"];

        /// <summary>
        /// Seivice URL
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Cookie，保证登录后，所有访问持有一个Cookie；
        /// </summary>
        static CookieContainer Cookie = new CookieContainer();

        public string AsyncRequest()
        {
            string Key = ConfigurationManager.AppSettings[Name];
            Url = SaveURL + "k3cloud/" + Key;
            return HttpAjax();
        }

        /// <summary>
        /// HTTP访问
        /// </summary>
        public string HttpAjax()
        {
            HttpWebRequest httpRequest = HttpWebRequest.Create(Url) as HttpWebRequest;
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            httpRequest.CookieContainer = Cookie;
            httpRequest.Timeout = 1000 * 60 * 10;//10min

            using (Stream reqStream = httpRequest.GetRequestStream())
            {
                JObject jObj = new JObject();
                jObj.Add("format", 1);
                jObj.Add("useragent", "ApiClient");
                jObj.Add("rid", Guid.NewGuid().ToString().GetHashCode().ToString());
                jObj.Add("parameters", Content);
                jObj.Add("timestamp", DateTime.Now);
                jObj.Add("v", "1.0");
                string sContent = jObj.ToString();
                var bytes = UnicodeEncoding.UTF8.GetBytes(sContent);
                reqStream.Write(bytes, 0, bytes.Length);
                reqStream.Flush();
            }
            using (var repStream = httpRequest.GetResponse().GetResponseStream())
            {
                using (var reader = new StreamReader(repStream))
                {
                    return ValidateResult(reader.ReadToEnd());
                }
            }
        }

        private static string ValidateResult(string responseText)
        {
            if (responseText.StartsWith("response_error:"))
            {
                return responseText.TrimStart("response_error:".ToCharArray());
            }
            return responseText;
        }
    }
}
