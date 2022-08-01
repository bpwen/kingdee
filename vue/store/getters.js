/*
 * @Name: 
 * @Author: bpwen.cn
 * @Date: 2021-11-19 17:36:45
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-19 17:36:45
 * @url: 
 */

const getters = {
    token: state => state.user.token,
    window: state => state.public.window,
}
export default getters