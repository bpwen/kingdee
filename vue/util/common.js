/*
 * @Name: 时间插件 根据时间戳 判断对应的时间（今天 昨天 前天）
 * @Author: bpwen.cn
 * @Date: 2021-11-16 16:46:45
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-20 20:41:53
 */

/*
import { formatDate, compareDate, isDategtime, getDateDiff } from '@/util/common.js'
export default {
	data() {
		return {
			compare: compareDate,
            iscompare: isDategtime,
            GetDateDiff: getDateDiff,
		}
	},
	filters: {
		FormatDate(data, fmt) {
			return formatDate(data, fmt)
		}
	}
}

<view class="time" v-if="compare(item.Add_date)">
    <template v-if="iscompare(item.Add_date, 3)">今天</template>
    <template v-else>
        {{ GetDateDiff(new Date(item.Add_date)) }}
    </template>
</view>
<view class="time" v-else-if="compare(item.Add_date, 1)">昨天</view>
<view class="time" v-else-if="compare(item.Add_date, 2)">前天</view>
<view class="time" v-else>{{item.Add_date | FormatDate('MM-d')}}</view>		
	
*/

const formatDate = (date, fmt) => {
  date = new Date(date);
  if (typeof (fmt) === "undefined") {
    fmt = "yyyy-MM-dd HH:mm:ss";
  }
  if (/(y+)/.test(fmt)) {
    fmt = fmt.replace(RegExp.$1, (date.getFullYear() + '').substr(4 - RegExp.$1.length))
  }
  let o = {
    'Y': date.getFullYear(),
    'M+': date.getMonth() + 1,
    'd+': date.getDate(),
    'H+': date.getHours(),
    'm+': date.getMinutes(),
    's+': date.getSeconds()
  }
  for (let k in o) {
    if (new RegExp(`(${k})`).test(fmt)) {
        let str = o[k] + ''
        fmt = fmt.replace(RegExp.$1, RegExp.$1.length === 1 ? str : ('00' + str).substr(str.length));
    }
  }
  return fmt
}

/**
 * @name: isDategtime
 * @test:  判断时间是否超过指定的时间 如当前时间是否超过3小时的
 * @msg: 
 * @param {date}  指定一个时间大于当前时间
 * @return {value} 指定一个时间如 3 就是判断超过 3小时否
 */
const isDategtime = (date, value) => {
    return new Date()-new Date(date) > value*60*60*1000;
}

const compareDate = (timestamp, day = 0) => {
	// timestamp 为要传入的时间戳
	// day 为要减去的日子 因为比较*当天*的话，是不需要减的，所以默认定义成0,
	
	// 根据上面分析，有些需要参数`time`，有些不需要，所以使用一个函数来区分一下 
	let newDate = (time = null) => {
		return time === null ? new Date() : new Date(time)
	}
	
	// 这里返回 比较后的值，比较成功，则返回`true`，失败则返回`false`
	return (newDate(timestamp).getDate() == newDate().getDate() - day) && (newDate(timestamp).getMonth() == newDate().getMonth()) && (newDate(timestamp).getYear() == newDate().getYear())	
}

/**
 * @name: getDateDiff
 * @test: 转化为几天前,几小时前，几分钟前
 * @msg: 
 * @param {dateTimeStamp}  转换标准时间为时间戳
 * @return {*}
 */
const getDateDiff = (dateTimeStamp) => {
	var minute = 1000 * 60;
	var hour = minute * 60;
	var day = hour * 24;
	var halfamonth = day * 15;
	var month = day * 30;
	var now = new Date().getTime();
	var diffValue = now - dateTimeStamp;
	if(diffValue < 0){return;}
	var monthC =diffValue/month;
	var weekC =diffValue/(7*day);
	var dayC =diffValue/day;
	var hourC =diffValue/hour;
	var minC =diffValue/minute;
    let result  = "";
	if(monthC>=1){
		result="" + parseInt(monthC) + "月前";
	}else if(weekC>=1){
		result="" + parseInt(weekC) + "周前";
	}else if(dayC>=1){
		result=""+ parseInt(dayC) +"天前";
	}else if(hourC>=1){
		result=""+ parseInt(hourC) +"小时前";
	}else if(minC>=1){
		result=""+ parseInt(minC) +"分钟前";
	}else{
        result="刚刚";
    }
	return result;
}

export { formatDate, compareDate, isDategtime, getDateDiff }