using System;
using System.Web;

namespace FIN.BPW
{
    /// <summary>
    /// 获取
    /// </summary>
    public class Request
    {
        #region 【Form】
        /// <summary>
        /// 文本框取值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string form(string text)
        {
            return HttpContext.Current.Request.Form[text];
        }

        /// <summary>
        /// 文本框取值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Form(string text)
        {
            string value = form(text);
            if (!BPW.IF.Null(value))
            {
                return HttpContext.Current.Server.HtmlEncode(value.Trim());
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 文本框取值,是否数字如不是则返回-1获取整数需要小数点则用Intf。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int Int(string text)
        {
            string objs = form(text);
            if (objs != null)
            {
                if (regex.IsDigital(objs))
                {
                    return Convert.ToInt32(objs);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region 【QueryString】
        /// <summary>
        /// 获取URL上相关参数
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string QueryString(string text)
        {
            string objs = HttpContext.Current.Request.QueryString[text];
            if (string.IsNullOrEmpty(objs))
            {
                return null;
            }
            else
            {
                return objs;
            }
        }

        /// <summary>
        /// 文本框取值，没删除相关空格字符等。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="i">默认为0</param>
        /// <returns></returns>
        public static string QueryString(string text, string i)
        {
            string objs = HttpContext.Current.Request.QueryString[text];
            if (string.IsNullOrEmpty(objs))
            {
                return null;
            }
            else
            {
                return objs;
            }
        }

        /// <summary>
        /// 获取URL上相关参数,是否数字如不是则返回-1。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int QueryStringInt(string text)
        {
            string objs = QueryString(text);
            if (objs != null)
            {
                if (regex.IsDigital(objs))
                {
                    return Convert.ToInt32(objs);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}
