using FIN.BPW;
using FIN.Model.admin;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace FIN.API.admin
{
    public class user
    {
        private static readonly string appSecret = ConfigurationManager.AppSettings["appSecret"];
        private static readonly string UserName = ConfigurationManager.AppSettings["username"];
        private static readonly string tokenName = ConfigurationManager.AppSettings["token"];

        token Token = new token();
        TokenInfo TokenInfo = new TokenInfo();
        adminModel Model = new adminModel();
        SuccessToken SuccessToken = new SuccessToken();

        #region 【第三方接口用】
        /// <summary>
        /// 第三方接口用
        /// </summary>
        /// <returns></returns>
        public JObject usertoken()
        {
            int type = SDK.Login();
            if (type == 1)
            {
                Model.username = UserName;
                Model.appSecret = appSecret;

                SuccessToken = Token.Set(Model);
                if (SuccessToken.Success)
                {
                    Response.Cookies(tokenName, SuccessToken.Token);
                }

                return Response.GetModel(SuccessToken);
            }
            else if(type == 2)
            {
                return Response.error("缺少应用密钥");
            }
            else if (type == 3)
            {
                return Response.error("提供的密钥不正确");
            }
            else
            {
                return Response.error("拒绝请求");
            }
        }
        #endregion

        #region 【帐号登录】
        /// <summary>
        /// 帐号登录
        /// </summary>
        /// <returns></returns>
        public JObject login()
        {
            string username = Request.Form("username");
            if (username == "")
            {
                return Response.error("请输入帐号");
            }

            string password = Request.Form("password");
            if (password == "")
            {
                return Response.error("请输入密码");
            }

            Model.username = username;
            Model.password = password;

            return login(Model);
        }

        /// <summary>
        /// 登录成功则返回token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JObject login(adminModel Model)
        {
            if(login(Model.username, Model.password))
            {
                SuccessToken = Token.Set(Model);
                if (SuccessToken.Success)
                {
                    Response.Cookies(tokenName, SuccessToken.Token);
                }

                return Response.GetModel(SuccessToken);
            }
            else
            {
                return Response.error("登录失败");
            }
        }

        /// <summary>
        /// 接入金蝶登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool login(string username, string password)
        {
            if (SDK.Login(username, password) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 【接口要是返回没登录则来重新登录】
        /// <summary>
        /// 接口要是返回没登录则来重新登录
        /// </summary>
        /// <returns></returns>
        public bool Login()
        {
            TokenInfo = Token.Get();
            //用帐号登录的重新获取
            if (login(TokenInfo.UserName, TokenInfo.Password))
            {
                return true;
            }
            else
            {
                //用第三方登录的重新获取
                if (TokenInfo.appSecret == appSecret)
                {
                    if (SDK.usertoken() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
