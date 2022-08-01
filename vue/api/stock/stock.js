/*
 * @Name: 取库
 * @Author: bpwen.cn
 * @Date: 2021-12-08 17:03:46
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-13 18:37:55
 */
import { post, get } from '@/util/request'

//获取库存数量
export const count = (params) => {
    return post('/api/stock/count', params);
}