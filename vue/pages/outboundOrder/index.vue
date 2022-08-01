<!--
 * @Name: 销售出库但
 * @Author: bpwen.cn
 * @Date: 2021-12-10 10:09:00
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-10 16:22:58
-->

<template>
    <view class="mail">
        <u-button type="primary" @click="onAdd">添加出库</u-button>
    </view>
</template>

<script>
    import { Add, Exists } from '@/api/outboundOrder/outboundOrder'

    export default {
        components:{
            
        },
        data () {
            return {
               name:"内容"
            }
        },
        watch: {
            
        },
        computed: {
            
        },
        created () {
            
        },
        mounted () {
            Exists({
                Number:'XSCKD036125'
            }).then((res) => {
                console.log(res)

            }).catch((res) => {
                console.log(res)
            });
        },
        methods: {
            onAdd(){
                Add().then((res) => {
                    console.log(res)
                }).catch((res) => {
                    console.log(res)
                });
            }
        }
    };
</script>

<style lang="less" scoped>

</style>