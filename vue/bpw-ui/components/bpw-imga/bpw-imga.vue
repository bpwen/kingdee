<!--
<view class="hx" v-for="(item, index) in list" :key="index">
	<bpw-imga :img="item.src"></bpw-imga>
	<view class="btn-main flex-right">
		<navigator class="btn" url="/pages/user/release/secondhand/add">编辑</navigator>
		<view class="btn iconfont icon-gengduo5" @tap="actionSheetTap"></view>
	</view>
</view>
-->

<!--
list:[
	{ src: 'http://localhost:8080/static/1/1.jpg', href: 'www.baidu.com'},
	{ src: 'http://localhost:8080/static/1/2.jpg', href: 'www.baidu.com'},
	{ src: 'http://localhost:8080/static/1/3.jpg', href: 'www.baidu.com'},
	{ src: 'http://localhost:8080/static/1/4.jpg', href: 'www.baidu.com'},
	{ src: 'http://localhost:8080/static/1/1.jpg', href: 'www.baidu.com'},
	{ src: 'http://localhost:8080/static/1/2.jpg', href: 'www.baidu.com'},
	{ src: 'http://localhost:8080/static/1/3.jpg', href: 'www.baidu.com'},
	{ src: 'http://localhost:8080/static/1/4.jpg', href: 'www.baidu.com'}
]
-->


<template>
	<navigator class="item flex" hover-class="none" url="/pages/secondhand/show">
		<view class="cover">
			<image :src="img" class="img" lazy-load="true"></image>
		</view>
		<view class="text">
			<view class="title">
				<slot name="title">单层冰箱，带冷冬冷藏功能，可满足一两</slot>
			</view>
			<view class="brief">
				<slot name="brief">￥<text class="txt">220</text></slot>
			</view>
			<view class="info flex-left">
				<slot name="info">
					<view>曝光 2.9 万</view>
					<view class="circular"></view>
					<view>浏览 332</view>
					<view class="circular"></view>
					<view>想要 20</view>
				</slot>
			</view>
		</view>
	</navigator>
</template>

<script>
    export default {
		name: 'bpw-img',
		props:{
			/*跳转链接*/
			to:{
				type:String,
				default: function() {
					return '';
				}
			},
			/*封面图片*/
			img:{
				type:String,
				default: function() {
					return '';
				}
			}
		}
    };
</script>

<style lang="less" scoped>
	.item{
		padding: 27.17upx;
		.cover{
			width: 162upx;
			height: 163.04upx;
			margin-right: 27.17upx;
			border-radius: 23.55upx;
			overflow: hidden;
			.img{
				width: 100%;
				height: 100%;
			}
		}
		.text{
			padding: 9.05upx 0upx;
			.title{
				font-weight: bold;
				font-size: 27.24upx;
				margin-bottom: 21.73upx;
			}
			.brief{
				color: #F94745;
				margin-bottom: 27.17upx;
				.txt{
					font-size: 30.79upx;
				}
			}
			.info{
				color: #A3A3A3;
				font-size: 27.17upx;
				.circular{
					width: 5.43upx;
					height: 5.43upx;
					background: #A3A3A3;
					border-radius: 50%;
					margin: 0upx 14.49upx;
				}
			}
		}
	}
</style>