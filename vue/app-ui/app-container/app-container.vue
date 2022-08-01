<!--
 * @Name: APP容器
 * @Author: bpwen.cn
 * @Date: 2021-11-16 11:44:13
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-23 22:05:30
-->

<template>
    <view class="app-container" :class="{'b-bai': bjColor, 'topBottom': btnType == 'topBottom', 'Bottom': btnType == 'Bottom'}">
        <slot></slot>
        <!-- BackTop 返回顶部 -->
		<u-back-top :scroll-top="0" bottom="50"></u-back-top>
    </view>
</template>

<script>
    export default {
        props:{
            //背景
            bjColor:{
                type:Boolean,
                default: false
            },
            btnType:{
                type:String,
                default: ''// topBottom
            }
        },
        data () {
            return {
               
            }
        },
        computed: {
            
        },
        created () {
            
        },
        mounted () {
            
        },
        methods: {
            
        }
    };
</script>

<style lang="less" scoped>
	.app-container{
		background: #f1f1f1;
		
        //#ifdef APP
		min-height: 100vh;
		//#endif
		
		//#ifdef H5
		min-height: calc(100vh - 44px);
		//#endif
        
        &.topBottom{
            min-height: calc(100vh - 100px);
        }
        &.Bottom{
            min-height: calc(100vh - 50px);
        }
        &.b-bai{
            background: #ffffff;
        }
	}
</style>