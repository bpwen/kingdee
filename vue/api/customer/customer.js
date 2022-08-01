/*
 * @Name: 
 * @Author: bpwen.cn
 * @Date: 2021-12-03 10:55:51
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-10 10:20:51
 * @url: 
 */
import { post, get } from '@/util/request'

//用户登录
export const list = () => {
    return post('/api/customer/list');
}