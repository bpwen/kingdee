using FIN.Model.admin;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FIN.BPW
{
    /// <summary>
    /// token写入和读取
    /// </summary>
    public class token
    {
        private static readonly string tokenName = ConfigurationManager.AppSettings["token"];

        SuccessToken Token = new SuccessToken();
        TokenInfo TokenInfo = new TokenInfo();

        const string secretKey = "To Live is to change the world";

        /// <summary>
        /// 生成 Token
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public SuccessToken Set(adminModel adminModel)
        {
            bool isAdmin = (adminModel.username == "admin") ? true : false;

            TokenInfo TokenInfo = new TokenInfo
            {
                UserName = adminModel.username,
                Password = adminModel.password,
                appSecret = adminModel.appSecret,
                Roles = new List<string> { "admin", "User" },
                IsAdmin = isAdmin,
                StartTime = DateTime.Now,
                ExpirationTime = DateTime.Now
                //ExpirationTime = DateTime.Now.AddMinutes(30)
            };

            try
            {
                byte[] key = Encoding.UTF8.GetBytes(secretKey);
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var token = encoder.Encode(TokenInfo, key);

                Token.Success = true;
                Token.Token = token;
                Token.Message = "OK";
            }
            catch (Exception ex)
            {
                Token.Success = false;
                Token.Message = ex.Message.ToString();
            }
            return Token;
        }

        /// <summary>
        /// 获取 Token
        /// </summary>
        /// <returns></returns>
        public TokenInfo Get()
        {
            string token = Response.Cookies(tokenName);
            if (IF.Null(token))
            {
                return TokenInfo;
            }
            else
            {
                try
                {
                    //secret需要加密
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IDateTimeProvider provider = new UtcDateTimeProvider();
                    IJwtValidator validator = new JwtValidator(serializer, provider);
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                    IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                    TokenInfo = decoder.DecodeToObject<TokenInfo>(token, secretKey, verify: true);
                    if (TokenInfo != null)
                    {
                         return TokenInfo;
                    }
                    return TokenInfo;
                }
                catch (Exception ex)
                {
                    return TokenInfo;
                }
            }
        }
    }

    /// <summary>
    /// Token返回信息
    /// </summary>
    public class SuccessToken
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 身份验证信息 模拟JWT的payload
    /// </summary>
    public class TokenInfo
    {

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        public string appSecret { get; set; }
        
        /// <summary>
        /// 角色
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 口令开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 口令过期时间
        /// </summary>
        public DateTime ExpirationTime { get; set; }
    }
}
