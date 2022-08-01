/*
 * @Name: UniApp 项目中配置环境变量
 * @Author: bpwen.cn
 * @Date: 2021-11-15 15:46:49
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-15 15:54:28
 * @url: https://www.jianshu.com/p/b3aee659476e
 * const baseUrl = process.uniEnv.baseUrl;
 */

var EnvChannel  = {
    DEVELOPMENT:0, //开发环境
    TEST:1,//测试环境
    PRODUCTION:2//生产环境
}

//设置环境
let ENV_CONFIG = '';
const ENV_CHANNEL = EnvChannel.DEVELOPMENT;

if(ENV_CHANNEL == EnvChannel.DEVELOPMENT){
    //开发环境
    ENV_CONFIG = require('./env.dev.js');
}else if(ENV_CHANNEL == EnvChannel.TEST){
    //测试环境
    ENV_CONFIG = require('./env.test.js');
}else if(ENV_CHANNEL == EnvChannel.PRODUCTION){
    //生产环境
    ENV_CONFIG = require('./env.prod.js');
}

//给环境变量process.uniEnv赋值
if (ENV_CONFIG) {
    process.uniEnv = {};
    for (let key in ENV_CONFIG) {
        process.uniEnv[key] = ENV_CONFIG[key];
    }
}