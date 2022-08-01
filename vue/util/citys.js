import { get } from '@/util/request.js'

//获取外部归属地json文件
export const citys = () => {
	return get('/util/citys.json');
}

