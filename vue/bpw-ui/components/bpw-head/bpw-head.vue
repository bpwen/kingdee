<!--
 * @Name: 头部导航封装
 * @Author: bpwen.cn
 * @Date: 2021-11-22 02:23:48
 * @LastEditors: VSCode
 * @LastEditTime: 2021-11-28 03:27:31
 * @url: https://v1.uviewui.com/components/navbar.html

<bpw-head
:backText="current + 1 + '/3'"
:title="headnav.title"
:leftSlot="headnav.leftSlot"
:rightSlot="headnav.rightSlot"
></bpw-head>

headnav:{
    title:'我的简历',
    rightSlot:[
        { title: '编辑'}
    ]
}
-->

<template>
	<u-navbar class="u-main-navbar"
	:class="{'transparent' : opacity}"
	:title="title"
	:background="style"
	:isBack="isBack"
	:back-text="backText"
	:border-bottom="borderBottom"
	>
		<slot></slot>
		
		<view class="slot-wrap" slot="left" v-if="leftSlot.length != 0">
			<view class="main-navbar-right">
				<template v-if="opacity">
					<view class="navbar-right">
						<view class="right-item" v-for="item in leftSlot">
							<view class="a-item u-line-1" :style="item.style[0]">
								<u-icon v-if="ontypeof(item.icon)" :name="item.icon" :size="item.size"></u-icon>
								{{ item.title }}
							</view>
							<view class="b-item u-line-1" :style="item.style[1]">
								<u-icon v-if="ontypeof(item.icon)" :name="item.icon" :size="item.size"></u-icon>
								{{ item.title }}
							</view>
						</view>
					</view>
				</template>
				<view class="right-item u-line-1" v-else v-for="item in leftSlot">
					<u-icon v-if="ontypeof(item.icon)" :name="item.icon" :size="item.size"></u-icon>
					{{ item.title }}
				</view>
			</view>
		</view>
		
		<view slot="title" class="right-item" v-if="typeof this.title == 'object'">
            <view class="a-item" :class="title.class" :style="title.style[0]">
                {{ title.name }}
            </view>
            <view class="b-item" :class="title.class" :style="title.style[1]">
                {{ title.name }}
            </view>
		</view>
		
		<view slot="right" v-if="rightSlot.length != 0">
			<view class="main-navbar-right">
				<view class="navbar-right">
					<template v-if="opacity">
						<view class="right-item" v-for="item in rightSlot">
							<view class="a-item" :style="item.style[0]">
								<u-icon v-if="ontypeof(item.icon)" :name="item.icon" :size="item.size"></u-icon>
								{{ item.title }}
							</view>
							<view class="b-item" :style="item.style[1]">
								<u-icon v-if="ontypeof(item.icon)" :name="item.icon" :size="item.size"></u-icon>
								{{ item.title }}
							</view>
						</view>
					</template>
					<view class="right-item" v-else v-for="item in rightSlot">
						<u-icon v-if="ontypeof(item.icon)" :name="item.icon" :size="item.size"></u-icon>
						<text class="u-line-1" v-if="ontypeof(item.title)">{{ item.title }}</text>
					</view>
				</view>
			</view>
		</view>
	</u-navbar>
</template>

<script>
	/*
	* navbar 自定义导航栏
	* @property {String, Object} title 标题		
	* @property {String, Object} background 导航背景色，支持渐变
	* @property {String} opacity 导航透明 
	* @property {Number} scrollTop 滚动位置,opacity=true的时候需要父页面传入scrollTop滚动位置
	* @property {Boolean} isBack 是否显示导航栏左边返回图标和辅助文字（默认true）
	* @property {String} back-text 返回图标右边的辅助提示文字
	* @property {Boolean} borderBottom 导航栏底部是否显示下边框，如定义了较深的背景颜色，可取消此值（默认true）
	*/
	export default {
		name: "bpw-head",
		props: {
			//标题
			// 	title:{
			// 		name: '您好',
			// 		class: 'size18',
			// 		style:[
			// 			{ opacity: 1},
			// 			{ opacity: 0}
			// 		]
			// 	}	
			title: {
				type: [String, Object],
				default: ''
			},
			//导航背景色，支持渐变
			background: {
				type: [String, Object],
				default: 'rgb(249, 249, 249)'
			},
			//类型 fixed为固定
			opacity: {
				type: [Boolean, String],
				default: false
			},
			//位置
			scrollTop: {
				type: Number,
				default: 0
			},
			//isBack 是否显示导航栏左边返回图标和辅助文字（默认true）
			isBack: {
				type: [Boolean, String],
				default: true
			},
			// 返回的文字提示
			backText: {
				type: String,
				default: ''
			},
			useSlot: {
				type: [Boolean, String],
				default: true
			},
			//右侧卡槽启用
			// 	leftSlot:[
			// 		{ title: '三穗县', icon: 'home-fill', size: '39', style:[
			// 			{ display: 'none', opacity: 1},
			// 			{ position: 'inherit', opacity: 0}
			// 		]}
			// 	]
			leftSlot: {
				type: Array,
				default: function() {
					return [];
				}
			},
			//左侧卡槽启用
			// 	rightSlot:[
			// 		{ icon: 'search', size: '39', style:[
			// 			{ opacity: 1},
			// 			{ opacity: 0}
			// 		]}
			// 	]
			rightSlot: {
				type: Array,
				default: function() {
					return [];
				}
			},
			// 是否显示导航栏的下边框
			borderBottom: {
				type: Boolean,
				default: true
			},
		},
		data() {
			return {
				style: {
					backgroundColor: '#F9F9F9'
				}
			}
		},
		watch: {
			background:{
				immediate: true,
				handler(v){
					let style = {};
					
					if(typeof v == 'string'){
						style.backgroundColor = v;
					}else{
						Object.assign(style, v);
					}
					
					if(this.opacity){
						style.opacity = 0;
					}
					this.style = style;
				}
			},
			scrollTop(v) {
				let num = parseFloat(v);
				let total = parseFloat(280);

				let percentage = Math.round(num / total * 10000) / 100.00;
				
				let count = ''
				if (percentage <= 0) {
					count = 0
				} else if (percentage < 100) {
					count = percentage / 100
				} else {
					count = 100 / 100
				}
				
				this.style.opacity = count;
				
				if(this.leftSlot.length != 0){
					this.leftSlot.forEach((item) => {
						item.style[0].opacity = 1 - count;
						item.style[1].opacity = count;
					})
				}
				
				if(this.rightSlot.length != 0){
					this.rightSlot.forEach((item) => {
						item.style[0].opacity = 1 - count;
						item.style[1].opacity = count;
					})
				}
				
				if(typeof this.title == 'object'){
					this.title.style[0].opacity = 1 - count;
					this.title.style[1].opacity = count;
				}
			}
		},
		methods: {
			ontypeof(itrm){
				return typeof itrm != 'undefined'
			}
		}
	}
</script>

<style lang="less">
	.u-main-navbar {
		&.transparent {
			position: fixed;
			z-index: 999;
		}
	}
	
	.main-navbar-right{
		position: relative;
	}
	
	.navbar-right {
		margin-right: 24rpx;
		display: flex;
	}
	
	.right-item {
		position: relative;
		display: flex;
		justify-content: center;
		.a-item{
			color: #ffffff;
		}
		.b-item{
			color: #000000;
			position: fixed;
			opacity: 0;
		}
		/deep/.u-iconfont{
			margin: 0 12rpx;
		}
	}
	
	.slot-wrap {
		display: flex;
		align-items: center;
		flex: 1;
	}
	
	.u-line-1 {
	    overflow: hidden;
	    white-space: nowrap;
	    text-overflow: ellipsis;
		font-size: 32.6upx;
	}
</style>
