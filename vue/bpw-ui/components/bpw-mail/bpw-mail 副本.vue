// iLikeIt:{
// 	item: {},
// 	list:[],
// 	ArrData:[],
// 	parameterpage: {
// 		id:1081,
// 		page: 1
// 	},
// 	Refresh: false,
// 	LoadStart: false
// }
	
// watch:{
// 	'iLikeIt.ArrData': {
// 		deep: true,
// 		handler: function (v) {
// 			if(v.length != 0){
// 				this.onAddList();
// 			}
// 		}
// 	}
// },
	
// onGetModel(){
// 	GetModel(this.iLikeIt.parameterpage).then(res => {
// 		this.iLikeIt.ArrData = res.data.map((item, index) => {
// 			return {
// 			   src: item.img,
// 			   title: item.title,
// 			   remarks: item.guide
// 		   }
// 		})
// 	})
// },
// onAddList(){
// 	if(this.iLikeIt.list.length == 0 || this.iLikeIt.Refresh){
// 		this.iLikeIt.list = Object.assign(this.iLikeIt.ArrData)
// 	}else{
// 		this.iLikeIt.list = this.iLikeIt.list.concat(this.iLikeIt.ArrData)
// 	}
	
// 	this.iLikeIt.ArrData = [];
	
// 	//刷新成功关闭
// 	if(this.iLikeIt.Refresh){
// 		this.iLikeIt.Refresh = false;
// 		this.$refs.mail.onComplete();
// 	}
// 	//加载更多关闭
// 	if(this.iLikeIt.LoadStart){
// 		this.iLikeIt.LoadStart = false;
// 		this.$refs.mail.uLower(1);
// 	}
// },
// //上拉加载
// onLoadmore(){
// 	this.iLikeIt.LoadStart = true;
// 	this.iLikeIt.parameterpage.page++;
// 	this.onGetModel();
// },
// //刷新加载
// onRefresh(){
// 	this.headnav.keyword = '';
// 	this.iLikeIt.Refresh = true;
// 	this.iLikeIt.parameterpage.page = 1;
// 	this.onGetModel()
// }

<template>
	<scroll-view
	:scroll-y="scroll.bool"
	@scroll="onScroll"
	class="content topBottom" 
	@scrolltolower="lower"
	@touchmove="handletouchmove"
	@touchstart="handletouchstart"
	@touchend="handletouchend"
	>
		<view class="shuaxin flex-row" :style="style">
			<view class="iconfont icon-shuaxin5" :style="iconfont" :class="{'iconAnima': refresh.load}"></view>
		</view>
		<slot></slot>
		<view class="load flex-col hx top" v-if="loadData">
			<u-loadmore :status="loadmore.status" :loadText="loadmore.loadText" :icon-type="loadmore.iconType" :is-dot="loadmore.isDot"/>
		</view>
	</scroll-view>
</template>

<script>
	export default {
		name:'bpw-mail',
		data() {
			return {
				loadData: false,
				scroll:{
					bool: false,
					scrollTop: 0
				},
				loadmore:{
					status: 'loadmore',
					loadText: {
						loadmore: '查看更多',
						loading: '正在加载',
						nomore: '没有更多了'
					},
					iconType: 'flower',
					isDot: false,
				},
				flag: 0,//1向左滑动,2向右滑动,3向上滑动 4向下滑动
				text: '',//向哪里滑动
				lastX: 0,
				lastY: 0,
				index:0,
				count: '',
				refresh:{
					height: -271.73,
					text: '下拉刷新',
					load: false,
					zIndex: 0
				},
			}
		},
		computed:{
			style(){
				if(!this.refresh.load){
					if(this.count !== ''){
						return 'top:' + this.count + 'upx; z-index:' + this.refresh.zIndex
					}
				}else{
					return '';
				}
			},
			iconfont(){
				if(this.count !== ''){
					return '-webkit-transform:rotate(' + this.count + 'deg)'
				}else{
					return ''
				}
			}
		},
		methods: {
			//拉动触发
			onScroll: function(e) {
				this.scroll.scrollTop = e.detail.scrollTop;
			},
			//拉到低部触发加载更多数据
			lower: function(e) {
				this.loadData = true;
				this.loadmore.status = 'loading';
				this.$emit("scrolltolower");
			},
			uLower(i){
				if(i === 0){
					this.loadmore.status = 'nomore';
				}else{
					this.loadData = false;
				}
			},
			//触摸开始
			handletouchstart: function(event) {
			    this.lastX = event.changedTouches[0].pageX;
			    this.lastY = event.changedTouches[0].pageY;
			},
			//手指滑动的过程
			handletouchmove: function(event) {
				if(this.scroll.scrollTop <= 15 && !this.refresh.load){
					if(this.scroll.bool ){
						this.scroll.bool = false;
					}
					if(this.refresh.zIndex == 0){
						this.refresh.zIndex = this.getMaxZIndex();
					}
					
					if (this.flag !== 0) {
						let lastX = event.changedTouches[0].pageX;
						let lastY = event.changedTouches[0].pageY;
						
						//console.log(this.lastX,this.lastY,lastX,lastY)
						switch(this.flag)
						{
							case 1:
								
								break;
							case 2:
								
								break;
							case 3:
								
								break;
							case 4:
								let xx = parseInt(lastY - this.lastY);
								if(xx < 0){
									xx = 0;
								};
								
								if(parseInt(this.refresh.height + xx) < 0){
									this.count = parseInt(this.refresh.height + xx);
									this.refresh.text = '下拉刷新';
								}else{
									this.count = 0;
									this.refresh.text = '松开刷新';
								}
								
								break;    
						}
					}else{
						this.onFangxiang(event);
					}
				}
			},
			//触摸结束，手指离开屏幕
			handletouchend: function(event) {
				switch(this.flag)
				{
				    case 1:
				        
				        break;
				    case 2:
				        
				        break;
					case 3:
					    
					    break;
					case 4:
						if(this.count != 0){
							this.onRefresh();
						}else{
							this.refresh.load = true;
							this.$emit('handletouchend')
						}
					    break;    
				}
			},
			//下拉不到0弹回去
			onRefresh(){
				let i = 2;
				// #ifdef H5
				i = 0
				// #endif

				var sInterval = setInterval(() => {
					if(this.count >= this.refresh.height){
						this.count--;
					}else{
						this.onComplete();
						clearInterval(sInterval);
					}
				}, i)
			},
			//执行完毕执行
			onComplete(){
				this.flag = 0;
				this.text = '没有滑动';
				this.count = '';
				this.scroll.bool = true;
				this.refresh.load = false;
				this.refresh.zIndex = 0;
			},
			onFangxiang(event){
				let currentX = event.changedTouches[0].pageX;
				let currentY = event.changedTouches[0].pageY;
				let tx = currentX - this.lastX;
				let ty = currentY - this.lastY;
				let text = '';
				this.mindex = -1;
				//左右方向滑动
				if (Math.abs(tx) > Math.abs(ty)) {
					if (tx < 0) {
						text = '向左滑动';
						this.flag = 1;
					//  this.getList();  //调用列表的方法
					} else if (tx > 0) {
						text = '向右滑动';
						this.flag = 2;
					}
				}
				//上下方向滑动
				else {
					if (ty < 0) {
						text = '向上滑动';
						this.flag = 3;
					//  this.getList();  //调用列表的方法
					} else if (ty > 0) {
						text = '向下滑动';
						this.flag = 4;
					}
				}
					 
				//将当前坐标进行保存以进行下一次计算
				this.lastX = currentX;
				this.lastY = currentY;
				this.text = text;
			},
			// 获取页面里面最大的z-index值
			getMaxZIndex(){
				return this.$u.zIndex.navbar - 1
			}
		}
	}
</script>

<style scoped>
	
.shuaxin{
	padding-top: 180upx;
	height: 271.73upx;
	position: absolute;
	width: 100%;
	top: -271.73upx;
}
.iconfont{
	font-size: 45.28upx;
	text-align: center;
	width: 81.52upx;
	height: 81.52upx;
	line-height: 83.33upx;
	color: #4bc56c;
	background: #fff;
	border-radius: 50%;
	box-shadow: rgba(0, 0, 0, 0.37) 0px 0px 5px;
}
.iconAnima{
	animation:iconAnima 1s linear infinite;     
}
@keyframes iconAnima{
	0%{-webkit-transform:rotate(0deg);}
	25%{-webkit-transform:rotate(90deg);}
	50%{-webkit-transform:rotate(180deg);}
	75%{-webkit-transform:rotate(270deg);}
	100%{-webkit-transform:rotate(360deg);}
}
	
	
	
.content{
	background: #f1f1f1;
	height: 100vh;
	overflow-y: scroll;
	position: relative;
}
.content.overflow{
	overflow: hidden;
}
/* #ifdef H5 */
.content.topBottom{
	height: calc(100vh - 175upx);
}
/* #endif */

/* #ifdef APP-VUE */
.content.topBottom{
	height: calc(100vh - 250upx);
}
/* #endif */


.load{
	height: 99.63upx;
}

</style>
