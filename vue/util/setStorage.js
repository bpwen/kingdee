/*
 * @Name: 将数据存储在本地
 * @Author: bpwen.cn
 * @Date: 2021-11-12 22:55:17
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-12 22:55:17
 * @url:https://uniapp.dcloud.io/api/storage/storage?id=setstorage
*/

//将数据存储在本地缓存中指定的 key 中，会覆盖掉原来该 key 对应的内容，这是一个异步接口。
const setStorage = (key, value, callback) => {
	uni.setStorage({
	    key: key,
	    data: value,
	    success: ()  => {
	       callback();
	    },
		fail: ()  => {
			uni.showToast({
				icon: 'none',
				title: '未知错误'
			});
		}
	});
}

//从本地缓存中异步获取指定 key 对应的内容。
const getStorage = (key, callback) => {
	uni.getStorage({
	    key: key,
	    success: res  => {
			callback(res.data);
	    }
	});
}

//从本地缓存中异步移除指定 key。
const delStorage = (key, callback) => {
	uni.removeStorage({
	    key: key,
	    success: res  => {
	        callback(res);
	    }
	});
}

export {
	setStorage,
	getStorage,
	delStorage
}