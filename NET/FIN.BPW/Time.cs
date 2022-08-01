using System;
using System.Globalization;


namespace FIN.BPW
{
    /// <summary>
    /// 时间类
    /// </summary>
    public class Time
    {
        #region 【返回当前时间】
        /// <summary>
        /// 返回一个时间
        /// </summary>
        /// <returns></returns>
        public static DateTime val()
        {
            return DateTime.Now;
        }
        #endregion

        #region 【当前时间格式化】
        /// <summary>
        /// 当前时间格式化,如单独取月type传MM
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="type">
        /// 格式化样式：
        ///     yyyy-MM-dd HH:mm:ss 
        ///     yyyyMMddHHmmss
        ///     yyyy-MM-dd
        ///     HH:mm:ss 
        ///     HH:mm
        /// </param>
        /// <returns></returns>
        public static string val(string type)
        {
            return Convert.ToDateTime(val()).ToString(type);
        }
        #endregion

        #region 【指定一个时间格式化】
        /// <summary>
        /// 指定一个时间格式化,如单独取月type传MM
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="type">
        /// 格式化样式：
        ///     yyyy-MM-dd HH:mm:ss 
        ///     yyyyMMddHHmmss
        ///     yyyy-MM-dd
        ///     HH:mm:ss 
        ///     HH:mm
        /// </param>
        /// <returns></returns>
        public static string val(DateTime time,string type)
        {
            return Convert.ToDateTime(time).ToString(type);
        }
        #endregion

        #region 【获取当前时间某一个字段】
        /// <summary>
        /// 获取当前时间某一个字段
        /// </summary>
        /// <param name="name">年、月、日、星期、时、分、秒</param>
        /// <returns></returns>
        public static string mval(string name)
        {
            string Add = null;
            switch (name)
            {
                case "年":
                    Add = DateTime.Now.Year.ToString();// 获取年份   // 2008
                    break;
                case "月":
                    Add = DateTime.Now.Month.ToString();// 获取月份   // 9
                    break;
                case "星期":
                    Add = DateTime.Now.DayOfWeek.ToString();// 获取星期   // Thursday   
                    break;
                case "日":
                    Add = DateTime.Now.Day.ToString();// 获取日
                    break;
                case "时":
                    Add = DateTime.Now.Hour.ToString();// 获取小时   // 20   
                    break;
                case "分":
                    Add = DateTime.Now.Minute.ToString();// 获取分钟   // 31   
                    break;
                case "秒":
                    Add = DateTime.Now.Second.ToString();// 获取秒数   // 45    
                    break;
                case "一年中第几天":
                    Add = DateTime.Now.DayOfYear.ToString();// 获取第几天   // 248    
                    break;
                default:
                    Add = DateTime.Now.ToString();
                    break;
            }
            return Add;
        }
        #endregion

        #region 【改变日期】
        /// <summary>
        /// 时间更新
        /// </summary>
        /// <param name="name">单个字，年月日时分秒</param>
        /// <param name="count">加还还是减如-1，减1天。2则加2天</param>
        /// <returns></returns>
        public static DateTime update(string name, int count)
        {
            return update(name, val(), count);
        }

        /// <summary>
        /// 时间更新
        /// </summary>
        /// <param name="name">单个字，年月日时分秒</param>
        /// <param name="dt">时间</param>
        /// <param name="count">加还还是减如-1，减1天。2则加2天</param>
        /// <returns></returns>
        public static DateTime update(string name, DateTime dt, int count)
        {
            switch (name)
            {
                case "年":
                    dt = dt.AddYears(count);
                    break;
                case "月":
                    dt = dt.AddMonths(count);
                    break;
                case "日":
                    dt = DateTime.Now.AddDays(count);
                    break;
                case "时":
                    dt = dt.AddHours(count);
                    break;
                case "分":
                    dt = dt.AddMinutes(count);
                    break;
                case "秒":
                    dt = dt.AddSeconds(count);
                    break;
                default:
                    break;
            }
            return dt;
        }
        #endregion

        #region 【获取时间数组】
        /// <summary>
        /// 数组时间
        /// </summary>
        /// <returns></returns>
        public static string[] Arr_DateTime()
        {
            return Arr_DateTime(val());
        }
        
        /// <summary>
        /// 数组时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string[] Arr_DateTime(DateTime dt)
        {
            string[] arr = new string[] {
                dt.Year.ToString(),    //年
                dt.Month.ToString(),   //月
                dt.Day.ToString(),     //日
                dt.Hour.ToString(),    //时
                dt.Minute.ToString(),  //分
                dt.Second.ToString(),  //秒
                Getmaxday(dt.Year,dt.Month).ToString(),//获取当月有多少天
                dt.DayOfWeek.ToString()//获取星期
            };
            return arr;
        }
        #endregion

        #region 【获取年份中的第几周】
        /// <summary>
        /// 获取年份中的第几周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }
        #endregion

        #region 【获取某个月有多少天】

        #region 获取某个月有多少天
        /// <summary>
        /// 获取某个月有多少天
        /// </summary>
        /// <returns></returns>
        public static int Getmaxday()
        {
            return Getmaxday(val().Year, val().Month);
        }
        #endregion

        #region 获取某个月有多少天-需参数
        /// <summary>
        /// 获取某个月有多少天
        /// </summary>
        /// <param name="Year">年</param>
        /// <param name="Month">月</param>
        /// <returns></returns>
        public static int Getmaxday(int Year,int Month)
        {
            int _DAYS = DateTime.DaysInMonth(Year, Month);
            return _DAYS;
        }
        #endregion

        #region 【补零】
        /// <summary>
        /// 补零
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string zeros(int value)
        {
            if (value < 10)
            {
                return "0" + value;
            }
            else
            {
                return value.ToString();
            }
        }
        #endregion

        #endregion

        #region 【时间对比】
        /// <summary>
        /// 时间对比
        /// </summary>
        /// <param name="date1">2018-08-12 16:40:34</param>
        /// <param name="date2">2018-08-12 16:50:34</param>
        /// <returns>返回0为等于，返回-1为小于，返回1为大于</returns>
        public static int Compare(DateTime date1, DateTime date2)
        {
            return DateTime.Compare(date1, date2);
        }

        #region 【Comparea】
        /// <summary>
        /// 判断时间年月日是否等于，相等则返回true
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static bool Comparea(DateTime date1, DateTime date2)
        {
            if (Time.Arr_DateTime(date1)[0] == Time.Arr_DateTime(date2)[0] && Time.Arr_DateTime(date1)[1] == Time.Arr_DateTime(date2)[1] && Time.Arr_DateTime(date1)[2] == Time.Arr_DateTime(date2)[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #endregion
    }
}