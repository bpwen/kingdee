<template>
	<view>
		<uni-transition :mode-class="['fade']" class="maskClass" :show="showPopup" @click="close" />
		<uni-transition :duration="200" :mode-class="['slide-bottom']" :show="showPopup" class="transfromClass">
			<view class="zj-bj popup">
				<view class="c-hex h-55-l ui-center">{{ title }}</view>
				<view class="popup-main">
					<view class="input"><input focus :type="type" v-model="input" :maxlength="maxlength" class="w-100-b h-100-b ui-center size25" /></view>
					<view class="fh" v-if="icon != ''">{{ icon }}</view>
				</view>
				<view class="popup-hint hx-tb size17" v-if="placeholder != ''">{{ placeholder }}</view>
				<slot></slot>
			</view>
		</uni-transition>
	</view>
</template>

<script>
	export default{
		props:{
			show:{
				type: Boolean,
				default: function() {
					return false;
				}
			},
			title:{
				type:String,
				default: function() {
					return '';
				}
			},
			// text	文本输入键盘
			// number	数字输入键盘
			// idcard	身份证输入键盘
			// digit	带小数点的数字键盘
			type:{
				type: String,
				default: function() {
					return 'text';
				}
			},
			value:{
				type: String,
				default: function() {
					return '';
				}
			},
			icon:{
				type: String,
				default: function() {
					return '';
				}
			},
			placeholder:{
				type: String,
				default: function() {
					return '';
				}
			},
			maxlength:{
				type:Number,
				default:-1
			}
		},
		data(){
			return{
				showPopup:false,
				input:''
			}
		},
		watch: {
			value(v){
				this.input = v
			},
			show(v){
				this.showPopup = v
				//#ifdef APP-PLUS || APP-VUE
				this.keyboard()
				//#endif
			},
			// showPopup:{
			// 	deep: true,
			// 	immediate: true,
			// 	handler: function(v) {
			// 		console.log(v)
			// 	}
			// }
		},
		computed:{
			bpw(){
				console.log(this.showPopup)
				if(!this.showPopup){
					this.close()
				}
			}
		},
		methods:{
			close(){				
				this.$emit('close')
				this.$emit("update:show", false)
				
				if(this.input != ''){
					this.$emit("update:value", this.input)
				}
			},
			//监听键盘打开和关闭0为关闭
			keyboard(){
				uni.onKeyboardHeightChange(res => {
					if(res.height == 0){
						this.showPopup = false
						this.close()
					}
				})
			}
		},
		beforeDestroy() {
			//#ifdef APP-PLUS || APP-VUE
			uni.offKeyboardHeightChange(callback)
			//#endif
		}
	}
</script>

<style lang="less" scoped>
	.popup{
		&-main{
			position: relative;
			height: 99.63upx;
			color: #FE552E;
			.input{
				position: absolute;
				width: 100%;
				height: 63.4upx;
				line-height: 63.4upx;
				.ui-center {
					color: #FE552E;
					border: none;
					outline:none
				}
			}
			.fh{
				position: absolute;
				right: 27.17upx;
				height: 63.4upx;
				line-height: 63.4upx;
				font-size: 45.28upx;
			}
		}
		&-hint{
			line-height: 90.57upx;
			background: #F9FAFC;
			color: #999999;
			text-align: center;
		}
	}


	.maskClass {
		position: fixed;
		bottom: 0;
		top: 0;
		left: 0;
		right: 0;
		background-color: rgba(0, 0, 0, 0.4);
	}
	.transfromClass {
		position: fixed;
		bottom: 0px;
		left: 0;
		right: 0;
		overflow: auto;
		background: #f1f1f1;
	}
</style>