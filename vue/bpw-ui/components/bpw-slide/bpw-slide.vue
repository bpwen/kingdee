<template>
	<!-- 幻灯片 -->
	<view class="home-swiper" v-if="list.length != 0" :style="'height:' + height">
		<view class="slide-page" v-if="SerialNumberTyle === 1">{{currentIndex+1}} / {{list.length}}</view>
		<swiper class="swiper-box" @change="change" :indicator-dots="SerialNumber" indicator-color="#e1e1e1" indicator-active-color="#ff9a6a" autoplay="true" interval="3000" duration="500" circular="true">
			<swiper-item v-for="(item, index) in list" :key="index">
				<navigator url="" hover-class="none">
					<image :src="item.src" mode="aspectFill" class="swiper-img" :style="'height:' + imgheight" lazy-load="true"></image>
				</navigator>
			</swiper-item>
		</swiper>
		<slot></slot>
	</view>
</template>

<script>
	export default {
		name:'bpw-slide',
		props:{
			list:{
				type: [String, Array],
				default: function() {
					return [];
				}
			},
			height:{
				type: String,
				default: function() {
					return '452.89upx';
				}
			},
			imgheight:{
				type: String,
				default: function() {
					return this.height;
				}
			},
			SerialNumberTyle:{
				type:Number,
				default: function() {
					return 0;
				}
			}
		},
		data(){
			return {
				currentIndex: 0,
			}
		},
		computed:{
			SerialNumber(){
				return this.SerialNumberTyle === 0 ? true : false
			}
		},
		methods: {
			   change(e){
				   this.currentIndex = e.detail.current
			   },
		}
	}
</script>

<style scoped>
/*幻灯片*/
.home-swiper{position: relative; display: block; background: #FFFFFF;}
.swiper-box{height: 100%;}
.swiper-box .swiper-img{width: 100%;}
.swiper-box /deep/ .uni-swiper-dots{height: 27.17upx; z-index: 2; bottom: 3.62upx;}
.slide-page {width: initial;position: absolute;bottom: 18.11upx;right: 18.11upx;line-height: 63.4upx;text-align: center;background: rgba(0, 0, 0, 0.55);color: #fff;font-size: 27.17upx;border-radius: 9.05upx;padding: 0upx 21.73upx;z-index: 1;}
</style>
