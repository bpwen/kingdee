<template>
	<navigator class="href zj-nr-p hx flex-center" url="to" :hover-stay-time="100">
		<view class="name flex-center">
			<view class="iconfont" :class="icon" v-if="icon"></view>
			<view class="title"><slot></slot></view>
		</view>
		<view class="iconfont icon-triangle-right"></view>
	</navigator>
</template>

<script>
	export default {
		name:'bpw-navigator',
		props:{
			icon:{
				type:String,
				default: ''
			}
		}
	}
</script>

<style lang="less" scoped>
	.href{
		.name{
			.iconfont{
				color: #e64340;
				font-size: 39.85upx;
				margin-right: 14.49upx;
			}
			.title{
				font-size: 28.98upx;
			}
		}
		.icon-triangle-right{
			font-size: 27.17upx;
			color: #b7b7b7;
		}
	}
</style>