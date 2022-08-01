卡片

<template>
	<view class="bpw-card">
		<view class="head zj-rl-p hx flex-center">
			<view class="title flex-center">
				<view :class="isiconTitle" v-if="isiconTitle != ''"></view>
				{{title}}
			</view>
			<view class="more flex-center">
				<view :class="isiconMore" v-if="isiconMore != ''"></view>
				{{more}}
			</view>
		</view>
		
		<view class="content zj-nr-p" v-if="!type">
			<slot></slot>
		</view>
		<slot v-else></slot>
	</view>
</template>

<script>
	export default {
		name:'bpw-card',
		props:{
			title:{
				type:String,
				default:''
			},
			iconTitle:{
				type:String,
				default:''
			},
			more:{
				type:String,
				default:''
			},
			iconMore:{
				type:String,
				default:''
			},
			type:{
				 type:Boolean,
				 default: true
			},
		},
		computed:{
			isiconTitle(){
				let str = "";
				switch(this.iconTitle)
				{
				    case "红心":
				        str = "iconfont icon-xinheart118";
				        break;
					case "竖线":
					    str = "vertical-line";
					    break;
				    default:
				        str = this.iconTitle;
				        
				}
				return str;
			},
			isiconMore(){
				let str = "";
				switch(this.iconMore)
				{
				    case "更多":
				        str = "iconfont icon-jiantouyou";
				        break;
				    default:
				        str = this.iconMore;
				        
				}
				return str;
			}
		}
	}
</script>

<style lang="less">
	.bpw-card{
		width: 100%;
		background: #FFFFFF;
		margin-top: 27.17upx;
		.head{
			height: 99.63upx;
			.title{
				font-size: 32.6upx;
				color: #919191;
				.iconfont{margin-right: 18.11upx; font-size: 45.28upx; color:#FF0000;
					&::before{vertical-align: -10.86upx;}
				}
				.vertical-line{
					display: inline-block;
					width: 9.05upx;
					height: 32.6upx;
					vertical-align: bottom;
					margin-right: 18.11upx;
					background: #FE6A22;
				}
			}
			.more{
				font-size: 21.73upx;
				color: #999;
			}
		}
		
		.content{
			font-size: 28.98upx;
			line-height: 63.4upx;
		}
	}
</style>
