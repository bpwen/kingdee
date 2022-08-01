<!--
 * @Name: 头部自定义导航需要
 * @Author: bpwen.cn
 * @Date: 2021-11-18 10:01:27
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-21 16:09:28
 * @url: https://v1.uviewui.com/components/topTips.html
    <app-top-tips ref="uTips"></app-top-tips>
    this.$refs.uTips.show('刷新成功');
-->
<template>
	<u-top-tips ref="uTips" v-if="navbarHeight != 0" :navbar-height="statusBarHeight + navbarHeight"></u-top-tips>
    <u-top-tips ref="uTips" v-else></u-top-tips>
</template>

<script>
    export default {
		props:{
            //type值可选的有primary(默认)、success、info、warning、error
			type:{
				type: String,
				default: 'success'
			},
			duration:{
				type: Number,
				default: 3000
			},
			// 导航栏内容区域高度，不包括状态栏高度在内 一般44
			navbarHeight:{
				type: Number,
				default: 0
			}
		},
        data () {
            return {
               // 状态栏高度，H5中，此值为0，因为H5不可操作状态栏
               statusBarHeight: uni.getSystemInfoSync().statusBarHeight
            }
        },
        methods: {
            show(...data){
				let arr = null;
				if(typeof data[0] == 'object'){
					arr = data[0];
				}else{
					arr = {
						title: data[0],
						type: this.type,    //type值可选的有primary(默认)、success、info、warning、error
						duration: this.duration
					}
					arr = Object.assign(arr, data[1]);
				}

            	this.$refs.uTips.show(arr);
            },
            error(...data){
                let arr = null;
				if(typeof data[0] == 'object'){
					arr = data[0];
				}else{
					arr = {
						title: data[0],
						type: 'error',    //type值可选的有primary(默认)、success、info、warning、error
						duration: this.duration
					}
					arr = Object.assign(arr, data[1]);
				}
                this.$refs.uTips.show(arr);
            }
        }
    };
</script>