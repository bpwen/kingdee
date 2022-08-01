using FIN.Model.SDK;
using FIN.Model.SDK.Pushdown;
using FIN.Model.SDK.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace FIN.BPW
{
    public class SDK
    {
        private static readonly string acctID = ConfigurationManager.AppSettings["acctID"];
        private static readonly string username = ConfigurationManager.AppSettings["username"];
        private static readonly string appId = ConfigurationManager.AppSettings["appId"];
        private static readonly string appSecret = ConfigurationManager.AppSettings["appSecret"];
        private static readonly string lcid = ConfigurationManager.AppSettings["lcid"];

        #region 【用户登录】

        #region 【金蝶第三方登录授权登录】
        /// <summary>
        ///  金蝶第三方登录授权登录
        /// </summary>
        /// <returns></returns>
        public static int Login()
        {
            string App_Secret = Request.Form("appSecret");
            if(App_Secret != "")
            {
                if(App_Secret == appSecret) {
                    return usertoken();
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 2;
            }
        }

        public static int usertoken()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "LoginByAppSecret";
            List<object> Parameters = new List<object>();
            Parameters.Add(acctID);
            Parameters.Add(username);
            Parameters.Add(appId);
            Parameters.Add(appSecret);
            Parameters.Add(lcid);

            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            JObject STR = JObject.Parse(httpClient.AsyncRequest());
            return STR["LoginResultType"].Value<int>();
        }
        #endregion

        #region 【金蝶帐号密码登录】
        /// <summary>
        ///  金蝶帐号密码登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Login(string username, string password)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "ValidateUser";
            List<object> Parameters = new List<object>();
            Parameters.Add(acctID);
            Parameters.Add(username);
            Parameters.Add(password);
            Parameters.Add(lcid);
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            return JObject.Parse(httpClient.AsyncRequest())["LoginResultType"].Value<int>();
        }
        #endregion

        #endregion

        #region 【单据查询】
        /// <summary>
        /// 单据查询
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string ExecuteBillQuery(ExecuteBillQuery Model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "ExecuteBillQuery";
            List<object> Parameters = new List<object>();
            Parameters.Add(json.parse(Model));
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            string msg = httpClient.AsyncRequest();
            if (msg.IndexOf("请重新登录") != -1)
            {
                if (usertoken() == 1)
                {
                    return ExecuteBillQuery(Model);
                }
                else
                {
                    return "会话信息已丢失，请重新登录";
                }
            }
            else
            {
                return msg;
            }
        }
        #endregion

        #region 【查看】
        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string View(string key, ViewModel Model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "View";
            List<object> Parameters = new List<object>();
            Parameters.Add(key);
            Parameters.Add(json.parse(Model));
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            string msg = httpClient.AsyncRequest();
            if (msg.IndexOf("请重新登录") != -1)
            {
                if (usertoken() == 1)
                {
                    return View(key, Model);
                }
                else
                {
                    return "会话信息已丢失，请重新登录";
                }
            }
            else
            {
                return msg;
            }
        }
        #endregion

        #region 【保存】
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string Save(string key, string Model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "Save";
            List<object> Parameters = new List<object>();
            Parameters.Add(key);
            Parameters.Add(Model);
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            string msg = httpClient.AsyncRequest();
            if (msg.IndexOf("请重新登录") != -1)
            {
                if (usertoken() == 1)
                {
                    return Save(key, Model);
                }
                else
                {
                    return "会话信息已丢失，请重新登录";
                }
            }
            else
            {
                return msg;
            }
        }
        #endregion

        #region 【提交】
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string Submit(string key, SubmitModel Model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "Submit";
            List<object> Parameters = new List<object>();
            Parameters.Add(key);
            Parameters.Add(json.parse(Model));
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            string msg = httpClient.AsyncRequest();
            if (msg.IndexOf("请重新登录") != -1)
            {
                if (usertoken() == 1)
                {
                    return Submit(key, Model);
                }
                else
                {
                    return "会话信息已丢失，请重新登录";
                }
            }
            else
            {
                return msg;
            }
        }
        #endregion

        #region 【审核】
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string Audit(string key, SubmitModel Model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "Audit";
            List<object> Parameters = new List<object>();
            Parameters.Add(key);
            Parameters.Add(json.parse(Model));
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            string msg = httpClient.AsyncRequest();
            if (msg.IndexOf("请重新登录") != -1)
            {
                if (usertoken() == 1)
                {
                    return Audit(key, Model);
                }
                else
                {
                    return "会话信息已丢失，请重新登录";
                }
            }
            else
            {
                return msg;
            }
        }
        #endregion

        #region 【反审核】
        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string UnAudit(string key, SubmitModel Model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "UnAudit";
            List<object> Parameters = new List<object>();
            Parameters.Add(key);
            Parameters.Add(json.parse(Model));
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            string msg = httpClient.AsyncRequest();
            if (msg.IndexOf("请重新登录") != -1)
            {
                if (usertoken() == 1)
                {
                    return UnAudit(key, Model);
                }
                else
                {
                    return "会话信息已丢失，请重新登录";
                }
            }
            else
            {
                return msg;
            }
        }
        #endregion

        #region 【下推】
        /// <summary>
        /// 下推
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string Pushdown(string key, PushdownModel Model)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Name = "Push";
            List<object> Parameters = new List<object>();
            Parameters.Add(key);
            Parameters.Add(json.parse(Model));
            httpClient.Content = JsonConvert.SerializeObject(Parameters);
            string msg = httpClient.AsyncRequest();
            if (msg.IndexOf("请重新登录") != -1)
            {
                if (usertoken() == 1)
                {
                    return Pushdown(key, Model);
                }
                else
                {
                    return "会话信息已丢失，请重新登录";
                }
            }
            else
            {
                return msg;
            }
        }
        #endregion

        #region 【错误信息回调】
        /// <summary>
        /// 错误信息回调
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Result(string value)
        {
            resultAB result = JsonConvert.DeserializeObject<resultAB>(value);

            ResponseStatusAB ResponseStatus = result.Result.ResponseStatus;
            if (!ResponseStatus.IsSuccess)
            {
                return ResponseStatus.Errors[0].Message;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}