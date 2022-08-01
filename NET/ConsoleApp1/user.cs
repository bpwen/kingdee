using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class user
    {
        public string login()
        {
            // 使用webapi引用组件Kingdee.BOS.WebApi.Client.dll
            K3CloudApiClient client = new K3CloudApiClient("http://120.25.229.153:81/k3cloud/");
            var loginResult = client.ValidateLogin("619c819088d92c", "玉玄道", "888888", 2052);
            var resultType = JObject.Parse(loginResult)["LoginResultType"].Value<int>();
            //登录结果类型等于1，代表登录成功
            return resultType.ToString();
        }
    }
}
