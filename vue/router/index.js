/*
 * @Name: 
 * @Author: bpwen.cn
 * @Date: 2021-12-02 14:56:50
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-13 17:03:41
 * @url: 
 */
import {RouterMount,createRouter} from 'uni-simple-router';

const router = createRouter({
	platform: process.env.VUE_APP_PLATFORM,  
	routes: [
		...ROUTES,
		{
			path: '*',
			redirect:(to)=>{
				return {name:'404'}
			}
		}
	]
});

router.beforeEach((to, from, next) => {
	if(to.meta.noCache){
		if(uni.getStorageSync('yxd_net_token') == ''){
			uni.setStorage({
				key: 'fullPath',
				data: to.path,
				success: function () {
					next({
						path: '/pages/login/login'
					})
				}
			});
		}else{
			next();
		}
	}else{
		next();
	}
});

router.afterEach((to, from) => {
    console.log('跳转结束')
})

export {
	router,
	RouterMount
}