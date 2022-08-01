<template>
	<view>
		<!-- <view style="background:#FFFFFF; padding:40rpx;">
			<block v-if="hasLocation === true">
				<view class="uni-hello-text uni-center" style="margin-top:10px;">
					{{locationAddress}}
				</view>
				<view class="uni-h2 uni-center uni-common-mt">
					<text>E: {{location.longitude[0]}}°{{location.longitude[1]}}′</text>
					<text>\nN: {{location.latitude[0]}}°{{location.latitude[1]}}′</text>
				</view>
			</block>
		</view> -->
		<view @tap="chooseLocation">
			<slot name="btn"></slot>
		</view>
		<!-- <button @tap="clear">清空</button> -->
	</view>
</template>

<script>
	var util = require('../../../common/util.js');
	var formatLocation = util.formatLocation;

	export default {
		data() {
			return {
				hasLocation: false,
				location: {},
				locationAddress: ''
			}
		},
		methods: {
			chooseLocation: function () {
				uni.chooseLocation({
					success: (res) => {
						this.hasLocation = true,
						this.location = formatLocation(res.longitude, res.latitude),
						this.locationAddress = res.address
						this.$emit("click", res)
					}
				})
			},
			clear: function () {
				this.hasLocation = false
			}
		}
	}
</script>

<style lang="less">
	
</style>