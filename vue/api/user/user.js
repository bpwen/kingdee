/*
 * @Name: 
 * @Author: bpwen.cn
 * @Date: 2021-12-02 14:56:48
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-13 16:46:56
 * @url: 
 */
import { post, get } from '@/util/request'

//用户登录
export const login = (params) => {
    return post('/api/user/userlogin', params);
}
export const usertoken = (params) => {
    return post('/api/user/usertoken', params);
}

//用户退出
// export const logout = () => {
//     return post('/api/admin/user/logout');
// }