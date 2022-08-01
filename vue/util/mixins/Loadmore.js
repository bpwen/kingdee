/*
 * @Name: 分页加载更多
 * @Author: bpwen.cn
 * @Date: 2021-11-19 15:35:54
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-21 01:48:45
 * 用于混入列表加载下一页或更多
 * import Loadmore from '@/util/mixins/Loadmore'
 * mixins:[Loadmore]
 * <!-- 加载更多、加载中或加载完成提示 -->
 * <bpw-loadmore :show="loadmore.show" v-model="loadmore.index"></bpw-loadmore>
 */

export default {
    data () {
        return {
            bool:{
                bottom: false //用于判断拉到底部加载
            },
            loadmore:{//底部加载中等显示
                show: false,
                index: 0
            }
        }
    },
    watch:{
        'table.load'(v){     //列表页 table.load 默认为false 用于判断axios请求状态，false为没请求，请求完毕为true
            if(v){
                if(this.bool.bottom){	//	启用了下拉刷新
                    setTimeout(function(e){
                        e.bool.bottom = false; //关闭了底部加载
                    },1000, this)
                }
            }
        },
        'table.paging'(v){
            if(v.pagecount == v.page){
                this.loadmore.index = 2;//底部加载触发 提示 没有更多了
            }
        }
    },
    // 拉到底部执行
    onReachBottom() {
        //bool.bottom防止多次执行防抖，和判断list有数据否防止初始加载还没获取数据就执行了
        if(!this.bool.bottom && this.table.list.length != 0){
            this.bool.bottom = true;//启用底部加载
            if(this.table.paging.pagecount >= (this.query.page + 1)){
                if(!this.loadmore.show){
                    this.loadmore.index = 1;//底部加载触发 提示 正在加载
                    this.loadmore.show = true;//底部加载触发 显示
                }
                this.query.page++;//加载下一页数据
                this.onList();//去执行获取数据
            }
        }
    }
}
