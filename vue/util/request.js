/*
 * @Name: Ajax封装
 * @Author: bpwen.cn
 * @Date: 2021-11-18 10:01:36
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-13 17:55:49
 */
// 二次封装请求接口
// https://uniapp.dcloud.io/api/request/request

// main.js 添加
// import api from './util/api.js'
// Vue.prototype.$api = api

// 全局请求封装
const token = uni.getStorageSync('yxd_net_token');

const Ajax = (url, method, params) => {
	return new Promise((resolve, reject) => {
		if(url.indexOf('https://') == -1 && url.indexOf('http://') == -1 ){
			url = process.uniEnv.baseUrl + url;
		}
		
		uni.request({
			url: url,
			data:params,
			method:method,
			header: {
				'yxd_net_token':token || uni.getStorageSync('yxd_net_token'),
				'content-type': 'application/x-www-form-urlencoded'
			},
		}).then((response)=>{
			let [error, res] = response;
            if(res){
                if(res.statusCode == 200){
                    if(res.data.error != null){
                        if(res.data.error.includes("请重新登录")){
                            let _this = this;
                            uni.showLoading({
                                icon: 'none',
                                title: "请重新登录",
                                success:function(){
                                    setTimeout(function () {
                                        uni.hideLoading();
                                        uni.navigateTo({
                                            url: '/pages/login/login'
                                        });
                                    }, 1000);
                                }
                            });
                        }else{
                            reject(res.data.error);
                        }
                    }else{
                        resolve(res.data);
                    }
                }else if(res.statusCode == 404){
                    reject('请求未响应或其它未知错误');
                }else if(res.statusCode == 500){
                    reject('内部服务器错误');
                }else{
                    reject('其它未知错误');
                    if(process.uniEnv.ENV == 'development'){
                        console.error(res);
                    }
                }
            }else{
                reject('服务器断开或未响应');
                if(process.uniEnv.ENV == 'development'){
                    console.error(error);
                }
            }
		}).catch(error => {
			try {
				let [err, res] = error;
				reject(error)
			}catch (exception) {
				reject(exception)
			}
        })
	});
}

const get = (url, params) => {
	return new Promise((resolve, reject) => {
		if(params != undefined){
			url += '?' + params
		}
		
		Ajax(url, 'GET', '').then(res => {
			resolve(res);
		}).catch(error => {
            reject(error)
        })
	});
}

const post = (url, params) => {
	return new Promise((resolve, reject) => {
		Ajax(url, 'POST', params).then(res => {
			resolve(res);
		}).catch(error => {
            reject(error)
        })
	});
}

export {
	Ajax,
	get,
	post
}