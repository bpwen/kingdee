/*
 * @Name: 
 * @Author: bpwen.cn
 * @Date: 2021-11-18 10:01:28
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-19 17:27:02
 * @url: 
 */
import Vue from 'vue'
import App from './App'

//引用并设置环境变量
import '@/config/index.js'

// #ifdef H5
import bpwui from "@/bpw-ui/index.js";
Vue.use(bpwui);
// #endif

import bpwuijs from './common/bpwjs.js'
Vue.use(bpwuijs);

// 引入全局uView
import uView from 'uview-ui';
Vue.use(uView);

//路由
import {router,RouterMount} from './router'  //路径换成自己的
Vue.use(router)

//挂载vuex
import store from './store'
//把vuex定义成全局组件
Vue.prototype.$store = store

Vue.config.productionTip = false

App.mpType = 'app'
const app = new Vue({
	...App,
    store
})

//v1.3.5起 H5端 你应该去除原有的app.$mount();使用路由自带的渲染方式
// #ifdef H5
	RouterMount(app,router,'#app')
// #endif

// #ifndef H5
	app.$mount(); //为了兼容小程序及app端必须这样写才有效果
// #endif