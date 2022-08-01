<template>
	<scroll-view
		:scroll-top="scrollTop"
		scroll-y="true"
		class="scroll-Y"
		:class="setClass"
		@scrolltoupper="upper"
		@scrolltolower="lower"
		@scroll="scroll"
		
		:refresher-enabled="scroll_refresher_enabled"
		:refresher-triggered="triggered"
		:refresher-threshold="100"
		refresher-background="transparent" 
		@refresherpulling="onPulling"
		@refresherrefresh="onRefresh" 
		@refresherrestore="onRestore"
		@refresherabort="onAbort"
	>
		<view class="scroll-content">
			<slot></slot>
			<view class="load flex-col hx top" v-if="load.bool && loadData">
				<u-loadmore :status="status" :loadText="loadText" :icon-type="iconType" :is-dot="isDot" @loadmore="loadmore"/>
			</view>
		</view>
	</scroll-view>
</template>

<script>
	//@scroll		滚动位置回调
	//@onRefresh	下拉触动刷新回调
	//@onRestore 	下拉刷新完毕回调
	//@loadmore		点击更多回调
	
	export default {
		name:'bpw-mail',
		props:{
			/*
			以下可连着用
			bai 背景百
			head-none 无头部
			*/
			type:{
				type:String,
				default:''
			},
			/*是否启用下拉刷新*/
			refresh:{
				type:Boolean,
				default: false
			},
			/*是否启用上拉获取更多数据*/
			loadData:{
				type:Boolean,
				default: false
			},
			/*是否启动自动加载不用点击*/
			loadDataEval:{
				type:Boolean,
				default: false
			},
			/*是否有底部面板
			topBottom 有头部和底部
			bottom 有底部
			*/
			setClass:{
				type:String,
				default: ''
			},
			/*用于判断刷新加载全部完毕否，全部完毕则 true 就关闭刷新图标*/
			refreshload:{
				type:Boolean,
				default: false
			}
		},
		data() {
			return {
				scrollTop: 0,
				old: {
					scrollTop: 0
				},
				triggered: false,//设置当前下拉刷新状态，true 表示下拉刷新已经被触发，false 表示下拉刷新未被触发
				_freshing: false,
				scroll_refresher_enabled: false,//开启自定义下拉刷新
				load:{
					bool:false
				},
				status: 'loadmore',
				iconType: 'flower',
				isDot: false,
				loadText: {
					loadmore: '查看更多',
					loading: '正在加载',
					nomore: '没有更多了'
				},
				current: 0,
				count:0
			}
		},
		watch:{
			refresh:{
				immediate: true,
				handler: function (v) {
					this.scroll_refresher_enabled = v
				}
			},
			refreshload(v){
				debugger
				if(v){
					this.count = 0;
					this.triggered = false;//触发onRestore，并关闭刷新图标
					this._freshing = false;
				}
			}
		},
		onLoad() {  
			//this._freshing = false;
			// setTimeout(() => {  
			// 	this.triggered = true;//触发onRefresh来加载自己的数据，如果不用这种方式，不要在此改变triggered的值  
			// }, 1000)  
		},
		methods: {
			//拉到头部触发
			upper: function(e) {
				//console.info('拉到头部触发了')
			},
			//拉到低部触发加载更多数据
			lower: function(e) {
				if(this.loadData){
					this.load.bool = true;
					this.statusChange(0);
					if(this.loadDataEval){
						this.loadmore()
					}
				}
			},
			//拉动触发
			scroll: function(e) {
				let scrollTop = e.detail.scrollTop
				this.old.scrollTop = scrollTop
				if(this.refresh){
					if(scrollTop > 20){
						this.scroll_refresher_enabled = false;
					}else{
						this.scroll_refresher_enabled = true;
					}
				}
				this.$emit('scroll', scrollTop)
			},
			//下拉拉动触动
			onPulling(e) {
				//console.log("下拉拉动触动");
			},
			//下拉拉动触动结束关闭刷新交互
			onRefresh() {
				if(this.count == 0){
	
				console.log(1)
				this.count++
				if (this._freshing) return  
				this._freshing = true;  
				
				if (!this.triggered){
					this.triggered = true; 
				}
				
				
				
				this.$emit('onRefresh');
					
				// setTimeout(() => {  
				// 	this.count = 0;
				// 	this.triggered = false;//触发onRestore，并关闭刷新图标  
				// 	this._freshing = false;  
					
				// 	//#ifdef H5
				// 	this.$router.go(0);//强制uniapp刷新当前页面
				// 	//#endif
					
				// 	//#ifdef APP-VUE
				// 	// //uni.redirectTo({
				// 	// uni.navigateTo({
				// 	// 	url: '/pages/refresh/index'
				// 	// });
				// 	//#endif
				// }, 3000)
				}
			},
			//刷新结束恢复
			onRestore() {
				//console.log("恢复");
				// this.$emit('onRestore')
			},
			//刷新中止
			onAbort() {
				//console.log("中止");
			},
			
			// 点击组件，触发加载更多事件(status为'loadmore'状态下才触发)
			loadmore() {
				this.statusChange(1);
				this.$emit('loadmore', this);
			},
			statusChange(index) {
				this.status = index == 0 ? 'loadmore' : index == 1 ? 'loading' : index == 2 ? 'loadmore' : 'nomore';
			},
		}
	}
</script>

<style scoped>
.scroll-Y{
	width: 100vw;
	height: 100vh;
	background: #f1f1f1;
	color: #333333;
}

.scroll-Y.bottom{
	height: calc(100vh - 134.05upx);
}
.scroll-Y.bai{
	background: #FFFFFF;
}


/* #ifdef H5 */
.scroll-Y.topBottom{
	height: calc(100vh - 170upx);
}
/* #endif */

/* #ifdef APP-VUE */
.scroll-Y.topBottom{
	height: calc(100vh - 250upx);
}
/* #endif */

>>> .uni-scroll-view-refresher {
    position: fixed;
    top: 0px;
    width: 100%;
    overflow: hidden;
	z-index: 9999;
}

.load{
	height: 99.63upx;
}
</style>
