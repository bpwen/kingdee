<template>
	<view class="bpw-img">
		<navigator class="href" :url="to" hover-class="none">
			<image class="cover" :src="img" :style="imgStyle" lazy-load="true"></image>
			<view class="text">
				<text class="title" :style="titleStyle">{{title}}</text>
				<text class="brief" v-if="brief">{{brief}}</text>
				<slot></slot>
			</view>
		</navigator>
	</view>
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
			},
			/*图片样式*/
			imgStyle:{
				type:String,
				default: function() {
					return '';
				}
			},
			/*唯一标识*/
			index:{
				type:Number,
				default: function() {
					return 0;
				}
			},
			/*标题*/
			title:{
				type:String,
				default: function() {
					return '';
				}
			},
			/*标题样式*/
			titleStyle:{
				type:String,
				default: function() {
					return '';
				}
			},
			/*简略*/
			brief:{
				type:String,
				default: function() {
					return '';
				}
			}
		}
    };
</script>

<style>
	.bpw-img .href{display: block; padding-bottom:9.05rpx;margin-top: 13.58rpx;vertical-align: top;overflow: hidden;}
	.bpw-img .cover{width:100%; height: 425.72rpx;}
	.bpw-img .title{display: block; font-weight: bold; margin: 18.11rpx 0;font-size: 27.17rpx;}
	.bpw-img .brief{display: block;  margin-bottom: 18.11rpx; font-size: 23.55rpx;}
</style>