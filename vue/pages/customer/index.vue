<!--
* @Name:客户
* @Author: bpwen.cn
* @Date: 2021-12-03 10:06:06
 * @LastEditors: VSCode
 * @LastEditTime: 2021-12-03 10:09:29
-->

<template>
    <view class="mail">
        {{name}}
    </view>
</template>

<script>
	import { list } from '@/api/customer/customer'
	
    export default {
        components:{
            
        },
        props:{
            type:{
                type:String,
                default: ''
            },
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
            list().then(res => {
				console.log(res)
			}).catch((err) => {
				uni.showToast({
					icon: 'none',
					title: err
				});
			});
        },
        methods: {
            
        }
    };
</script>

<style lang="less" scoped>

</style>