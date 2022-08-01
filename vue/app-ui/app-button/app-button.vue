<!--
 * @Name: APP端底部固定按钮在移动端口弹起键盘的时候不显示
 * @Author: bpwen.cn
 * @Date: 2021-11-22 23:41:54
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-23 23:19:29
-->
<template>
    <view class="app-button" v-show="isopenInput == 0">
        <slot></slot>
    </view>
</template>

<script>
    export default {
        data () {
            return {
               isopenInput: 0
            }
        },
        mounted () {
            //#ifdef APP
            //手机端键盘监听高度
            uni.onKeyboardHeightChange(res => {
                this.isopenInput = res.height;
            })
            //#endif
        }
    };
</script>