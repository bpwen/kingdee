<!--
 * @Name: Empty 内容为空
 * @Author: bpwen.cn
 * @Date: 2021-11-22 10:04:19
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-22 16:36:03
 * @url: https://v1.uviewui.com/components/empty.html
-->

<template>
    <view class="empty-main" :class="{'Full-screen':full, 'text-none': empty.title == ' '}">
        <u-empty mode="list" :src="icon || empty.icon" :text="empty.title"></u-empty>
    </view>
</template>

<script>
    export default {
        props:{
            // car	购物车为空
            // page	页面不存在
            // search	没有搜索结果
            // wifi	没有WiFi
            // order	订单为空
            // coupon	没有优惠券
            // permission	无权限
            // history	无历史记录
            // news	无新闻列表
            // message	消息列表为空
            // list	列表为空(通用)
            // data	数据为空(默认，通用)
            mode:{
                type:String,
                default: 'data'
            },
            //内置图标名称，或图片路径，建议绝对路径
            icon:{
                type:String,
                default: ''
            },
            //标题
            title:{
                type:String,
                default: ''
            },
            //是否全屏
            full:{
                type:Boolean,
                default: false
            }
        },
        data () {
            return {
                empty:{
                    title:'',
                    icon:'',
                },
                iconArr:[
                    { name: 'car', url: '/static/none/car.png', title:'购物车为空'},
                    { name: 'comment', url: '/static/none/comment.png', title:'暂无评论'},
                    { name: 'coupon', url: '/static/none/coupon.png', title:'没有优惠券'},
                    { name: 'data', url: '/static/none/data.png', title:'数据为空'},
                    { name: 'history', url: '/static/none/history.png', title:'无历史记录'},
                    { name: 'list', url: '/static/none/list.png', title:'列表为空'},
                    { name: 'message', url: '/static/none/message.png', title:'消息列表为空'},
                    { name: 'news', url: '/static/none/news.png', title:'无新闻列表'},
                    { name: 'order', url: '/static/none/order.png', title:'订单为空'},
                    { name: 'page', url: '/static/none/page.png', title:'页面不存在'},
                    { name: 'permission', url: '/static/none/permission.png', title:'无权限'},
                    { name: 'search', url: '/static/none/search.png', title:'没有搜索结果'},
                    { name: 'wifi', url: '/static/none/wifi.png', title:'没有WiFi'}
                ]
            }
        },
        watch: {
            mode: {
                deep: true,
                immediate: true,
                handler: function (v) {
                    this.onIconArr(v);
                }
            },
            title: {
                immediate: true,
                handler: function (v) {
                    if(v != ''){
                        this.empty.title = v;
                    }
                }
            },
        },
        methods: {
            onIconArr(v){
                let _this = this;
                this.iconArr.filter(function (item) {
                    if(item.name === v){
                        _this.empty.icon = item.url;
                        if(_this.title == ''){
                            _this.empty.title = item.title;
                        }
                    }
                })
            }
        }
    };
</script>

<style lang="less" scoped>
.empty-main{
    padding-bottom: 20px;

    &.text-none{
        padding-bottom: 0px;
        /deep/.u-icon__label,/deep/.u-slot-wrap{
            display: none;
        }
    }

    &.Full-screen{
        display: flex;
        align-items: center;
        justify-content: center;
        position: absolute;
        width: 100%;
        top: 0px;
        bottom: 0px;
        padding-bottom: 0px;
        .u-empty{
            margin-top: -80px !important;
        }
    }
    /deep/.u-icon__img{
        width: 160px !important;
        height: 160px !important;
    }
}
</style>