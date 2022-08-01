<template>
	<mescroll-uni ref="mescrollRef" @scroll="scroll" @init="mescrollInit" :down="downOption" @down="downCallback" :up="upOption" @up="upCallback">
		<view class="scroll-content" :class="type">
			<slot></slot>
		</view>
	</mescroll-uni>
</template>

<script>
	import MescrollMixin from "@/components/mescroll-uni/mescroll-mixins.js";
	
	export default {
		name:'bpw-mail',
		mixins: [MescrollMixin],
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
			downOptionUse:{
				type:Boolean,
				default: true
			}
		},
		data() {
			return {
				scrollTop:0, //头部滚动条
				downOption: {
					use: false,
					auto: false,
					offset:88
				},
				upOption:{
					onScroll:true
				}
			}
		},
		watch:{
			downOptionUse:{
				immediate: true,
				handler: function (v) {
					this.downOption.use = v
				}
			}
		},
		methods: {
			scroll: function(e) {
				//头部NavBar导航条下拉180改变为不透明
				this.scrollTop = e.scrollTop;
				this.$emit('scroll', this.scrollTop)
			},
			/*下拉加载的回调*/
			upCallback(page) {
				let _this = this;
				setTimeout(function () {
					console.log("加载更多数据");
					_this.mescroll.endByPage(1, 1); //必传参数(当前页的数据个数, 总页数)
				}, 1000);
			},
			/*刷新的回调*/
			downCallback() {
				let _this = this;
				setTimeout(function () {
					console.log("页面刷新");
					_this.mescroll.endSuccess(10);
				}, 1000);
			}
		}
	}
</script>

<style lang="less" scoped>
	.scroll-content{
		background: #f1f1f1;
		color: #333333;
		min-height: 100vh;
		font-size: 25.36upx;
		&.bai{
			background: #FFFFFF;
		}
		&.head-none{
			min-height: calc(100vh - 98rpx);
		}
	}
</style>