using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            K3CloudApiClient client = new K3CloudApiClient("http://120.25.229.153:81/k3cloud/");
            var loginResult = client.ValidateLogin("619c819088d92c", "玉玄道", "888888", 2052);
            var resultType = JObject.Parse(loginResult)["LoginResultType"].Value<int>();
        }
    }
}
