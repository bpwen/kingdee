using FIN.BPW;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FIN.Web.AuthAttributes
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        TokenInfo tokenInfo = new TokenInfo();
        private static readonly string tokenName = ConfigurationManager.AppSettings["token"];

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authHeader = from t in actionContext.Request.Headers where t.Key == tokenName select t.Value.FirstOrDefault();
            if (authHeader != null)
            {
                string token = authHeader.FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        const string secret = "To Live is to change the world";
                        //secret需要加密
                        IJsonSerializer serializer = new JsonNetSerializer();
                        IDateTimeProvider provider = new UtcDateTimeProvider();
                        IJwtValidator validator = new JwtValidator(serializer, provider);
                        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                        IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                        IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                        tokenInfo = decoder.DecodeToObject<TokenInfo>(token, secret, verify: true);
                        if (tokenInfo != null)
                        {
                            if (IF.Null(Response.Cookies(tokenName)))
                            {
                                Response.Cookies(tokenName, token);
                            }
                            return true;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// 处理授权失败的请求
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            JObject erModel = null;

            var authHeader = from t in actionContext.Request.Headers where t.Key == tokenName select t.Value.FirstOrDefault();
            if (authHeader != null)
            {
                string token = authHeader.FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {

                }
                else
                {
                    erModel = Response.error("已拒绝为此请求授权");
                }
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
        }
    }
}