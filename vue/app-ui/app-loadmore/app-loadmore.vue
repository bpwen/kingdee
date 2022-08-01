<!--
 * @Name: 加载更多、加载中或加载完成提示
 * @Author: bpwen.cn
 * @Date: 2021-11-16 23:52:48
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-17 00:08:57
-->

<template>
	<view class="h-55 flex-row">
		<u-divider bg-color="transparent" v-if="bool">
			<view class="flex-cen">
				<view class="m-5-r" v-if="index == 1"><u-loading :mode="iconType"></u-loading></view>
				<view>{{loadText[index]}}</view>
			</view>
		</u-divider>
	</view>
</template>

<script>
    export default {
		name: 'bpw-loadmore',
		props:{
			// 是否显示
			show: {
				type: Boolean,
				default: false
			},
			// 指定 显示 loadText 那一个
			value: {
				type:Number,
				default: 0
			}
		},
		watch:{
			show(v){
				this.bool = v;
			},
			value(v){
				this.index = v;
			}
		},
		data(){
			return {
				bool: false,
				index: 0,
				loadText: ['查看更多','正在加载','没有更多了'],
				iconType: 'flower'
			}
		}
    };
</script>