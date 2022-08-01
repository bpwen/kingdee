<template>
	<view class="footer">
		<view class="flex-center">
			<view class="flex-1 collections t-ali-c hx top" v-if="home">
				<view class="iconfont icon-zhuye"></view>
				<view class="text">首页</view>
			</view>
			<view class="flex-1 collections t-ali-c hx top" v-if="settle">
				<view class="iconfont icon-fabu1"></view>
				<view class="text">入驻</view>
			</view>
			<view class="flex-1 collections t-ali-c hx top" v-if="navigation">
				<view class="iconfont icon-daohang"></view>
				<view class="text">导航</view>
			</view>
			<view class="flex-1 collections t-ali-c hx top" v-if="collections">
				<view class="iconfont icon-kongxinwujiaoxing"></view>
				<view class="text">搜藏</view>
			</view>
			<view class="flex-2 micro-chat t-ali-c" v-if="microChat">
				<view class="iconfont icon-xiaoxi"></view>
				<view class="text">微聊</view>
			</view>
			<view :class="phoneClss" class="flex-2 phone t-ali-c" v-if="phone">
				<view class="iconfont icon-dianhua"></view>
				<view class="text">{{phoneName}}</view>
			</view>
		</view>
	</view>
</template>

<script>
	export default{
		name:'bpw-footer-phone',
		props:{
			home:{
				type:Boolean,
				default: false
			},
			settle:{
				type:Boolean,
				default: false
			},
			navigation:{
				type:Boolean,
				default: false
			},
			collections:{
				type:Boolean,
				default: true
			},
			microChat:{
				type:Boolean,
				default: true
			},
			phone:{
				type:Boolean,
				default: true
			},
			phoneName:{
				type:String,
				default:'电话'
			},
			phoneClss:{
				type:String,
				default:''
			}
		}
	}
</script>

<style lang="less" scoped>
	.footer{
		height: 126.81upx;
		
		width: 100%;
		.flex-center{
			height: 126.81upx;
			background: #FFFFFF;
			width: 100%;
			position: fixed;
			bottom: 0px;
		}
		.t-ali-c{
			height: 100%;
			padding-top: 12.68upx;			
		}
		.iconfont{
			font-size: 63.4upx;
			height: 56.15upx;
			margin-bottom: 9.05upx;
			&.icon-dianhua{
				font-size: 45.28upx;
				&:before {
				    vertical-align: sub;
				}
			}
			&.icon-fabu1{
				font-size: 50.72upx;
				padding-top: 9.05upx;
				&:before{
					width: 61.59upx;
					height: 67.02upx;
				}
			}
		}
		.collections{
			color: #7E7E7E;
			border-left: 1.81upx solid #EEEEEE;
			&:first-child{
				border-left:none
			}
		}
		.micro-chat{
			color: #FFFFFF;
			background: #F1A72A;
		}
		.phone{
			color: #FFFFFF;
			background: #FF542E;
			&.flex-row{
				.iconfont{
					margin-right: 27.17upx;
					font-size: 36.23upx;
					height: auto;
					margin-bottom: 0upx;
				}
				.text{
					font-size: 32.6upx;
				}
			}
		}
	}
</style>
