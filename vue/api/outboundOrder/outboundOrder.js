/*
 * @Name: 销售出库但
 * @Author: bpwen.cn
 * @Date: 2021-12-10 10:11:42
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-10 16:22:24
 */
import { post, get } from '@/util/request'

//添加
export const Add = () => {
    return post('/api/outaLibrary/Add');
}

//查找
export const Exists = (params) => {
    return post('/api/outaLibrary/Exists',params);
}