/**
	iLikeIt:{
		list:[],
		ArrData:[],
		parameterpage: {
			id:1081,
			page: 1
		},
		Refresh: false,
		LoadStart: false
	}
	
	watch:{
		'iLikeIt.ArrData': {
			deep: true,
			handler: function (v) {
				if(v.length != 0){
					this.onAddList();
				}
			}
		}
	},
	
	onGetModel(){
		GetModel(this.iLikeIt.parameterpage).then(res => {
			if(res.data){
				this.iLikeIt.ArrData = res.data.map((item, index) => {
					return {
					   src: item.img,
					   title: item.title,
					   remarks: item.guide
				   }
				})
			}
		}).catch(error => {
			this.onGbRefresh();
		})
	},
	onAddList(){
		if(this.iLikeIt.list.length == 0 || this.iLikeIt.Refresh){
			this.iLikeIt.list = Object.assign(this.iLikeIt.ArrData)
		}else{
			this.iLikeIt.list = this.iLikeIt.list.concat(this.iLikeIt.ArrData)
		}
		
		this.iLikeIt.ArrData = [];
		
		this.onGbRefresh();
		this.onGbLoadStart();
	},
	//刷新成功关闭
	onGbRefresh(){
		if(this.iLikeIt.Refresh){
			this.iLikeIt.Refresh = false;
			this.$refs.mail.onComplete();
		}
	},
	//加载更多关闭
	onGbLoadStart(){
		if(this.iLikeIt.LoadStart){
			this.iLikeIt.LoadStart = false;
			this.$refs.mail.uLower(1);
		}
	},
	//上拉加载
	onLoadmore(){
		this.iLikeIt.LoadStart = true;
		this.iLikeIt.parameterpage.page++;
		this.onGetModel();
	},
	//刷新加载
	onRefresh(){
		this.headnav.keyword = '';
		this.iLikeIt.Refresh = true;
		this.iLikeIt.parameterpage.page = 1;
		this.onGetModel()
	}

*/

<template>
	<scroll-view
	:scroll-y="scroll.bool"
	@scroll="onScroll"
	class="content"
    :class="{
        'topBottom': btnType == 'topBottom',
        'Bottom': btnType == 'Bottom'
    }"
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
        <app-top-tips ref="uTips" :navbarHeight="navbarHeight"></app-top-tips>
	</scroll-view>
</template>

<script>
	export default {
		name:'bpw-mail',
		props:{
            //刷新是否启用
            breakxBool:{
                type:Boolean,
                default: false
            },
            //拉到低部触发是否启动，有数据则穿true启用
			lowerBool:{
                type:Boolean,
                default: false
            },
            btnType:{
                type:String,
                default: ''// topBottom
            },
			// 导航栏内容区域高度，不包括状态栏高度在内
			navbarHeight:{
				type: Number,
				default: 0
			}
		},
		data() {
			return {
				loadData: false,
				scroll:{
					bool: true,
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
				count: '',
				clickSk: false,//用于点击还是松开
				refresh:{
					load: false,
					zIndex: 0
				},
                bool: {
                    lower: false, //是否启用加载更多
                }
			}
		},
        watch:{
            lowerBool(v){
                this.bool.lower = v;
            }
        },
		computed:{
			style(){
				let style = {}
				if(!this.refresh.load && this.lastX != 0){
					if(this.count != 0){
						style = Object.assign(style, {
							'transform': 'translate3d(0px, '+ this.count +'%, 0px) translateZ(0px)',
							'transition-duration': 'inherit',
							'z-index': + this.refresh.zIndex
						})
					}else{
						style = Object.assign(style, {
							'transform': 'translate3d(0px, 0%, 0px) translateZ(0px)',
							'z-index': + this.refresh.zIndex
						})
					}
				}else if(this.refresh.load){
					style = Object.assign(style, {
						'transform': 'translate3d(0px, 100%, 0px) translateZ(0px)',
						'transition-duration': 'inherit',
						'z-index': + this.refresh.zIndex
					})
				}
				return style;
			},
			iconfont(){
				if(this.count !== ''){
					if(this.count !== 0){
						return '-webkit-transform:rotate(' + this.count * 3.5 + 'deg); opacity:' + this.count / 100
					}else{
						return 'opacity:0; transition-duration: 500ms;'
					}
				}else{
					return ''
				}
			}
		},
		methods: {
			//拉动触发
			onScroll: function(e) {
				this.scroll.scrollTop = e.detail.scrollTop;
                this.$emit('scrollTop', e)
			},
			//拉到低部触发加载更多数据
			lower: function(e) {
                if(this.bool.lower){
                    this.loadData = true;
                    this.loadmore.status = 'loading';
                    this.$emit("scrolltolower");
                }
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
                this.clickSk = true;
			},
			//手指滑动的过程
			handletouchmove: function(event) {
                if(this.breakxBool){
                    if(this.scroll.scrollTop <= 15 && !this.refresh.load){
                        if(this.scroll.bool ){
                            this.scroll.bool = false;
                        }
                        if(this.refresh.zIndex == 0){
                            this.refresh.zIndex = this.getMaxZIndex();
                        }
                        
                        this.onFangxiang(event);
                        
                        switch(this.flag){
                            case 1:
                                
                                break;
                            case 2:
                                
                                break;
                            case 3:
                                this.count--;
                                if(this.count <= 0){
                                    this.count = 0;
                                }
                                break;
                            case 4:
                                this.count++;
                                if(this.count >= 100){
                                    this.count = 100;
                                }
                                break;    
                        }
                    }
                }
			},
			//触摸结束，手指离开屏幕
			handletouchend: function(event) {
				if(this.clickSk){
					this.clickSk = false;
					
					if(this.count < 95){
						this.onRefresh();
					}else if(this.count >= 95){
						this.refresh.load = true;
						this.$emit('handletouchend')
					}
					/*
					//switch(this.flag)
					// {
					//     case 1:	
					//         break;
					//     case 2:
					//         break;
					// 	case 3:
					// 	    break;
					// 	case 4:
					// 		if(this.count < 95){
					// 			this.onRefresh();
					// 		}else if(this.count >= 95){
					// 			this.refresh.load = true;
					// 			this.$emit('handletouchend')
					// 		}
					// 		break;    
					}*/
				}
			},
			//下拉不到0弹回去
			onRefresh(){
				this.count = 0;
				setTimeout(() =>{
					this.onComplete(0);
				},500)
			},
			//执行完毕执行
			onComplete(type){
				this.flag = 0;
				this.lastX = 0;
				this.lastY = 0;
				this.text = '没有滑动';
				this.count = type === undefined ? '' : type;
				this.scroll.bool = true;
				this.refresh.load = false;
				this.refresh.zIndex = 0;
				
				if(type === undefined){
                    this.$refs.uTips.show('刷新成功');
				}
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
			},
		}
	}
</script>

<style lang="scss" scoped>
	.content{
		overflow-y: scroll;
		position: relative;
		&.overflow{
			overflow: hidden;
		}

        &.Bottom{
            /* #ifdef H5 */
			height: calc(100vh - 92upx);
			/* #endif */
			
			/* #ifdef APP-VUE */
			height: calc(100vh - 95upx);
			/* #endif */
        }
		
		&.topBottom{
			/* #ifdef H5 */
			height: calc(100vh - 172upx);
			/* #endif */
			
			/* #ifdef APP-VUE */
			height: calc(100vh - 253upx);
			/* #endif */
		}
	}
	
	.load{
		height: 99.63upx;
	}
	
	.shuaxin{
		padding-top: 180upx;
		height: 271.73upx;
		position: absolute;
		width: 100%;
		top: -271.73upx;
		transition-duration: 500ms;
		
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
	}
</style>
