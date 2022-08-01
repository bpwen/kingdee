<template>
	<view :style="isMailStyle">
		<view class="bpw-head " :style="isStyle">
			<view class="bColor" :style="isColor"></view>
			<view class="head-mail flex-center" :style="stylemail">
				<view class="icon flex-center icon-left" :style="opacityLeft ? 'opacity:' + opacity : ''">
					<view class="iconfont icon-jiantouzuo" @click="setReturn" v-if="isiconLeft.includes('return')">{{iconLeftText.return}}</view>
					<view class="iconfont icon-zhuye" @click="setHome" v-if="isiconLeft.includes('home')">{{iconLeftText.home}}</view>
					<slot name="iconLeft"></slot>
				</view>
				<view class="mail-title flex-center flex-center-1" :style="opacityTitle ? 'opacity:' + opacity : ''">
					<view class="title" v-if="!search">
						<slot name="title">{{title}}</slot>
					</view>
					<view class="search flex-center" :style="searchstyle" v-else>
						<view class="iconfont icon-icon-"></view>
						<input class="i-search" :placeholder="placeholder" />
					</view>
				</view>
				<view class="icon flex-center icon-right" :style="opacityRight ? 'opacity:' + opacity : ''">
					<view :style="'color:' + rcolor">
						<view class="iconfont icon-icon-" v-if="iconRight.includes('search')">{{iconRightText.search}}</view>
						<view class="iconfont icon-zhuye" @click="setHome" v-if="iconRight.includes('home')">{{iconRightText.home}}</view>
						<view class="iconfont icon-iconfontzhizuobiaozhun0257"  v-if="iconRight.includes('more')">{{iconRightText.more}}</view>
						<view class="iconfont icon-fabu2"  v-if="iconRight.includes('release')">{{iconRightText.release}}</view>
						
						<view class="iconfont icon-fenxiang size20-i" v-if="iconRight.includes('share')">{{iconRightText.share}}</view>
						<view class="iconfont icon-kongxinwujiaoxing size26-i"  v-if="iconRight.includes('collections')">{{iconRightText.collections}}</view>
						
						<view class="iconfont icon-fabu4" @click="setPlus" v-if="iconRight.includes('plus')">{{iconRightText.plus}}</view>
						
						<!-- 只文本 -->
						<view v-if="iconRightTxt" class="iconfont m-10-r size18-i" v-for="item in iconRightTxt"  @click="submitForm(item)">{{item}}</view>
						<!-- 自定义 -->	
						<slot name="iconRight"></slot>
						<button class="btn-success h-35-l size16 m-10-r" v-if="rightBtnBool" @click="submitForm(rightBtn)">{{rightBtn}}</button>
					</view>
				</view>
			</view>
		</view>
	</view>
</template>

<script>
	export default{
		name:"bpw-head",
		props:{
			// 图标
			iconLeft:{
				type: [String, Array],
				default: function() {
					return [];//'home','return'
				}
			},
			//图标里面文字
			iconLeftText:{
				type: [String, Array, Object],
				default: function() {
					return [];//'主页','返回箭头'
				}
			},
			iconRight:{
				type: [String, Array],
				default: function() {
					return [];//'search','home','more','release','share','collections','plus'
				}
			},
			//图标里面文字
			iconRightTxt:{
				type: [String, Array],
				default: function() {
					return [];//'搜索','主页','3个点','发布','分享','搜藏','加号'
				}
			},
			//图标里面文字
			iconRightText:{
				type: [String, Array],
				default: function() {
					return [];//'搜索','主页','3个点','发布','分享','搜藏','加号'
				}
			},
			//返回箭头 return true为返回退后一页false自定义
			clickReturn:{
				type: Boolean,
				default: function() {
					return true;
				}
			},
			// 左右标题是会默认显现
			opacityLeft:{
				type: Boolean,
				default: function() {
					return false;
				}
			},
			opacityRight:{
				type: Boolean,
				default: function() {
					return false;
				}
			},
			opacityTitle:{
				type: Boolean,
				default: function() {
					return false;
				}
			},
			//导航背景色，支持渐变
			bgColor: {
				type: [String, Array],
				default: function() {
					return '#F9F9F9';//'#06c1ae';
				}
			},
			prcolor: {
				type: [String, Array],
				default: function() {
					return '#666666';
				}
			},
			//标题
			title: {
				type: String,
				default: function() {
					return '';
				}
			},
			//类型 fixed为固定 默认
			// ordinary 普通的 不固定
			// transparent 透明 不固定的
			// transparentFixed  透明固定的
			type: {
				type: String,
				default: function() {
					return 'fixed';
				}
			},
			//搜索框
			search:{
				type: Boolean,
				default: function() {
					return false;
				}
			},
			//搜索框 style 定义
			searchstyle:{
				type: String,
				default: function() {
					return '';
				}
			},
			//位置
			scrollTop:{
				type:Number,
				default: function() {
					return 0;
				}
			},
			//高度
			height:{
				type:Number,
				default: function() {
					return 99.63;
				}
			},
			placeholder:{
				type: String,
				default: function() {
					return '';
				}
			},
			/* 右边按钮 @submitForm 回执 */
			rightBtnBool:{
				type: Boolean,
				default: function() {
					return false;
				}
			},
			/* 右边按钮名称 */
			rightBtn:{
				type: String,
				default: function() {
					return '完成';
				}
			}
		},
		data() {
			return {
				isStyle: '',
				opacity: 1,
				stylemail: '',
				rcolor:this.prcolor
			}
		},
		watch:{
			type:{
				immediate: true,
				handler(v){
					if(this.type == 'transparent' || this.type == 'transparentFixed'){
						this.opacity = 0
					}
				}
			},
			scrollTop:{
				immediate: true,
				handler: function (v) {
					if(this.type == 'transparent'){
						if(v < 180){
							this.rcolor = '#FFFFFF'
						}else{
							this.rcolor = '#666666'
						}
						let num = parseFloat(v);
						let total = parseFloat(280);
						
						let percentage = Math.round(num / total * 10000) / 100.00;
						
						let count = ''
						if(percentage <= 0){
							count = 0
						}else if(percentage < 100){
							count = percentage / 100
						}else{
							count = 100 / 100
						}
						this.opacity = count
					}
				}
			},
		},
		computed:{
			isColor(){
				let arr = {}
				if(this.bgColor != ''){
					arr['background'] = this.bgColor
				}		
				
				arr['opacity'] = this.opacity
				
				return arr;
			},
			isiconLeft(){
				//#ifdef H5
				if (window.history.length <= 1) {
				    return ['home'];
				} else {
				    return this.iconLeft;
				}
				//#endif
				
				//#ifdef APP-PLUS || APP-VUE
					return this.iconLeft;
				//#endif
			},
			isMailStyle(){
				let arr = {}
				if(this.type == 'ordinary'){
					arr['height'] = this.height + 'upx';
					
					//#ifdef APP-PLUS || APP-VUE
					arr['height'] = (this.height + 36.23) + 'upx';
					//#endif
				}
				return arr
			}
		},
		mounted(){
			this.isStyle = this.getStyle()
		},
		methods:{
			getStyle(){
				let arr = {}
				arr['height'] = this.height + 'upx';
				
				//#ifdef APP-PLUS || APP-VUE
				arr['height'] = (this.height + 36.23) + 'upx';
				this.stylemail = {
					'top':'20upx'
				}
				//#endif
				
				if(this.type == 'ordinary' || this.type == 'transparent'){
					arr['position'] = 'fixed'
					arr['top'] = '0'
					arr['width'] = '100%'
					arr['z-index'] = '2'
				}
				
				if(this.bgColor ==  "#FFFFFF"){
					arr['color'] = '#000000';
				}
				
				return arr
			},
			setHome(){
				uni.navigateTo({url: '/'});
			},
			/*右边符号加号事件*/
			setPlus(){
				this.$emit('setPlus')
			},
			setReturn(){
				if(this.clickReturn){
					//#ifdef H5
					if (window.history.length <= 1) {
						//this.$router.push({path:'/'})
						uni.navigateTo({url: '/'});
						return false
					} else {
						this.$router.go(-1)
					}
					//#endif
					
					//#ifdef APP-PLUS || APP-VUE
					uni.navigateBack({  //uni.navigateTo跳转的返回，默认1为返回上一级
						delta: 1
					});
					//#endif
					
					//#ifdef H5
					//上面都没执行就说明卡在当前页不是最后一条， histroy记录数量大于1，又没有回退记录，只能返回首页，
					//如果上面都执行了 页面都跳走了，这个也就不用管了   
					// setTimeout(() => {
					// 	uni.navigateTo({url: '/'});
					// },500)
					//#endif
				}else{
					this.$emit('setReturn')
				}
			},
			submitForm(item){
				this.$emit('setrightBtn', item);
			}
		}
	}
</script>

<style lang="less">
	.bpw-head{
		color: #666666;
		position: relative;
		/* height: 36.23upx */
		
		.bColor{
			width: 100%;
			height: 100%;
			border-bottom: 1.81upx solid #E5E5E5;
		}
		
		.head-mail{
			width: 100%;
			height: 100%;
			padding: 0upx 9.05upx;
			position: absolute;
			top: 0px;
			
			.mail-title{
				position: absolute; left: 0px; right: 0px; height: 100%;
				.title{
					font-size: 36.23upx;
				}
			}
			
			.icon{
				z-index: 1;
				.iconfont{
					display: inline-block;
					min-width: 57.97upx;
					min-height: 57.97upx;
					line-height: 57.97upx;
					text-align: center;
				}
				.icon-zhuye{
					font-size: 48.91upx;
				}
				.icon-jiantouzuo{
					font-size: 36.23upx;
					.icon-jiantouzuo:before{
						font-size: 39.85upx;
					}
				}
				.icon-icon-{
					font-size: 39.85upx;
					margin-right: 18.11upx;
				}
				.icon-fabu2{
					font-size: 45.28upx;
				}
			}
			
			.search{
				height: 100%;
				position: relative;
				.iconfont{
					position: absolute;
					left: 27.17upx;
					top: 50%;
					margin-top: -14.49upx;
					color: #727272;
					font-size: 28.98upx;
				}
				.i-search{
					background: #FFFFFF;
					border: 1px solid #E5E5E5;
					border-radius: 90.57upx;
					height: 63.4upx;
					width: 100%;
					padding: 0 72.46upx;
					color: #727272;
					text-align: center;
					/* #ifdef APP-PLUS || APP-VUE */
					font-size: 25.36upx;
					/* #endif */
					.uni-input-placeholder{
						color: #c5c0c0;
					}
				}
			}
		}
	}
</style>