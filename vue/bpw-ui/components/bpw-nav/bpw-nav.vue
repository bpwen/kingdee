<!--
	<bpw-nav
	:list="list"
	>
		<template v-slot="{index}">
			<view v-show="index == 0 ? true : false">
				<tab-home ref="home"></tab-home>
				1
			</view>
			
			<view v-show="index == 1 ? true : false">
				2
			</view>
			
			<view v-show="index == 2 ? true : false">
				3
			</view>
			
			<view v-show="index == 3 ? true : false">
				4
			</view>
			
			<view v-show="index == 4 ? true : false">
				5
			</view>
		</template>
	</bpw-nav>
-->

<template>
	<view class="container">
		<view class="h-gao">
			<slot :index="show_index"></slot>
		</view>
		<!-- is_lhp判断是否为刘海屏在main.js里，好像uniapp有一个css变量获取刘海屏的安全区域 -->
		<view class="tabBar" :style="{height:is_lhp?'140rpx':'98rpx'}">
			<!-- 导航的中间圆圈 --> 
			<view class="border_box" :style="{paddingBottom:is_lhp?'40rpx':''}">
				<view class="tabBar_miden_border"></view>
			</view>
			<view class="tabBar_list" :style="{paddingBottom:is_lhp?'40rpx':''}">
				<view v-for="(item) in list" :key="item.id" :class="{'tabBar_item':item.id!=5,'tabBar_item2':item.id==5}" @tap="oPenSwitch(item.id)">
					<image v-if="show_index == item.id"  :src="`../../static/tabBar/${item.id+1}${item.id+1}.png`"></image>
					<image v-else :src="`../../static/tabBar/${item.id+1}.png`"></image>
					<view :class="{'tabBar_name':true,'nav_active':show_index == item.id}">{{item.name}}</view>
				</view>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		name:'bpw-nav',
		props:{
			list:{
				type: [String, Array],
				default: function() {
					return [];
				}
			},
		},
		data() {
			return {
				show_index:0,//控制显示那个组件
				is_lhp:false, //是否为刘海屏
			}
		},
		onLoad() {
			let _this = this
			this.is_lhp = this.$is_bang
			this.$nextTick(function(){
				setTimeout(function(){
					uni.setNavigationBarColor({
						frontColor: '#ffffff',
						backgroundColor: '#6739b6'
					})
					//_this.$refs.game.ontrueGetList()//初次加载第一个页面的请求数据
				},100)
			});
			// #ifdef H5
			window.addEventListener("beforeunload", e => {
				sessionStorage.setItem("stateInfo", this.show_index);
			});
			// #endif
		},
		mounted(){
			// #ifdef H5
			if (sessionStorage.getItem("stateInfo")) {
				this.show_index = sessionStorage.getItem("stateInfo");
			}
			// #endif
		},
		methods: {
			/*切换组件*/
			oPenSwitch(type){
				this.show_index = type;
				// #ifdef H5
				sessionStorage.setItem("stateInfo", this.show_index);
				// #endif
			}
		}
	}
</script>

<style lang="less">
	.h-gao{
		height: calc(100vh - 98rpx);
		/deep/ .scroll-content{
			height: 100% !important;
		}
	}
	.tabBar{ width:100%;height: 98rpx;background: #fff;border-top:1px solid #E5E5E5;position: fixed;z-index: 1;bottom:0px;left:0px;right:0px;display: flex;align-items: center;justify-content: center;
		.tabBar_list{ width:90%;display: flex;justify-content: space-between;z-index:2;
			image{ width:48rpx;height: 48rpx;margin-bottom:2rpx}
			.tabBar_item{ width:81.52upx;display: flex;justify-content: center;align-items: center;flex-direction: column;font-size: 20rpx;color: #969BA3;}
			.tabBar_item2{
				width:81.52upx;height:100%;display: flex;justify-content: center;align-items: center;flex-direction: column;font-size: 20rpx;color: #969BA3;margin-top:-20rpx;position: relative;z-index: 101;
				image{ width:68rpx;height: 68rpx;}
			}
		 } 
	}
	.border_box{
		width:100%;height: 100rpx;display: flex;justify-content: center;align-items: center;position: fixed;left:0px;bottom:50rpx;z-index: 1;pointer-events: none;
		.tabBar_miden_border{ width:100rpx;height:50rpx;border-top:2rpx solid #E5E5E5;border-radius:50rpx 50rpx 0 0; /* 左上、右上、右下、左下 */background: #fff;}
	}
</style>