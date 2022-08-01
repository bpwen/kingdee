using System;

namespace FIN.Model.admin
{
    /// <summary>
    /// 用户
    /// </summary>
    [Serializable]
    public partial class adminModel
    {
        public adminModel()
        { }

        #region Model
        private string _username = "";
        private string _password = "";
        private string _appSecret = "";

        /// <summary>
        /// 帐号
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }

        /// <summary>
        /// 第三方系统登录授权应用密钥
        /// </summary>
        public string appSecret
        {
            set { _appSecret = value; }
            get { return _appSecret; }
        }

        #endregion Model

    }
}

