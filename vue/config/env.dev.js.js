/*
 * @Name: 开发环境
 * @Author: bpwen.cn
 * @Date: 2021-11-15 15:47:09
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-26 10:53:05
 */

const config = {
    ENV: 'development',
	// #ifdef APP || MP-WEIXIN
	baseUrl: 'http://api.bpwen.com',
	// #endif
	//#ifdef H5
	baseUrl: '',
	// #endif
}

module.exports = config;