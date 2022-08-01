操作

<template>
	<view class="btn-main flex-right">
		<navigator class="btn" url="/pages/user/release/secondhand/add">编辑</navigator>
		<view class="btn iconfont icon-gengduo5" @tap="actionSheetTap"></view>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				buttonRect: {}
			}
		},
		// #ifdef H5
		onReady() {
			this.getNodeInfo()
			window.addEventListener('resize', this.getNodeInfo)
		},
		beforeDestroy() {
			window.removeEventListener('resize', this.getNodeInfo)
		},
		// #endif
		methods: {
			actionSheetTap() {
				const that = this
				uni.showActionSheet({
					//title:'标题',
					itemList: ['分享', '下架', '删除'],
					popover: {
						top: that.buttonRect.top * 2 + that.buttonRect.height,
						left: that.buttonRect.left + that.buttonRect.width/2
					},
					success: (e) => {
						console.log(e.tapIndex);
						uni.showToast({
							title:"点击了第" + e.tapIndex + "个选项",
							icon:"none"
						})
					}
				})
			},
			// #ifdef H5
			getNodeInfo() {
				let i = 1
				console.log(i++)
				uni.createSelectorQuery().select('.icon-gengduo5').boundingClientRect().exec((ret) => {
					const rect = ret[0]
					if (rect) {
						this.buttonRect = rect
					}
				});
			}
			// #endif
		}
	}
</script>

<style lang="less" scoped>
.btn-main{
	padding-bottom: 18.11upx;
	padding-right: 27.17upx;
	.btn{
		line-height: 45.28upx;
		font-size: 28.98upx;
		margin-left: 18.11upx;
		padding: 0upx 18.11upx;
		border: 1.81upx solid #C7C7C7;
		border-radius: 36.23upx;
	}
	.icon-gengduo5{
		width: 63.4upx;
		text-align: center;
		font-size: 45.28upx;
		font-weight: bold;
		padding: 0upx;
	}
}
</style>