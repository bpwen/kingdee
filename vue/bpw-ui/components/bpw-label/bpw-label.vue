<template>
	<view :class="type == '' ? 'house-label' : 'house-label-' + type"><slot></slot></view>
</template>

<script>
    export default {
		props:{
			type:{
				type:String,
				default: function() {
					return '';
				}
			}
		}
    };
</script>

<style lang="less" scoped>
	.house-label {
	    display: inline-block;
	    font-size: 23.55upx;
	    height: 45.28upx;
	    line-height: 45.28upx;
	    padding: 0px 18.11upx;
	    margin-bottom: 18.11upx;
		margin-right: 18.11upx;
		background: #EBF5FE;
		color: #0C74CB;
		&-1{
			display: inline-block;	
			color: #70B2DE;
			font-size: 21.73upx;
			padding: 4.52upx 9.05upx;
			margin-right: 9.05upx;
			margin-top: 9.05upx;
			margin-bottom: 9.05upx;
			position: relative;
			
			&:before {
				content: '';
				position: absolute;
				left: 0px;
				top: 0px;
				width: 200%;
				height: 200%;
				transform-origin: 0 0;
				transform: scale(0.5, 0.5);
				box-sizing: border-box;
				border: 1px solid #D9E7F0;
			}
		}
	}
</style>
