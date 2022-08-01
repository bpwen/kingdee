<template>
	<view class="nav-type flex-center zj-nav-p">
		<view v-for="str in list">
			<navigator :url="str.href" hover-class="none">
				<image class="cover" :src="str.src" lazy-load="true"></image>
				<text class="title">{{str.name}}</text>
			</navigator>
		</view>
	</view>
</template>

<script>
	export default{
		name:"home-nav-type",
		props:{
			list:{
				type: [String, Array],
				default: function() {
					return [];
				}
			}
		}
	}
</script>

<style lang="less">
.nav-type{
	text-align: center;
	.cover{
		width: 81.52upx;
		height: 81.52upx;
	}
	.title{
		display:block;
		padding: 9.05upx 0px;
		width: 100%;
		font-size: 25.36upx;
	}
}
</style>