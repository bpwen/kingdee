<!--
 * @Name: LoadingPage 加载页 
 * @Author: bpwen.cn
 * @Date: 2021-11-23 17:15:56
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-23 23:41:38
 <app-loading-page v-model="bool.loading"></app-loading-page>

data() {
    return {
        bool:{
            loading: true //首次加载
        }
    }
}
列表加载完监听则关闭
watch:{
    'table.load'(v){
        if(v){
            this.table.load = false;
            if(this.bool.loading){
                setTimeout((e) => {
                    e.bool.loading = false;
                },500, this)
            }
        }
    },
},

-->

<template>
    <transition name="fade">
        <view class="loading-page" v-if="bool">
            <view class="loading">
                <u-loading mode="flower" color="#000"></u-loading>
                <view class="title">数据加载中</view>
            </view>
            <u-mask :show="true" :custom-style="{background: '#ffffff'}"></u-mask>
        </view>
    </transition>
</template>

<script>
    export default {
        name:'app-loading-pag',
        props:{
            show:{
               type:Boolean,
               default: false
            }
        },
        data() {
            return {
                bool: false,
            }
        },
        watch: {
            show: {
                deep: true,
                immediate: true,
                handler: function (v) {
                    this.bool = v;
                }
            }
        }
    };
</script>

<style lang="less" scoped>
    .loading-page{
        .loading{
            width: 100px;
            height: 100px;
            top: 40%;
            left: 50%;
            margin: -50px 0px 0px -50px;
            position: fixed;
            z-index: 11111;
            text-align: center;
            .title{
                margin-top: 20px;
                font-size: 16px;
                line-height: 22px;
                color: #beb9be;
            }
            .u-loading{
                width: 40px !important;
                height: 40px !important;
            }
        }
    }
    .fade-enter-active, .fade-leave-active {
        transition: opacity .5s;
    }
    .fade-enter, .fade-leave-to {
        opacity: 0;
    }
</style>