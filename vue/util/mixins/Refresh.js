/*
 * @Name: 下拉刷新
 * @Author: bpwen.cn
 * @Date: 2021-11-19 15:49:01
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-23 23:58:42
 * 在pages.json文件中的pages数组中找到对应的页面，并在对应页面的style属性中开启 "enablePullDownRefresh":true
 */

export default {
    data () {
        return {
            bool:{
                refresh: false	//用于判断是否启用下拉刷新了，好获取数据关闭下拉
            }
        }
    },
    watch:{
        'table.load'(v){     //列表页 table.load 默认为false 用于判断axios请求状态，false为没请求，请求完毕为true
            if(v){
                if(this.bool.refresh){	//	启用了下拉刷新
                    this.bool.refresh = false; //刷新关闭了
                    this.$refs.uTips.show("刷新成功");
                    uni.stopPullDownRefresh();  //停止下拉刷新动画
                }
            }
        },
    },
    /*监听下拉刷新动作的执行方法，每次手动下拉刷新都会执行一次*/
    onPullDownRefresh() {
        if(!this.bool.loading){//在加载的时候阻止下拉刷新
            this.query = new this.Config(); //因为刷新把参数重新初始化
            // **************************************************
            // 需要混入的页面请求列表的默认参数用构造函数防止更改
            // data() {
            // 	return {
            //         Config:function(){
            //             this.page = 1;
            //             this.pagesize = 10;
            //             return this;
            //         }
            // 	}
            // }
            // **************************************************
            this.bool.refresh = true; //启用了刷新
            this.onList();//去执行获取数据
        }
    }
}
